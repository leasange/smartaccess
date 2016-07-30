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
    }
}
