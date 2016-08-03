using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.VerInfoMgr
{
    public partial class StaffInfoMgr : UserControl
    {
        public StaffInfoMgr()
        {
            InitializeComponent();
            deptTree.Tree.NodeMouseDown += Tree_NodeMouseDown;
        }

        void Tree_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                Node deptNode = e.Node;
                decimal orgId = -1;
                if (deptNode != null)
                {
                    Maticsoft.Model.SMT_ORG_INFO orgInfo = deptNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (orgInfo != null)
                    {
                        orgId = orgInfo.ID;
                    }
                }
                DoSearch(true, true, orgId);
            }
        }

        private void biAddUser_Click(object sender, EventArgs e)
        {
            FrmStaffInfo staffInfo = new FrmStaffInfo();
            staffInfo.ShowDialog(this);
            if (staffInfo.HasChanged)
            {
                DoSearch(false, _byDeptTree);
            }
        }

        private void biDoSearch_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }
        private bool _byDeptTree = false;
        private decimal _orgId = -1;
        /// <summary>
        /// 搜索
        /// </summary>
        private void DoSearch(bool resetCount=false, bool byDeptTree=false,decimal orgId=-1,int delayTime=0)
        {
            _byDeptTree = byDeptTree;
            
            string strWhere = "1=1";
            if (_byDeptTree && orgId == -1)
            {
                Node deptNode = deptTree.Tree.SelectedNode;
                if (deptNode != null)
                {
                    Maticsoft.Model.SMT_ORG_INFO orgInfo = deptTree.Tree.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (orgInfo != null)
                    {
                        orgId = orgInfo.ID;
                    }
                }
            }
            
            if (resetCount)
            {
                pageDataGridView.Reset();
            }
            int startIndex = pageDataGridView.PageControl.StartIndex;
            int endIndex = pageDataGridView.PageControl.EndIndex;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
                List<Maticsoft.Model.SMT_STAFF_INFO> list = new List<Maticsoft.Model.SMT_STAFF_INFO>();
                if (resetCount)//重置总数
                {
                    int count =0;
                    if (byDeptTree)
                    {
                        count = bll.GetRecordCountByDept(orgId);
                    }
                    else
                    {
                        count = bll.GetRecordCount(strWhere);
                    }
                    this.Invoke(new Action(() =>
                        {
                            pageDataGridView.PageControl.TotalRecords = count;
                        }));
                    if (count==0)
                    {
                        goto END;
                    }
                }
                DataSet ds = null;
                if (byDeptTree)
                {
                  ds=  bll.GetListByPageByDept(orgId, startIndex, endIndex);
                }
                else
                {
                    ds = bll.GetListByPageWithDept(strWhere, "ORG_ID", startIndex, endIndex);
                }
                list = bll.DataTableToListWithDept(ds.Tables[0]);
                END:
                this.Invoke(new Action(() =>
                {
                    DoShow(list);
                }));
            });
            waiting.Show(this);
        }
        private void DoShow(List<Maticsoft.Model.SMT_STAFF_INFO> list)
        {
            dgvStaffs.Rows.Clear();
            foreach (var item in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                string cards = "";
                if (item.CARDS != null && item.CARDS.Count > 0)
                {
                    foreach (var card in item.CARDS)
                    {
                        cards += card.CARD_NO + ";";
                    }
                }
                row.CreateCells(dgvStaffs,
                    item.STAFF_NO,
                    item.REAL_NAME,
                    item.ORG_NAME,
                    cards.TrimEnd(';'),
                    0,
                    item.IS_FORBIDDEN?"已挂失":"",
                    item.VALID_STARTTIME.ToString("yyyy-MM-dd") + " 至 " + item.VALID_ENDTIME.ToString("yyyy-MM-dd"),
                    item.TELE_PHONE,
                    "详情",
                    "授权",
                    "修改"
                    );
                row.Tag = item;
                dgvStaffs.Rows.Add(row);
            }
        }
        private void StaffInfoMgr_Load(object sender, EventArgs e)
        {
            DoSearch(true,true,300);
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false, _byDeptTree, _orgId);
        }

        private void dgvStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                if(dgvStaffs.Columns[e.ColumnIndex].Name=="Col_XG")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo!=null)
                    {
                        FrmStaffInfo frmStaffInfo = new FrmStaffInfo(staffInfo);
                        frmStaffInfo.ShowDialog(this);
                        if (frmStaffInfo.HasChanged)
                        {
                            DoSearch(false, _byDeptTree);
                        }
                    }
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name=="Col_CK")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo != null)
                    {
                        FrmStaffInfo frmStaffInfo = new FrmStaffInfo(staffInfo,true);
                        frmStaffInfo.ShowDialog(this);
                    }
                }
                
            }
        }
    }
}
