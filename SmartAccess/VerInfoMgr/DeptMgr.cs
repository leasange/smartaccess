using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using Li.Controls.Excel;

namespace SmartAccess.VerInfoMgr
{
    /// <summary>
    /// 证件编码
    /// </summary>
    public partial class DeptMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(DeptMgr));
        public DeptMgr()
        {
            InitializeComponent();
            this.deptTree.Tree.NodeMouseUp += deptTree_NodeMouseUp;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        private void deptTree_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Right)
            {
                ctxMenu.Show(Cursor.Position);
            }
            Maticsoft.Model.SMT_ORG_INFO info = e.Node.Tag as Maticsoft.Model.SMT_ORG_INFO;
            if (info!=null)
            {
                tbSelectDeptPath.Text = e.Node.FullPath;
                tbDeptNo.Text = info.ORG_CODE;
                tbDeptName.Text = info.ORG_NAME;
            }
        }
        private Maticsoft.Model.SMT_ORG_INFO GetSelectOrg()
        {
            if (this.deptTree.Tree.SelectedNode != null)
            {
                return this.deptTree.Tree.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
            }
            else return null;
        }
        private void biAddDept_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            DoAddDept(orgInfo);
        }
        private void DoAddDept(Maticsoft.Model.SMT_ORG_INFO orgInfo)
        {
            decimal parId = -1;
            if (orgInfo != null)
            {
                parId = orgInfo.PAR_ID;
            }
            FrmAddOrModifyDept frmDept = new FrmAddOrModifyDept(parId);
            if (frmDept.ShowDialog(this) == DialogResult.OK)
            {
                var node = DeptDataHelper.CreateNode(frmDept.OrgInfo);
                if (this.deptTree.Tree.SelectedNode == null || this.deptTree.Tree.SelectedNode.Parent == null)
                {
                    this.deptTree.Tree.Nodes.Add(node);
                }
                else
                {
                    this.deptTree.Tree.SelectedNode.Parent.Nodes.Add(node);
                    this.deptTree.Tree.SelectedNode.Parent.Expand();
                }
            }
        }
        private void biAddSubDept_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            if (orgInfo == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个节点！");
                return;
            }
            else
            {
                FrmAddOrModifyDept frmDept = new FrmAddOrModifyDept(orgInfo.ID);
                if (frmDept.ShowDialog(this) == DialogResult.OK)
                {
                    var node = DeptDataHelper.CreateNode(frmDept.OrgInfo);
                    if (this.deptTree.Tree.SelectedNode == null)
                    {
                        this.deptTree.Tree.Nodes.Add(node);
                    }
                    else
                    {
                        this.deptTree.Tree.SelectedNode.Nodes.Add(node);
                        this.deptTree.Tree.SelectedNode.Expand();
                    }
                }
            }
        }

        private void biModifyDept_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            if (orgInfo == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个节点！");
                return;
            }
            else
            {
                FrmAddOrModifyDept frmDept = new FrmAddOrModifyDept(orgInfo);
                if (frmDept.ShowDialog(this) == DialogResult.OK)
                {
                    string text = frmDept.OrgInfo.ORG_NAME + " [" + frmDept.OrgInfo.ORG_CODE + "]";
                    this.deptTree.Tree.SelectedNode.Text = text;
                    this.deptTree.Tree.SelectedNode.Tooltip = text;
                }
            }
        }
        private List<Maticsoft.Model.SMT_ORG_INFO> GetSelectWithSubDepts()
        {
            List<Maticsoft.Model.SMT_ORG_INFO> depts = new List<Maticsoft.Model.SMT_ORG_INFO>();
            if (this.deptTree.Tree.SelectedNode != null && this.deptTree.Tree.SelectedNode.Tag is Maticsoft.Model.SMT_ORG_INFO)
            {
                depts.Add((Maticsoft.Model.SMT_ORG_INFO)this.deptTree.Tree.SelectedNode.Tag);
                GetSubDepts(this.deptTree.Tree.SelectedNode, ref depts);
            }
            return depts;
        }
        private void GetSubDepts(DevComponents.AdvTree.Node node, ref List<Maticsoft.Model.SMT_ORG_INFO> depts)
        {
            foreach (DevComponents.AdvTree.Node item in node.Nodes)
            {
                depts.Add((Maticsoft.Model.SMT_ORG_INFO)item.Tag);
                GetSubDepts(item, ref depts);
            }
        }

        private void biDeleteDept_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            if (orgInfo == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个节点！");
                return;
            }
            else
            {
                if (MessageBox.Show("确定删除当前部门及其子部门？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    List<Maticsoft.Model.SMT_ORG_INFO> depts = GetSelectWithSubDepts();
                    CtrlWaiting waiting = new CtrlWaiting("删除部门...", () =>
                    {
                        try
                        {
                        	DeptDataHelper.DeleteDepts(depts);
                            this.Invoke(new Action(() =>
                                {
                                    this.deptTree.Tree.SelectedNode.Remove();
                                }));
                        }
                        catch (System.Exception ex)
                        {
                            log.Error("删除部门错误：", ex);
                            WinInfoHelper.ShowInfoWindow(this, "删除部门异常:" + ex.Message);
                        }
                    });
                    waiting.Show(this);
                }
            }
        }

        private void biRefreshDept_Click(object sender, EventArgs e)
        {
            this.deptTree.EnsureVisible(-1);
            this.deptTree.RefreshTree();
        }

        private void tsmiAddSubDept_Click(object sender, EventArgs e)
        {
            biAddSubDept_Click(sender, e);
        }

        private void tsmiModifyDept_Click(object sender, EventArgs e)
        {
            biModifyDept_Click(sender, e);
        }

        private void tsmiMoveDept_Click(object sender, EventArgs e)
        {
            biMoveDept_Click(sender, e);
        }

        private void biMoveDept_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            if (orgInfo==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择移动的部门！");
                return;
            }
            FrmMoveDept frmMove = new FrmMoveDept(orgInfo);
            if (frmMove.ShowDialog(this)== DialogResult.OK)
            {
                this.deptTree.RefreshTree();
                this.deptTree.EnsureVisible(orgInfo.ID);
            }
        }

        private void biDownloadDeptModel_Click(object sender, EventArgs e)
        {
            //WinInfoHelper.ShowInfoWindow(this, "建设中，敬请期待！");
            try
            {
                DataTable dt = new DataTable("部门模板");
                dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("部门编码"),
                new DataColumn("上级部门编码"),
                new DataColumn("部门名称"),
                new DataColumn("排序")
            });
                DataRow dr = dt.NewRow();
                ExportHelper.ExportEx(dt, "部门模板.xls", "部门列表");
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "部门模板下载异常：" + ex.Message);
                log.Error("部门模板下载异常", ex);
            }
        }

        private void biInput_Click(object sender, EventArgs e)
        {
            //WinInfoHelper.ShowInfoWindow(this, "建设中，敬请期待！");
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    bool iscancel;
                    List<Maticsoft.Model.SMT_ORG_INFO> orgs = new List<Maticsoft.Model.SMT_ORG_INFO>();
                    ImportHelper.ImportEx(out iscancel, 2, 1, 4, new ImportDataHandle((o,ise,row,error) =>
                    {
                        if (ise)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "导入中发生行值错误,行号：" + row + " 错误：" + error);
                            return;
                        }
                        Maticsoft.Model.SMT_ORG_INFO org = new Maticsoft.Model.SMT_ORG_INFO();
                        org.ORG_CODE = o[0];
                        int ord = 100;
                        int.TryParse(o[3], out ord);
                        org.ORDER_VALUE = ord;
                        org.ORG_NAME = o[2];
                        org.PAR_ORG_CODE = o[1];
                        org.PAR_ID = -1;
                        orgs.Add(org);
                    }));
                    if (!iscancel)
                    {
                        if (orgs.Count==0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "导入部门个数为0！");
                            return;
                        }
                        foreach (var item in orgs)
                        {
                            if (string.IsNullOrWhiteSpace(item.ORG_CODE) || string.IsNullOrWhiteSpace(item.ORG_NAME))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "导入失败，存在部门编码或者名称为空！编码：" + item.ORG_CODE + ",名称：" + item.ORG_NAME + ",行号：" + orgs.IndexOf(item));
                                return;
                            }
                        }
                        foreach (var item in orgs)
                        {
                            var dept = DeptDataHelper.GetDeptByCode(item.ORG_CODE);
                            if (dept==null)
                            {
                                item.ID = DeptDataHelper.AddDept(item);//添加
                            }
                            else
                            {
                                item.ID = dept.ID;
                                item.PAR_ID = dept.PAR_ID;
                                DeptDataHelper.UpdateDept(item);//更新
                            }
                        }
                        foreach (var item in orgs)
                        {
                            if (string.IsNullOrWhiteSpace(item.PAR_ORG_CODE))
                            {
                                continue;
                            }
                            var f= orgs.Find(m => m.ORG_CODE == item.PAR_ORG_CODE);
                            if (f==null)
	                        {
                                f = DeptDataHelper.GetDeptByCode(item.PAR_ORG_CODE);
                            }
                            if (f == null)
                            {
                                if (item.PAR_ID == -1)
                                {
                                    continue;
                                }
                                item.PAR_ID = -1;
                            }
                            else
                            {
                                if(item.PAR_ID == f.ID)
                                {
                                    continue;
                                }
                                item.PAR_ID = f.ID;
                            }
                            DeptDataHelper.UpdateDept(item);
                        }
                        WinInfoHelper.ShowInfoWindow(this, "导入结束！");
                        this.Invoke(new Action(() =>
                        {
                            biRefreshDept_Click(sender, e);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    log.Error("导入异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "导入异常:" + ex.Message);
                }

            });
            waiting.Show(this);
        }

        private void biOutput_Click(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var datas = DeptDataHelper.GetDepts(true);
                if (datas.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "没有部门可以导出！");
                    return;
                }
                DataTable dt = new DataTable("部门模板");
                dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("部门编码"),
                new DataColumn("上级部门编码"),
                new DataColumn("部门名称"),
                new DataColumn("排序")});
                var g= datas.GroupBy(m => m.PAR_ID);
                foreach (var item in g)
                {
                    var list = item.ToList();
                    var f = datas.Find(m => m.ID == list[0].PAR_ID);
                    if (f!=null)
                    {
                        foreach (var l in list)
                        {
                            l.PAR_ORG_CODE = f.ORG_CODE;
                        }
                    }
                }
                foreach (var item in datas)
                {
                    var row = dt.NewRow();
                    row[0] = item.ORG_CODE;
                    row[1] = item.PAR_ORG_CODE;
                    row[2] = item.ORG_NAME;
                    row[3] = item.ORDER_VALUE;
                    dt.Rows.Add(row);
                }
                this.Invoke(new Action(() =>
                {
                    ExportHelper.ExportEx(dt, "所有部门", "所有部门");
                }));
            });
            waiting.Show(this);
        }

        private void biCombine_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            if (orgInfo == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择合并的部门！");
                return;
            }
            FrmCombineDept frmCombine = new FrmCombineDept(orgInfo);
            if (frmCombine.ShowDialog(this) == DialogResult.OK)
            {
                this.deptTree.RefreshTree();
                //this.deptTree.EnsureVisible(orgInfo.ID);
            }
        }

        private void biDeleteCurrent_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = GetSelectOrg();
            if (orgInfo == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个节点！");
                return;
            }
            else
            {
                if (MessageBox.Show("确定删除当前部门（不包括下级部门）？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                   // List<Maticsoft.Model.SMT_ORG_INFO> depts = GetSelectWithSubDepts();
                    CtrlWaiting waiting = new CtrlWaiting("删除部门...", () =>
                    {
                        try
                        {
                            decimal parId = orgInfo.PAR_ID;
                            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update SMT_ORG_INFO set PAR_ID=" + parId + " where PAR_ID=" + orgInfo.ID);
                            DeptDataHelper.DeleteDepts(new List<Maticsoft.Model.SMT_ORG_INFO> { orgInfo });
                            this.Invoke(new Action(() =>
                            {
                                List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
                                foreach (DevComponents.AdvTree.Node item in this.deptTree.Tree.SelectedNode.Nodes)
                                {
                                    nodes.Add(item);
                                }
                                this.deptTree.Tree.SelectedNode.Nodes.Clear();
                                DevComponents.AdvTree.Node parent = this.deptTree.Tree.SelectedNode.Parent;
                                this.deptTree.Tree.SelectedNode.Remove();
                                if (parent == null)
                                {
                                    this.deptTree.Tree.Nodes.AddRange(nodes.ToArray());
                                }
                                else
                                {
                                    parent.Nodes.AddRange(nodes.ToArray());
                                }
                            }));
                        }
                        catch (System.Exception ex)
                        {
                            log.Error("删除部门错误：", ex);
                            WinInfoHelper.ShowInfoWindow(this, "删除部门异常:" + ex.Message);
                        }
                    });
                    waiting.Show(this);
                }
            }
        }
    }
}
