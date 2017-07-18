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
            this.deptTree.Tree.MultiSelect = true;
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
                tbSelectDeptPath.Text = e.Node.FullPath.Replace("<i><font color=\"#444444\">", "").Replace("</font></i>", "");
                tbSelectDeptPath.Tag = info;
                tbDeptNo.Text = info.ORG_CODE;
                tbDeptName.Text = info.ORG_NAME;
                ShowRoles(info.ID);
                ShowUsers(info.ID, info.ORG_NAME);
            }
        }

        private Maticsoft.Model.SMT_ORG_INFO GetSelectOrg()
        {
            if (this.deptTree.Tree.SelectedNodes.Count>0)
            {
                return this.deptTree.Tree.SelectedNodes[0].Tag as Maticsoft.Model.SMT_ORG_INFO;
            }
            else return null;
        }
        private List<Maticsoft.Model.SMT_ORG_INFO> GetSelectOrgs()
        {
            List<Maticsoft.Model.SMT_ORG_INFO> lists = new List<Maticsoft.Model.SMT_ORG_INFO>();
            if (this.deptTree.Tree.SelectedNodes.Count > 0)
            {
                foreach (DevComponents.AdvTree.Node item in this.deptTree.Tree.SelectedNodes)
                {
                    var a = item.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (a!=null)
                    {
                        lists.Add(a);
                    }
                }
            }
            return lists;
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
                var node = DeptDataHelper.CreateNode(frmDept.OrgInfo,null);
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
                    var node = DeptDataHelper.CreateNode(frmDept.OrgInfo,null);
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

            foreach (DevComponents.AdvTree.Node item in this.deptTree.Tree.SelectedNodes)
            {
                var dept = item.Tag as Maticsoft.Model.SMT_ORG_INFO;
                if (dept!=null)
                {
                    depts.Add(dept);
                }
                GetSubDepts(item, ref depts);
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
           var orgInfos = GetSelectOrgs();
           if (orgInfos.Count==0)
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
                                    List<DevComponents.AdvTree.Node> nodes = new List<DevComponents.AdvTree.Node>();
                                    foreach (DevComponents.AdvTree.Node item in this.deptTree.Tree.SelectedNodes)
                                    {
                                        nodes.Add(item);
                                    }
                                    foreach (var item in nodes)
                                    {
                                        item.Remove();
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
                    ImportHelper2.ImportEx(out iscancel, 2, 1, 4, new ImportDataHandle((o,ise,row,error) =>
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
                            var f = orgs.Find(m => m.ORG_CODE == item.PAR_ORG_CODE);
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
            var orgInfo = GetSelectOrg();
            if (orgInfo==null)
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

        private void biDeleteDept_Click_1(object sender, EventArgs e)
        {
            biDeleteDept.Popup(Cursor.Position);
        }
        private void ShowUsers(decimal orgId,string orgName)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_DEPT_USER duBll = new Maticsoft.BLL.SMT_DEPT_USER();
                var duModels = duBll.GetModelListEx("DEPT_ID=" + orgId);
                this.Invoke(new Action(() =>
                {
                    DoShowUsersToGrid(duModels, orgName);
                }));
            });
            waiting.Show(this);
        }

        private void ShowRoles(decimal orgId)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                var roles= roleBll.GetModelList("ID IN (SELECT RF.ROLE_ID FROM SMT_ROLE_FUN RF WHERE RF.FUN_ID=" + orgId + " and RF.ROLE_TYPE=2)");
                this.Invoke(new Action(() =>
                {
                    DoShowRolesToGrid(roles);
                }));
            });
            waiting.Show(this);
        }

        private void DoShowRolesToGrid(List<Maticsoft.Model.SMT_ROLE_INFO> roles)
        {
            dgvRoleInfos.Rows.Clear();
            if (dgvRoleInfos == null || roles.Count == 0)
            {
                return;
            }
            foreach (var item in roles)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvRoleInfos,
                    item.ROLE_NAME,
                    item.ROLE_DESC,
                    "删除"
                    );
                row.Tag = item;
                dgvRoleInfos.Rows.Add(row);
            }
        }

        private void DoShowUsersToGrid(List<Maticsoft.Model.SMT_DEPT_USER> dus,string orgName)
        {
            dgvUsers.Rows.Clear();
            if (dus == null || dus.Count == 0)
            {
                return;
            }
            foreach (var item in dus)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvUsers,
                    item.USER_INFO.USER_NAME,
                    item.USER_INFO.REAL_NAME,
                    orgName,
                    "删除"
                    );
                row.Tag = item;
                dgvUsers.Rows.Add(row);
            }
        }

        private void btnAddPrivate_Click(object sender, EventArgs e)
        {
            if (tbSelectDeptPath.Tag == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择部门！");
                return;
            }
            Maticsoft.Model.SMT_ORG_INFO orgInfo = (Maticsoft.Model.SMT_ORG_INFO)tbSelectDeptPath.Tag;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_DEPT_USER duBll = new Maticsoft.BLL.SMT_DEPT_USER();
                    var duModels = duBll.GetModelList("DEPT_ID=" + orgInfo.ID);
                    this.Invoke(new Action(() =>
                        {
                            List<decimal> userIds = new List<decimal>();
                            foreach (var item in duModels)
                            {
                                userIds.Add(item.USER_ID);
                            }
                            FrmSelectedUser frmUser = new FrmSelectedUser(userIds, orgInfo.ID);
                            if (frmUser.ShowDialog(this) == DialogResult.OK)
                            {

                                DoShowUsersToGrid(frmUser.SelectedUsers, orgInfo.ORG_NAME);

                            }
                        }));
                }
                catch (System.Exception ex)
                {
                    log.Error("加载用户操作权限异常：" + ex.Message, ex);
                    WinInfoHelper.ShowInfoWindow(this, "加载用户操作权限异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void DeletePrivateUsers(List<DataGridViewRow> rows)
        {
            List<Maticsoft.Model.SMT_DEPT_USER> deptUsers = new List<Maticsoft.Model.SMT_DEPT_USER>();
            foreach (DataGridViewRow item in rows)
            {
                deptUsers.Add((Maticsoft.Model.SMT_DEPT_USER)item.Tag);
            }
            if (deptUsers.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定删除用户？","提示", MessageBoxButtons.OKCancel)!=DialogResult.OK)
            {
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    decimal orgId = deptUsers[0].DEPT_ID;
                    List<string> userIds = new List<string>();
                    foreach (var item in deptUsers)
                    {
                        userIds.Add(item.USER_ID.ToString());
                    }
                    string str = string.Format("  DELETE   FROM SMT_DEPT_USER WHERE DEPT_ID={0} and USER_ID in({1})", orgId, string.Join(",", userIds.ToArray()));
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(str);
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in rows)
                        {
                            dgvUsers.Rows.Remove(item);
                        }
                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "删除异常：" + ex.Message);
                    log.Error("删除异常", ex);
                }
            });
            waiting.Show(this);
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvUsers.SelectedRows)
            {
                rows.Add(item);
            }
            DeletePrivateUsers(rows);
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex==3)
            {
                DeletePrivateUsers(new List<DataGridViewRow>() {dgvUsers.Rows[e.RowIndex] });
            }
        }

        private void btnSelectRole_Click(object sender, EventArgs e)
        {
            var orgInfo = GetSelectOrg();
            if (orgInfo == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个节点！");
                return;
            }
            List<decimal> ids = new List<decimal>();
            foreach (DataGridViewRow row in dgvRoleInfos.Rows)
            {
                Maticsoft.Model.SMT_ROLE_INFO role = (Maticsoft.Model.SMT_ROLE_INFO)row.Tag;
                ids.Add(role.ID);
            }
            FrmRolesSelector s = new FrmRolesSelector(ids,orgInfo.ID);
            if (s.ShowDialog(this) == DialogResult.OK)
            {
                DoShowRolesToGrid(s.SelectRoles);
            }
        }

        private void dgvRoleInfos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                if (dgvRoleInfos.Columns[e.ColumnIndex].Name=="ColDelete")
                {
                    if (MessageBox.Show("确定删除选择角色？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var orgInfo = GetSelectOrg();
                        Maticsoft.Model.SMT_ROLE_INFO role = (Maticsoft.Model.SMT_ROLE_INFO)dgvRoleInfos.Rows[e.RowIndex].Tag;

                        CtrlWaiting waiting = new CtrlWaiting(() =>
                        {
                            try
                            {
                                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN  where FUN_ID=" + orgInfo.ID + " and ROLE_TYPE=2 and ROLE_ID=" + role.ID);
                                this.Invoke(new Action(() =>
                                {
                                    dgvRoleInfos.Rows.RemoveAt(e.RowIndex);
                                }));
                            }
                            catch (System.Exception ex)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "删除角色异常：" + ex.Message);
                                log.Error("删除角色异常", ex);
                            }
                        });
                        waiting.Show(this);
                    }
                }
            }
        }
    }
}
