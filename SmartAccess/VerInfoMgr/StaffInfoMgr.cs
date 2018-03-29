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
using SmartAccess.Common.Datas;
using Li.Access.Core;
using Li.Access.Core.BJTWHCardIssue;
using SmartAccess.Common.Config;
using System.IO;
using Li.Controls.Excel;
using SmartAccess.Common;

namespace SmartAccess.VerInfoMgr
{
    public partial class StaffInfoMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(StaffInfoMgr));

        private List<Maticsoft.Model.SMT_DATADICTIONARY_INFO> staffTypes = new List<Maticsoft.Model.SMT_DATADICTIONARY_INFO>();

        public StaffInfoMgr()
        {
            InitializeComponent();
            deptTree.Tree.NodeMouseDown += Tree_NodeMouseDown;
        }
        private List<decimal> _selectOrgIds = null;
        void Tree_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Node deptNode = e.Node;
                if (deptNode.DataKey=="0")
                {
                    return;
                }
                decimal orgId = -1;
                if (deptNode != null)
                {
                    Maticsoft.Model.SMT_ORG_INFO orgInfo = deptNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (orgInfo != null)
                    {
                        orgId = orgInfo.ID;
                        _selectOrgIds = GetSelectIDs(deptNode);
                    }
                }
                DoSearch(true, true, false, null, orgId);
            }
        }
        private List<decimal> GetSelectIDs(Node orgNode)
        {
            List<decimal> decs = new List<decimal>();
            Maticsoft.Model.SMT_ORG_INFO orgInfo = orgNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
            if (orgInfo != null && orgNode.DataKey !="0")
            {
                decs.Add(orgInfo.ID);
            }
            foreach (Node item in orgNode.Nodes)
            {
                decs.AddRange(GetSelectIDs(item).ToArray());
            }
            return decs;
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
        private bool _byCardNum = false;
        private string _cardNum = null;
        private decimal _orgId = -1;
        private string _strWhere = null;
        /// <summary>
        /// 搜索
        /// </summary>
        private void DoSearch(bool resetCount = false, bool byDeptTree = false, bool byCardNum = false, string cardNum = null, decimal orgId = -1, int delayTime = 0)
        {
            if (resetCount)
            {
                _byDeptTree = byDeptTree;
                _byCardNum = byCardNum;
                _cardNum = cardNum;
                _orgId = orgId;
            }
            else
            {
                if (_byCardNum)
                {
                    byDeptTree = false;
                    byCardNum = true;
                    cardNum = _cardNum;
                }
            }
            string strWhere = "1=1  and IS_DELETE=0";
            if (resetCount)//重置个数
            {
                if (!byCardNum)
                {
                    if (!byDeptTree)
                    {
                        if (tbName.Text.Trim() != "")
                        {
                            strWhere += " and REAL_NAME like '%" + tbName.Text.Trim() + "%'";
                        }
                        if (tbStaffNo.Text.Trim() != "")
                        {
                            strWhere += " and STAFF_NO like '%" + tbStaffNo.Text.Trim() + "%'";
                        }
                        if (tbJob.Text.Trim() != "")
                        {
                            strWhere += " and JOB like '%" + tbJob.Text.Trim() + "%'";
                        }
                        if (dtpValidTime.ValueObject != null)
                        {
                            string date = dtpValidTime.Value.ToString("yyyy-MM-dd 12:00:00");
                            strWhere += " and VALID_STARTTIME <= '" + date + "' and VALID_ENDTIME>='" + date + "'";
                        }
                        if (tbDeptName.Text.Trim() != "")
                        {
                            strWhere += " and ORG_NAME like '%" + tbDeptName.Text.Trim() + "%'";
                        }
                        /*if (tbDoorName.Text.Trim() != "")
                        {
                            strWhere += " and DOOR_NAME like '%" + tbDoorName.Text.Trim() + "%'";
                        }*/

                    }
                    else
                    {
                        if (orgId != -1)
                        {
                            strWhere += " and ORG_ID in (" + string.Join(",", _selectOrgIds.ToArray()) + ")";
                        }
                        else
                        {
                            if (!UserInfoHelper.IsManager)
                            {
                                strWhere += " and ORG_ID in (select RF.FUN_ID from SMT_ROLE_FUN RF where RF.ROLE_TYPE=2 and RF.ROLE_ID=" + UserInfoHelper.UserInfo.ROLE_ID + ")";
                            }
                        }
                    }
                    if (cbIsForbbiden.Checked)
                    {
                        strWhere += " and IS_FORBIDDEN=1";
                    }
                    if ((cbHasCard.Checked && cbHasNoCard.Checked) || (!cbHasCard.Checked && !cbHasNoCard.Checked))
                    { }
                    else if (cbHasCard.Checked)
                    {
                        strWhere += " and  SI.ID in ( select SC.STAFF_ID  from SMT_STAFF_CARD SC,SMT_CARD_INFO CI where SC.CARD_ID=CI.ID group by SC.STAFF_ID )";
                    }
                    else
                    {
                        strWhere += " and  SI.ID not in ( select SC.STAFF_ID  from SMT_STAFF_CARD SC,SMT_CARD_INFO CI where SC.CARD_ID=CI.ID group by SC.STAFF_ID )";
                    }
                    if ((cbHasDoor.Checked && cbHasNoDoor.Checked) || (!cbHasDoor.Checked && !cbHasNoDoor.Checked))
                    { }
                    else if (cbHasDoor.Checked)
                    {
                        strWhere += " and  SI.ID in ( select SC.STAFF_ID as CARD_STAFF_ID from SMT_STAFF_DOOR SC,SMT_DOOR_INFO DI where SC.DOOR_ID=DI.ID  group by SC.STAFF_ID )";
                    }
                    else
                    {
                        strWhere += " and  SI.ID not in ( select SC.STAFF_ID as CARD_STAFF_ID from SMT_STAFF_DOOR SC,SMT_DOOR_INFO DI where SC.DOOR_ID=DI.ID  group by SC.STAFF_ID )";
                    }
                }

                _strWhere = strWhere;
            }
            else
            {
                strWhere = _strWhere;
            }

            /*if (_byDeptTree && orgId == -1)
            {
                Node deptNode = deptTree.Tree.SelectedNode;
                if (deptNode != null)
                {
                    Maticsoft.Model.SMT_ORG_INFO orgInfo = deptTree.Tree.SelectedNode.Tag as Maticsoft.Model.SMT_ORG_INFO;
                    if (orgInfo != null)
                    {
                        orgId = orgInfo.ID;
                        _selectOrgIds = GetSelectIDs(deptTree.Tree.SelectedNode);
                    }
                }
            }*/

            if (resetCount)
            {
                pageDataGridView.Reset();
            }
            int startIndex = pageDataGridView.PageControl.StartIndex;
            int endIndex = pageDataGridView.PageControl.EndIndex;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                staffTypes = dicBll.GetModelList("DATA_TYPE='STAFF_TYPE'");

                Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
                List<Maticsoft.Model.SMT_STAFF_INFO> list = new List<Maticsoft.Model.SMT_STAFF_INFO>();
                if (resetCount)//重置总数
                {
                    int count = 0;
                    if (!byCardNum)
                    {
                        count = bll.GetRecordCountWithDept(strWhere);
                    }
                    else
                    {
                        count = 1;
                    }
                    this.Invoke(new Action(() =>
                        {
                            pageDataGridView.PageControl.TotalRecords = count;
                        }));
                    if (count == 0 && !byCardNum)
                    {
                        goto END;
                    }
                }
                DataSet ds = null;
                //                 if (byDeptTree)
                //                 {
                //                     ds = bll.GetListByPageByDept(orgId, startIndex, endIndex);
                //                 }
                if (!byCardNum)
                {
                    ds = bll.GetListByPageWithDept(strWhere, "ORG_ID", startIndex, endIndex);
                }
                else
                {
                    ds = bll.GetListByCardNum(cardNum);
                }
                list = bll.DataTableToListWithDept(ds.Tables[0]);
            END:
                this.Invoke(new Action(() =>
                {
                    DoShow(list);
                }));
            });
            waiting.Show(this, delayTime);
        }
        private void DoShow(List<Maticsoft.Model.SMT_STAFF_INFO> list)
        {
            dgvStaffs.Rows.Clear();
            foreach (var item in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                string cards = "未发卡";
                string state = "正常";
                int count = 0;
                if (item.CARDS != null && item.CARDS.Count > 0)
                {
                    cards = "";
                    foreach (var card in item.CARDS)
                    {
                        cards += card.CARD_NO + ";";
                        count++;
                    }
                }
                else
                {
                    state = "未发卡";
                }
                if (item.IS_FORBIDDEN)
                {
                    state = "已挂失";
                }
                if (cbHasNoDoor.Checked && (!cbHasDoor.Checked) && state == "正常")
                {
                    state = "未授权";
                }
                string pic = item.PHOTO != null && item.PHOTO.Length > 0 ? "照片" : "无";

                string orgname = "";
                if (!string.IsNullOrWhiteSpace(item.ORG_NAME))
                {
                    orgname += item.ORG_NAME;
                }
                if (!string.IsNullOrWhiteSpace(item.ORG_CODE))
                {
                    orgname += "[" + item.ORG_CODE + "]";
                }
                row.CreateCells(dgvStaffs,
                    item.STAFF_NO,
                    item.REAL_NAME,
                    orgname,
                    cards.TrimEnd(';'),
                    count,
                    state,
                    item.VALID_STARTTIME.ToString("yyyy-MM-dd") + " 至 " + item.VALID_ENDTIME.ToString("yyyy-MM-dd"),
                    item.TELE_PHONE,
                    pic,
                    "查看",
                    "修改",
                    "授权",
                    "上传"
                    );
                row.Tag = item;
                dgvStaffs.Rows.Add(row);
            }
        }
        private void StaffInfoMgr_Load(object sender, EventArgs e)
        {
            DoSearch(true, true, false, null, -1, 300);
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false, _byDeptTree, false, null, _orgId);
        }

        private void dgvStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_Pic")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo != null)
                    {
                        if (staffInfo.PHOTO != null && staffInfo.PHOTO.Length > 0)
                        {
                            try
                            {
                                using (MemoryStream ms = new MemoryStream(staffInfo.PHOTO))
                                {
                                    Image image = Image.FromStream(ms);
                                    if (picImage.Image != null)
                                    {
                                        picImage.Image.Dispose();
                                        picImage.Image = null;
                                    }
                                    picImage.Image = image;
                                }
                                panelImage.Visible = true;
                                panelImage.BringToFront();
                            }
                            catch (Exception ex)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "照片显示异常！" + ex.Message);
                                log.Error("照片显示异常：", ex);
                            }
                        }
                        else
                        {
                            if (picImage.Image != null)
                            {
                                picImage.Image.Dispose();
                                picImage.Image = null;
                            }
                        }
                    }
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_XG")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo != null)
                    {
                        FrmStaffInfo frmStaffInfo = new FrmStaffInfo(staffInfo);
                        frmStaffInfo.ShowDialog(this);
                        if (frmStaffInfo.HasChanged)
                        {
                            DoSearch(false, _byDeptTree);
                        }
                    }
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_CK")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo != null)
                    {
                       // do
                       // {
                            FrmStaffInfo frmStaffInfo = new FrmStaffInfo(staffInfo, true);
                       //     Timer t = new Timer();
                       //     t.Tick += (o, s) =>
                       //         {
                       //             frmStaffInfo.Close();
                       //             t.Dispose();
                       //         };
                       //     t.Interval = 5000;
                       //     t.Start();
                            frmStaffInfo.ShowDialog(this);
                       //  } while (true);
                    }
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_SQ")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo != null)
                    {
                        FrmAddOrModifyStaffPrivate frmStaffInfo = new FrmAddOrModifyStaffPrivate(staffInfo);
                        frmStaffInfo.ShowDialog(this);
                    }
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_SC")
                {
                    Maticsoft.Model.SMT_STAFF_INFO staffInfo = dgvStaffs.Rows[e.RowIndex].Tag as Maticsoft.Model.SMT_STAFF_INFO;
                    if (staffInfo != null)
                    {
                        CtrlWaiting waiting = new CtrlWaiting(() =>
                        {
                            string errMsg = "";
                            bool ret = UploadPrivate.Upload(staffInfo, out errMsg);
                            if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "权限上传异常：" + errMsg);
                                return;
                            }
                            else
                            {
                                WinInfoHelper.ShowInfoWindow(this, "权限上传结束！");
                            }
                        });
                        waiting.Show(this);
                    }
                }
            }
        }
        private List<DataGridViewRow> GetSelectRows()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                var s = dgvStaffs.SelectedRows;
                foreach (DataGridViewRow item in s)
                {
                    rows.Add(item);
                }
            }
            if (dgvStaffs.SelectedCells.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择人员！");
                return null;
            }
            if (dgvStaffs.SelectedCells[0].RowIndex < 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择人员！");
                return null;
            }
            foreach (DataGridViewCell item in dgvStaffs.SelectedCells)
            {
                if (item.RowIndex >= 0)
                {
                    if (!rows.Contains(dgvStaffs.Rows[item.RowIndex]))
                        rows.Add(dgvStaffs.Rows[item.RowIndex]);
                }
            }
            return rows;
        }

        private DataGridViewRow GetSelectRow()
        {
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                if (dgvStaffs.SelectedRows.Count > 1)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择一个人员！");
                    return null;
                }
                else
                {
                    return dgvStaffs.SelectedRows[0];
                }
            }
            if (dgvStaffs.SelectedCells.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择人员！");
                return null;
            }
            if (dgvStaffs.SelectedCells.Count > 1)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个人员！");
                return null;
            }
            if (dgvStaffs.SelectedCells[0].RowIndex < 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择人员！");
                return null;
            }
            DataGridViewRow row = dgvStaffs.Rows[dgvStaffs.SelectedCells[0].RowIndex];
            return row;
        }
        //销户
        private void biDeleteStaff_Click(object sender, EventArgs e)
        {
            var rows = GetSelectRows();
            if (rows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定注销选择人员,选择个数：" + rows.Count + "？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (var item in rows)
            {
                staffInfos.Add((Maticsoft.Model.SMT_STAFF_INFO)item.Tag);
            }
            CtrlWaiting ctrlwaiting = new CtrlWaiting(() =>
            {

                Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
                foreach (var item in staffInfos)
                {
                    try
                    {
                        item.IS_DELETE = true;
                        item.DEL_TIME = DateTime.Now;
                        bll.Update(item);
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_STAFF_CARD where STAFF_ID=" + item.ID);
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_STAFF_DOOR where STAFF_ID=" + item.ID);
                    }
                    catch (Exception ex)
                    {
                        log.Error("注销人员异常1：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "注销异常：" + ex.Message);
                        item.IS_DELETE = false;
                        return;
                    }
                }

                string errMsg = "";
                bool ret = UploadPrivate.Upload(staffInfos, out errMsg);
                if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                {
                    WinInfoHelper.ShowInfoWindow(this, "注销时，权限删除存在异常：" + errMsg);
                }

                this.Invoke(new Action(() =>
                    {
                        foreach (var item in rows)
                        {
                            dgvStaffs.Rows.Remove(item);
                        }

                    }));
                WinInfoHelper.ShowInfoWindow(this, "注销成功！");

            });
            ctrlwaiting.Show(this);
        }
        //销卡
        private void biDeleteCard_Click(object sender, EventArgs e)
        {
            DoDeleteCard();
        }

        private void DoDeleteCard(bool resetCard = false)
        {
            DataGridViewRow row = GetSelectRow();
            if (row == null)
            {
                return;
            }
            if (MessageBox.Show("确定进行选择人员销卡？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            Maticsoft.Model.SMT_STAFF_INFO staffInfo = row.Tag as Maticsoft.Model.SMT_STAFF_INFO;
            if (!resetCard)
            {
                if (staffInfo.CARDS == null || staffInfo.CARDS.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "无授权的卡！");
                    return;
                }
            }

            CtrlWaiting ctrlwaiting = new CtrlWaiting(() =>
            {
                try
                {
                    string errMsg;
                    bool ret = InternalDeleteCard(staffInfo, out errMsg);
                    if (ret)
                    {
                        this.Invoke(new Action(() =>
                        {
                            staffInfo.CARDS.Clear();
                            staffInfo.DELETE_CARD = false;
                            row.Cells[3].Value = "未发卡";
                            row.Cells[4].Value = 0;
                            row.Cells[5].Value = "未发卡";
                        }));
                    }
                    else
                    {
                        log.Error("销卡异常：" + errMsg);
                        WinInfoHelper.ShowInfoWindow(this, "销卡异常：" + errMsg);
                    }
                }
                catch (Exception ex)
                {
                    if (resetCard)
                    {
                        log.Error("销卡异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "销卡异常：" + ex.Message);
                    }
                    else
                    {
                        log.Error("换卡异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "换卡异常：" + ex.Message);
                    }
                }

            });
            ctrlwaiting.Show(this);
        }
        private bool InternalDeleteCard(Maticsoft.Model.SMT_STAFF_INFO staffInfo, out string errMsg, bool isShowDetail=true)
        {
            Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
            staffInfo.DELETE_CARD = true;
            try
            {
                bool ret = UploadPrivate.Upload(staffInfo, out errMsg, isShowDetail:isShowDetail);
                if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                {
                    staffInfo.DELETE_CARD = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                staffInfo.DELETE_CARD = false;
                return false;
            }
            staffInfo.DELETE_CARD = false;
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_STAFF_CARD where STAFF_ID=" + staffInfo.ID);
            return true;
        }
        //读卡
        private void biReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                string num;
                string wgNum;
                string errorMsg;
                if (!CardIssueDeviceHelper.ReadCard(out num, out wgNum, out errorMsg))
                {
                    WinInfoHelper.ShowInfoWindow(this, "读取卡号失败：" + errorMsg);
                    return;
                }
                DoSearch(true, false, true, num);
            }
            catch (Exception ex)
            {
                log.Error("读卡错误：" + ex.Message);
                WinInfoHelper.ShowInfoWindow(this, "读卡异常：" + ex.Message);
            }
        }

        private void biPublishCard_Click(object sender, EventArgs e)
        {
            DoPublishCard(true);
        }

        private void DoPublishCard(bool isonlypublish = true)
        {
            DataGridViewRow row = GetSelectRow();
            if (row == null)
            {
                return;
            }
            if (MessageBox.Show("确定进行选择人员" + (isonlypublish ? "发卡" : "换卡") + "？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            Maticsoft.Model.SMT_STAFF_INFO staffInfo = row.Tag as Maticsoft.Model.SMT_STAFF_INFO;
            if (staffInfo.CARDS == null || staffInfo.CARDS.Count == 0)
            {
                staffInfo.CARDS = new List<Maticsoft.Model.SMT_CARD_INFO>();
                isonlypublish = true;
            }

            CtrlWaiting ctrlwaiting = new CtrlWaiting(() =>
            {
                try
                {

                    if (!isonlypublish)//换卡，先删除所有卡片
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback((o) =>
                            {
                                string errMsg;
                                bool ret = InternalDeleteCard(staffInfo, out errMsg,false);
                                if (!ret)
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "删除授权的卡片异常：" + errMsg);
                                }
                                FrmDetailInfo.Close();
                            }));
                        System.Threading.Thread.Sleep(200);
                    }
                    string num;
                    string wgNum;
                    string errorMsg;
                    if (!CardIssueDeviceHelper.ReadCard(out num, out wgNum, out errorMsg))
                    {
                        WinInfoHelper.ShowInfoWindow(this, "读取卡号失败：" + errorMsg);
                        return;
                    }
                    try
                    {
                        Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                        var cards = sbll.GetModelListByCardNo(num);
                        if (cards.Count > 0)
                        {
                            bool delete = false;
                            var card = cards.Find(m => m.STAFF_ID == staffInfo.ID && m.CARD_NO == num);
                            if (card != null)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "该人员已绑定此卡，换卡或发卡结束！");
                                return;
                            }
                            this.Invoke(new Action(() =>
                            {
                                if (MessageBox.Show("该卡已绑定人员，是否强制解绑？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    delete = true;
                                }
                            }));
                            if (!delete)
                            {
                                return;
                            }

                            string errMsg = "";
                            bool ret = UploadPrivate.DeletePrivateByCardNum(num, out errMsg, cards);
                            if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "卡片解绑异常：" + errMsg);
                                return;
                            }
                            foreach (var item in cards)
                            {
                                sbll.Delete(item.STAFF_ID, item.CARD_ID);
                                this.Invoke(new Action(() =>
                                {
                                    foreach (DataGridViewRow old in dgvStaffs.Rows)
                                    {
                                        Maticsoft.Model.SMT_STAFF_INFO staff = (Maticsoft.Model.SMT_STAFF_INFO)old.Tag;
                                        if (staff.ID == item.STAFF_ID)
                                        {
                                            var c = staff.CARDS.Find(m => m.ID == item.CARD_ID);
                                            if (c != null)
                                            {
                                                staff.CARDS.Remove(c);
                                            }
                                            string str = "";
                                            foreach (var cc in staff.CARDS)
                                            {
                                                str += cc.CARD_NO + ";";
                                            }
                                            str = str.TrimEnd(';');
                                            old.Cells[3].Value = str == "" ? "未发卡" : str;
                                            old.Cells[4].Value = staff.CARDS.Count;
                                            old.Cells[5].Value = staff.CARDS.Count > 0 ? "正常" : "未发卡";
                                            break;
                                        }
                                    }
                                }));
                            }
                            staffInfo.CARDS.Clear();

                            Maticsoft.BLL.SMT_CARD_INFO cardBll = new Maticsoft.BLL.SMT_CARD_INFO();
                            var cardInfos = cardBll.GetModelList("CARD_NO='" + num + "'");
                            var cardInfo = cardInfos[0];
                            staffInfo.CARDS.Add(cardInfo);
                            Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
                            scBll.Add(new Maticsoft.Model.SMT_STAFF_CARD()
                            {
                                STAFF_ID = staffInfo.ID,
                                CARD_ID = cardInfo.ID,
                                ACCESS_STARTTIME = staffInfo.VALID_STARTTIME,
                                ACCESS_ENDTIME = staffInfo.VALID_ENDTIME
                            });
                            bool uret = UploadPrivate.Upload(staffInfo, out errMsg);
                            if (!uret || !string.IsNullOrWhiteSpace(errMsg))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "换卡权限上传异常：" + errMsg);
                            }
                            else
                            {
                                WinInfoHelper.ShowInfoWindow(this, "换卡或发卡成功。");
                            }
                            this.Invoke(new Action(() =>
                            {
                                staffInfo.DELETE_CARD = false;
                                row.Cells[3].Value = cardInfo.CARD_NO;
                                row.Cells[4].Value = 1;
                                row.Cells[5].Value = "正常";
                            }));
                        }
                        else
                        {
                            string errMsg;
                            Maticsoft.BLL.SMT_CARD_INFO cardBll = new Maticsoft.BLL.SMT_CARD_INFO();
                            var cardInfos = cardBll.GetModelList("CARD_NO='" + num + "'");
                            if (cardInfos.Count == 0)//没有此卡
                            {
                                Maticsoft.Model.SMT_CARD_INFO card = new Maticsoft.Model.SMT_CARD_INFO();
                                card.CARD_NO = num;
                                card.CARD_DESC = num;
                                card.CARD_TYPE = 0;
                                card.CARD_WG_NO = wgNum;
                                card.STAFF_ID = -1;
                                card.ID = cardBll.Add(card);
                                cardInfos.Add(card);
                            }
                            var cardInfo = cardInfos[0];
                            staffInfo.CARDS.Add(cardInfo);
                            Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
                            scBll.Add(new Maticsoft.Model.SMT_STAFF_CARD()
                            {
                                STAFF_ID = staffInfo.ID,
                                CARD_ID = cardInfo.ID,
                                ACCESS_STARTTIME = staffInfo.VALID_STARTTIME,
                                ACCESS_ENDTIME = staffInfo.VALID_ENDTIME
                            });
                            bool uret = UploadPrivate.Upload(staffInfo, out errMsg);
                            if (!uret || !string.IsNullOrWhiteSpace(errMsg))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "换卡权限上传失败，请重新上传：" + errMsg);
                            }
                            else
                            {
                                WinInfoHelper.ShowInfoWindow(this, "换卡或发卡成功。");
                            }
                            

                            this.Invoke(new Action(() =>
                            {
                                staffInfo.DELETE_CARD = false;

                                string str = "";
                                foreach (var cc in staffInfo.CARDS)
                                {
                                    str += cc.CARD_NO + ";";
                                }
                                str = str.TrimEnd(';');
                                row.Cells[3].Value = str == "" ? "未发卡" : str;
                                row.Cells[4].Value = staffInfo.CARDS.Count;
                                row.Cells[5].Value = staffInfo.CARDS.Count > 0 ? "正常" : "未发卡";
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("发生异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "发生异常：" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    if (isonlypublish)
                    {
                        log.Error("销卡异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "销卡异常：" + ex.Message);
                    }
                    else
                    {
                        log.Error("换卡异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "换卡异常：" + ex.Message);
                    }
                }

            });
            ctrlwaiting.Show(this);
        }

        private void biChangeCard_Click(object sender, EventArgs e)
        {
            DoPublishCard(false);
        }

        private void biForbbiden_Click(object sender, EventArgs e)
        {
            DoForbbiden(true);
        }

        private void biUnForbbiden_Click(object sender, EventArgs e)
        {
            DoForbbiden(false);
        }

        private void DoForbbiden(bool isforbbiden)
        {
            DataGridViewRow row = GetSelectRow();
            if (row == null)
            {
                return;
            }
            if (MessageBox.Show("确定进行选择人员" + (isforbbiden ? "挂失" : "解挂") + "？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            Maticsoft.Model.SMT_STAFF_INFO staffInfo = row.Tag as Maticsoft.Model.SMT_STAFF_INFO;
            if (staffInfo.CARDS == null || staffInfo.CARDS.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "无授权的卡！");
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                bool oldstate = staffInfo.IS_FORBIDDEN;
                try
                {
                    Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    staffInfo.IS_FORBIDDEN = isforbbiden;
                    staffBll.Update(staffInfo);
                    this.Invoke(new Action(() =>
                        {
                            row.Cells[5].Value = isforbbiden ? "已挂失" : "正常";
                        }));
                }
                catch (Exception ex)
                {
                    log.Error((isforbbiden ? "挂失" : "解挂") + "失败：", ex);
                    WinInfoHelper.ShowInfoWindow(this, (isforbbiden ? "挂失" : "解挂") + "失败：" + ex.Message);
                    staffInfo.IS_FORBIDDEN = oldstate;
                }
                try
                {
                    string errMsg = "";
                    bool ret = UploadPrivate.Upload(staffInfo, out errMsg);
                    if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                    {
                        WinInfoHelper.ShowInfoWindow(this, (isforbbiden ? "挂失" : "解挂") + "时，权限上传异常，请稍候重新操作：" + errMsg);
                        log.Error("人员ID:" + staffInfo.ID + "，姓名：" + staffInfo.REAL_NAME + " " + (isforbbiden ? "挂失" : "解挂") + "时，权限上传异常：" + errMsg);
                    }
                }
                catch (Exception ex)
                {
                    log.Error((isforbbiden ? "挂失" : "解挂") + "权限上传异常，请稍候重新操作：", ex);
                    WinInfoHelper.ShowInfoWindow(this, (isforbbiden ? "挂失" : "解挂") + "权限上传异常，请稍候重新操作：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void biExportPhoto_Click(object sender, EventArgs e)
        {
            var rows = GetSelectRows();
            if (rows.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "未选择任何人员！");
                return;
            }
            List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (var item in rows)
            {
                Maticsoft.Model.SMT_STAFF_INFO staffInfo = (Maticsoft.Model.SMT_STAFF_INFO)item.Tag;
                if (staffInfo.PHOTO == null || staffInfo.PHOTO.Length == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, staffInfo.REAL_NAME + " 没有照片！");
                }
                else
                {
                    staffInfos.Add(staffInfo);
                }
            }
            if (staffInfos.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "没有照片可以导出！");
                return;
            }
            if (folderBrowser.ShowDialog(this)==DialogResult.OK)
            {
                foreach (var item in staffInfos)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(item.PHOTO))
                        {
                            using (Image image = Image.FromStream(ms))
                            {
                                string filename = item.REAL_NAME + ".jpg";
                                if (!string.IsNullOrWhiteSpace(item.STAFF_NO))
                                {
                                    filename=item.REAL_NAME + "_" + item.STAFF_NO + ".jpg";
                                }
                                string file = Path.Combine(folderBrowser.SelectedPath, filename);
                                image.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this,item.REAL_NAME+ " 保存照片异常：" + ex.Message);
                        log.Error(item.REAL_NAME + " 保存照片异常：", ex);
                        return;
                    }
                }
                WinInfoHelper.ShowInfoWindow(this, "保存照片结束！");
            }
        }

        private void biClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbDeptName.Text = "";
            tbJob.Text = "";
            tbStaffNo.Text = "";
            dtpValidTime.ValueObject = null;
        }

        private void cbHasCard_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }

        private void cbHasNoCard_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }

        private void cbIsForbbiden_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }

        private void cbHasDoor_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }

        private void cbHasNoDoor_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }

        private void biPrivateCopy_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectRow();
            if (row == null)
            {
                return;
            }
            Maticsoft.Model.SMT_STAFF_INFO staffInfo = row.Tag as Maticsoft.Model.SMT_STAFF_INFO;

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_DOOR sdBll = new Maticsoft.BLL.SMT_STAFF_DOOR();
                    var doors = sdBll.GetModelList("STAFF_ID=" + staffInfo.ID);
                    if (doors.Count == 0)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "选择的人员未授权！");
                        return;
                    }
                    this.Invoke(new Action(() =>
                        {
                            FrmPrivateCopy copy = new FrmPrivateCopy(staffInfo, doors);
                            copy.ShowDialog(this);
                        }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "复制权限异常：" + ex.Message);
                    log.Error("复制权限异常:", ex);
                    return;
                }
            });
            waiting.Show(this);
        }

        private void biOneKeyUpload_Click(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting("正在上传权限...", () =>
            {
                try
                {
                    //Maticsoft.BLL.SMT_STAFF_INFO staffbll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    //var staffs = staffbll.GetModelList("");
                    string errMsg = "";
                    bool ret = UploadPrivate.UploadAllPrivate(out errMsg);
                    SmtLog.InfoFormat("权限", "上传权限结果：{0},{1}", ret ? "成功" : "失败", errMsg);
                    if (errMsg == "")
                    {
                        errMsg = "成功！";
                    }
                    WinInfoHelper.ShowInfoWindow(this, "上传结束，输出结果：" + errMsg);
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "上传异常：" + ex.Message);
                    log.Error("一键上传权限异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void pageDataGridView_PageControl_ExportCurrent(object sender, Li.Controls.PageEventArgs args)
        {
            DoExport(args.StartIndex, args.EndIndex);
        }

        private void pageDataGridView_PageControl_ExportAll(object sender, Li.Controls.PageEventArgs args)
        {
            DoExport(-1, -1);
        }
        private void DoExport(int startIndex,int endIndex)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {

                try
                {
                    Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    DataSet ds = null;
                    if (!_byCardNum)
                    {
                        ds = bll.GetListByPageWithDept(_strWhere, "ORG_ID", startIndex, endIndex);
                    }
                    else
                    {
                        ds = bll.GetListByCardNum(_cardNum);
                    }
                    var list = bll.DataTableToListWithDept(ds.Tables[0]);

                    this.Invoke(new Action(() =>
                    {
                        DoExport(list);
                    }));
                }
                catch (System.Exception ex)
                {
                    log.Error("导出异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "导出异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }
        private DataTable CreateStaffTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("部门编码");
            dt.Columns.Add("部门名称");
            dt.Columns.Add("编码格式");
            dt.Columns.Add("证件编号");
            dt.Columns.Add("姓名");
            dt.Columns.Add("性别");
            dt.Columns.Add("职务");
            dt.Columns.Add("职员类别");
            dt.Columns.Add("出生日期");
            dt.Columns.Add("政治面貌");
            dt.Columns.Add("婚姻状态");
            dt.Columns.Add("技术等级");
            dt.Columns.Add("有效证件名称");
            dt.Columns.Add("有效证件号码");
            dt.Columns.Add("办公电话");
            dt.Columns.Add("手机");
            dt.Columns.Add("籍贯");
            dt.Columns.Add("民族");
            dt.Columns.Add("宗教");
            dt.Columns.Add("学历");
            dt.Columns.Add("邮箱");
            dt.Columns.Add("有效开始时间");
            dt.Columns.Add("有效结束时间");
            dt.Columns.Add("入职时间");
            dt.Columns.Add("离职时间");
            dt.Columns.Add("通信地址");
            dt.Columns.Add("注册时间");
            dt.Columns.Add("挂失状态");
            dt.Columns.Add("卡号");
            return dt;
        }
        private void DoExport(List<Maticsoft.Model.SMT_STAFF_INFO> staffs,bool ismodel=false)
        {
            DataTable dt = CreateStaffTable();
            Maticsoft.BLL.SMT_VER_FORMAT formatbll = new Maticsoft.BLL.SMT_VER_FORMAT();
            var list= formatbll.GetModelList("");
            foreach (var item in staffs)
            {
                DataRow dr = dt.NewRow();
                dr["部门编码"] = item.ORG_CODE;
                dr["部门名称"] = item.ORG_NAME;
                if (item.STAFF_NO_TEMPLET!=null)
                {
                   var format= list.Find(m => m.ID == (decimal)item.STAFF_NO_TEMPLET);
                   if (format!=null)
                   {
                       dr["编码格式"] = format.VER_NAME;
                   }
                }
                dr["证件编号"] = item.STAFF_NO;
                dr["姓名"] = item.REAL_NAME;
                int isex = item.SEX == null ? 0 : (int)item.SEX;
                string sex = "未知";
                if (isex==1)
                {
                    sex = "男";
                }
                else if (isex==2)
                {
                    sex = "女";
                }
                dr["性别"] = sex;
                dr["职务"] = item.JOB;
                dr["职员类别"] = "";
                foreach (var s in staffTypes)
                {
                    if (s.DATA_KEY==item.STAFF_TYPE)
                    {
                        dr["职员类别"] = s.DATA_NAME;
                        break;
                    }
                }

                dr["出生日期"] = item.BIRTHDAY;
                dr["政治面貌"] = item.POLITICS;
                int married = item.MARRIED == null ? 0 : (int)item.MARRIED;
                string mm = "未知";
                if (married == 1)
                {
                    mm = "已婚";
                }
                else if (married == 2)
                {
                    mm = "未婚";
                }
                dr["婚姻状态"] = mm;
                dr["技术等级"] = item.SKIIL_LEVEL;
                dr["有效证件名称"] = item.CER_NAME;
                dr["有效证件号码"] = item.CER_NO;
                dr["办公电话"] = item.TELE_PHONE;
                dr["手机"] = item.CELL_PHONE;
                dr["籍贯"] = item.NATIVE;
                dr["民族"] = item.NATION;
                dr["宗教"] = item.RELIGION;
                dr["学历"] = item.EDUCATIONAL;
                dr["邮箱"] = item.EMAIL;
                dr["有效开始时间"] = item.VALID_STARTTIME;
                dr["有效结束时间"] = item.VALID_ENDTIME;
                dr["入职时间"] = item.ENTRY_TIME;
                dr["离职时间"] = item.ABORT_TIME;
                dr["通信地址"] = item.ADDRESS;
                dr["注册时间"] = item.REG_TIME;
                dr["挂失状态"] = item.IS_FORBIDDEN ? "已挂失" : "正常";
                var cards = item.CARDS;
                if (cards.Count==0)
                {
                    dr["卡号"] = "";
                }
                else
                {
                    string nos = "";
                    foreach (var c in cards)
                    {
                        nos += c.CARD_NO + ",";
                    }
                    dr["卡号"] = nos.TrimEnd(',');
                }
                dt.Rows.Add(dr);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            if (!ismodel)
            {
                sfd.FileName = "人员信息.xls";
            }
            else
            {
                sfd.FileName = "人员信息模板.xls";
            }
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bool ret =ExportHelper.Export(dt, sfd.FileName, "人员信息");
                if (!ismodel)
                {
                    SmtLog.InfoFormat("人员", "导出人员信息，个数：{0},目录：{1},结果：{2}", dt.Rows.Count, sfd.FileName, ret ? "成功" : "失败");
                }
                else
                {
                    string staffphoto = Path.Combine(Path.GetDirectoryName(sfd.FileName), "人员照片");
                    if (!Directory.Exists(staffphoto))
                    {
                        Directory.CreateDirectory(staffphoto);
                    }
                    StreamWriter sw= File.CreateText(Path.Combine(staffphoto, "照片名称说明.txt"));
                    sw.Write("在进行人员导入时，所有人员照片存储于当前目录“人员照片”中，照片名称格式为“姓名_编号”或“姓名”，格式可为bmp,jpg,png。\r\n注意:如果照片只以“姓名”命名，重名会有冲突问题！");
                    sw.Close();
                }
                if (ret)
                {
                    try
                    {
                        string path = Path.GetDirectoryName(sfd.FileName);
                        path = Path.Combine(path, "人员照片");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        foreach (var item in staffs)
                        {
                            if (item.PHOTO != null && item.PHOTO.Length > 0)
                            {
                                try
                                {
                                    using (MemoryStream ms = new MemoryStream(item.PHOTO))
                                    {
                                        Image image = Image.FromStream(ms);
                                        string filename = item.REAL_NAME + ".jpg";
                                        if (!string.IsNullOrWhiteSpace(item.STAFF_NO))
                                        {
                                            filename = item.REAL_NAME + "_" + item.STAFF_NO + ".jpg";
                                        }
                                        string file = Path.Combine(path, filename);
                                        image.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        image.Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "导出“" + item.REAL_NAME + "”照片发生异常：" + ex.Message);
                                    log.Error("导出“" + item.REAL_NAME + "”照片发生异常：", ex);
                                    SmtLog.ErrorFormat("人员", "导出人员：{0} 照片发生异常：{1}", item.REAL_NAME , ex.Message);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "导出照片发生异常：" + ex.Message);
                        log.Error("导出照片发生异常：", ex);
                        SmtLog.ErrorFormat("人员", "导出人员照片发生异常：{0}", ex.Message);
                    }
                    if (!ismodel)
                    {
                        MessageBox.Show("导出结束,照片自动保存至导出目录“人员照片”下。");
                    }
                    else
                    {
                        MessageBox.Show("导出模板结束,照片导入时请放置导出目录的“人员照片”下，以“姓名_编号”或“姓名”命名。");
                    }
                }
                else
                {
                    MessageBox.Show("导出失败!");
                }

            }
        }
        private DateTime GetDateTime(object datetime,DateTime def)
        {
            string str = Convert.ToString(datetime);
            DateTime dt=def;
            DateTime.TryParse(str, out dt);
            var min = DateTime.Parse("1800-01-01 00:00:00");
            if (dt<min)
            {
                dt = min;
            }
            return dt;
        }
        private string GetNotNullString(object str)
        {
            string strr = Convert.ToString(str);
            if (strr==null)
            {
                strr = "";
            }
            return strr;
        }
        private void biImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel(*.xls)|*.xls|所有文件(*.*)|*.*";
            ofd.FileName = "人员信息.xls";
            if (ofd.ShowDialog(this)==DialogResult.OK)
            {
                DataTable dt = CreateStaffTable();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    var depts = DeptDataHelper.GetDepts();
                    FrmDetailInfo.Show(false);
                    FrmDetailInfo.AddOneMsg("开始导入...");
                    int count = 0;
                    Maticsoft.BLL.SMT_VER_FORMAT formatbll = new Maticsoft.BLL.SMT_VER_FORMAT();
                    var list = formatbll.GetModelList("");
                    ImportHelper2.Import(ofd.FileName, 2, 1, 29, new ImportDataHandle((target,iserror,row,error) =>
                    {
                        if (iserror)
                        {
                            FrmDetailInfo.AddOneMsg("获取行值有错误，忽略改行导入,行号："+row+" 错误：" + error, isRed: true);
                            return;
                        }
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = target;
                        string name = GetNotNullString(dr["姓名"]);
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            FrmDetailInfo.AddOneMsg("警告：姓名为空不予导入！",isRed:true);
                            return;
                        }
                        try
                        {
                            Maticsoft.Model.SMT_STAFF_INFO staffInfo = new Maticsoft.Model.SMT_STAFF_INFO();
                            staffInfo.ABORT_TIME = GetDateTime(dr["离职时间"], DateTime.MaxValue);
                            staffInfo.ADDRESS = GetNotNullString(dr["通信地址"]);
                            staffInfo.BIRTHDAY = GetDateTime(dr["出生日期"], DateTime.MinValue);
                            staffInfo.CELL_PHONE = GetNotNullString(dr["手机"]);
                            staffInfo.CER_NAME = GetNotNullString(dr["有效证件名称"]);
                            staffInfo.CER_NO = GetNotNullString(dr["有效证件号码"]);
                            staffInfo.EDUCATIONAL = GetNotNullString(dr["学历"]);
                            staffInfo.EMAIL = GetNotNullString(dr["邮箱"]);
                            staffInfo.ENTRY_TIME = GetDateTime(dr["入职时间"], DateTime.MinValue);
                            staffInfo.IS_FORBIDDEN = GetNotNullString(dr["挂失状态"]) == "已挂失";
                            staffInfo.JOB = GetNotNullString(dr["职务"]);

                            try
                            {//防止老版本Excel无职员类型
                                string stafftype = GetNotNullString(dr["职员类型"]);
                                foreach (var s in staffTypes)
                                {
                                    if (s.DATA_NAME == stafftype)
                                    {
                                        staffInfo.STAFF_TYPE = s.DATA_KEY;
                                        break;
                                    }
                                }
                            }
                            catch
                            {
                            }


                            string marr = GetNotNullString(dr["婚姻状态"]);
                            if (marr == "已婚")
                            {
                                staffInfo.MARRIED = 1;
                            }
                            else if (marr == "未婚")
                            {
                                staffInfo.MARRIED = 2;
                            }
                            else
                            {
                                staffInfo.MARRIED = 0;
                            }
                            staffInfo.NATION = GetNotNullString(dr["民族"]);
                            staffInfo.NATIVE = GetNotNullString(dr["籍贯"]);
                          
                            string orgCode = GetNotNullString(dr["部门编码"]);
                            Maticsoft.Model.SMT_ORG_INFO dept = null;
                            if (!string.IsNullOrWhiteSpace(orgCode))
                            {
                                dept = depts.Find(m => m.ORG_CODE == orgCode);
                            }
                            else
                            {
                                string orgName = GetNotNullString(dr["部门名称"]);
                                if (!string.IsNullOrWhiteSpace(orgName))
                                {
                                    dept = depts.Find(m => m.ORG_NAME == orgName);
                                }
                            }

                            if (dept != null)
                            {
                                staffInfo.ORG_ID = dept.ID;
                            }
                            else
                            {
                                staffInfo.ORG_ID = -1;
                            }
                            try
                            {
                                string realname = dr["姓名"]+"";
                                string staffno = dr["证件编号"] + "";

                                string path = Path.Combine(Path.GetDirectoryName(ofd.FileName), "人员照片", dr["姓名"]+"");
                                string[] ends = new string[] {".jpg",".png",".jpeg",".bmp" };
                                string temp = null ;
                                foreach (var item in ends)
                                {
                                    List<string> ts = new List<string>();
                                    ts.Add(path + "_" + staffno + item);
                                    ts.Add(path  + staffno + item);
                                    ts.Add(path  + item);
                                    foreach (var t in ts)
                                    {
                                        if (File.Exists(t))
                                        {
                                            temp = t;
                                            break;
                                        }
                                    }
                                    if (temp!=null)
                                    {
                                        break;
                                    }
                                }
                                if (temp!=null)
                                {
                                    Image image = Image.FromFile(temp);
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        Image newImage = CommonClass.Get2InchPhoto(image);
                                        if (newImage != null)
                                        {
                                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                            newImage.Dispose();
                                        }
                                        else
                                        {
                                            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        }
                                        image.Dispose();
                                        staffInfo.PHOTO = ms.GetBuffer();
                                    }
                                }
                                else
                                {
                                    staffInfo.PHOTO = new byte[0];
                                }
                            }
                            catch (Exception)
                            {
                            }
                            staffInfo.POLITICS = GetNotNullString(dr["政治面貌"]);
                            staffInfo.REAL_NAME = name;
                            staffInfo.REG_TIME = GetDateTime(dr["注册时间"], DateTime.Now);
                            staffInfo.RELIGION = GetNotNullString(dr["宗教"]);
                            string sex = GetNotNullString(dr["性别"]);
                            if (sex == "男")
                            {
                                staffInfo.SEX = 1;
                            }
                            else if (sex == "女")
                                staffInfo.SEX = 2;
                            else staffInfo.SEX = 0;
                            staffInfo.SKIIL_LEVEL = GetNotNullString(dr["技术等级"]);
                            
                            var str11 = GetNotNullString(dr["编码格式"]);
                            if (!string.IsNullOrWhiteSpace(str11))
                            {
                                var format = list.Find(m => m.VER_NAME == str11);
                                if (format != null)
                                {
                                    staffInfo.STAFF_NO_TEMPLET = format.ID;
                                }
                            }

                            staffInfo.STAFF_NO = GetNotNullString(dr["证件编号"]);
                            staffInfo.TELE_PHONE = GetNotNullString(dr["办公电话"]);
                            staffInfo.VALID_ENDTIME = GetDateTime(dr["有效结束时间"], DateTime.MaxValue);
                            staffInfo.VALID_STARTTIME = GetDateTime(dr["有效开始时间"], DateTime.MinValue);
                            Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                            if (!string.IsNullOrWhiteSpace(staffInfo.STAFF_NO))//判断证件号已存在
                            {
                                if (Maticsoft.DBUtility.DbHelperSQL.Exists("select count(1) from SMT_STAFF_INFO where STAFF_NO='" + staffInfo.STAFF_NO + "' and IS_DELETE=0"))
                                {
                                    FrmDetailInfo.AddOneMsg("已存在相同证件号人员：" + staffInfo.STAFF_NO + ",人员" + staffInfo.REAL_NAME + "跳过导入！", isRed: true);
                                    return;
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(staffInfo.REAL_NAME))//判断姓名已存在
                            {
                                if (Maticsoft.DBUtility.DbHelperSQL.Exists("select count(1) from SMT_STAFF_INFO where REAL_NAME='" + staffInfo.REAL_NAME + "' and IS_DELETE=0"))
                                {
                                    FrmDetailInfo.AddOneMsg("已存在相同姓名人员（请使用其他姓名导入之后人工修改）：" + staffInfo.REAL_NAME + ",人员" + staffInfo.REAL_NAME + "跳过导入！", isRed: true);
                                    return;
                                }
                            }
                            staffInfo.ID = staffBll.Add(staffInfo);

                            string cardNos = GetNotNullString(dr["卡号"]);
                            log.Info("卡号为：" + cardNos);
                            if (!string.IsNullOrWhiteSpace(cardNos))
                            {
                                try
                                {
                                    Maticsoft.BLL.SMT_CARD_INFO cardbll = new Maticsoft.BLL.SMT_CARD_INFO();
                                    cardNos = cardNos.TrimEnd(' ', ',');
                                    string[] nos = cardNos.Split(',');
                                    string str = "";
                                    foreach (var no in nos)
                                    {
                                        str += "'" + no + "',";
                                    }
                                    var cards = cardbll.GetModelList("CARD_NO in (" + str.TrimEnd(',') + ")");
                                    
                                    foreach (var no in nos)
                                    {
                                        log.InfoFormat("导入卡号：{0}", no);
                                        if (!cards.Exists(m=>m.CARD_NO==no))
                                        {
                                            log.InfoFormat("导入卡号1：{0}", no);
                                            Maticsoft.Model.SMT_CARD_INFO cardInfo = new Maticsoft.Model.SMT_CARD_INFO();
                                            cardInfo.CARD_NO = no;
                                            cardInfo.CARD_TYPE = 0;
                                            cardInfo.CARD_DESC = no;
                                            var config = SysConfig.GetCardIssueConfig();
                                            cardInfo.CARD_WG_NO = cardInfo.CARD_NO;
                                            if (config.cardIssueModel == CardIssueModel.HY_EM800A)
                                            {
                                                cardInfo.CARD_WG_NO = DataHelper.ToWGAccessCardNo(no);
                                            }
                                            cardInfo.ID = cardbll.Add(cardInfo);
                                            cards.Add(cardInfo);
                                        }
                                    }
                                    foreach (var card in cards)
                                    {
                                        Maticsoft.Model.SMT_STAFF_CARD sc = new Maticsoft.Model.SMT_STAFF_CARD();
                                        sc.CARD_ID = card.ID;
                                        sc.STAFF_ID = staffInfo.ID;
                                        sc.ACCESS_STARTTIME = staffInfo.VALID_STARTTIME;
                                        sc.ACCESS_ENDTIME = staffInfo.VALID_ENDTIME;
                                        Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
                                        scBll.Add(sc);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    FrmDetailInfo.AddOneMsg(" 人员卡号导入异常：" + name + ",异常：" + ex.Message);
                                }
                               
                            }
                            count++;
                            FrmDetailInfo.AddOneMsg("成功导入人员：" + name);
                        }
                        catch (Exception ex)
                        {
                            FrmDetailInfo.AddOneMsg("导入人员：" + name + " 异常：" + ex.Message);
                        }
                    }));
                    FrmDetailInfo.AddOneMsg("导入结束！成功导入人员：" + count);
                    this.Invoke(new Action(() =>
                    {
                    	DoSearch(true);
                    }));
                });
                waiting.Show(this);
            }
        }

        private void biDownloadModel_Click(object sender, EventArgs e)
        {
            DoExport(new List<Maticsoft.Model.SMT_STAFF_INFO>(),true);
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            DoSearch(false, _byDeptTree, false, null, _orgId);
        }
        private void biUploadSelect_Click(object sender, EventArgs e)
        {
            var rows = GetSelectRows();
            if (rows.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "未选择任何人员！");
                return;
            }
            List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (var item in rows)
            {
                staffInfos.Add((Maticsoft.Model.SMT_STAFF_INFO)item.Tag);
            }

            CtrlWaiting waiting = new CtrlWaiting("正在上传权限...", () =>
            {
                try
                {
                    string errMsg = "";
                    bool ret = UploadPrivate.Upload(staffInfos, out errMsg);
                    SmtLog.InfoFormat("权限", "上传权限结果：{0},{1}", ret ? "成功" : "失败", errMsg);
                    if (errMsg == "")
                    {
                        errMsg = "成功！";
                    }
                    WinInfoHelper.ShowInfoWindow(this, "上传结束，输出结果：" + errMsg);
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "上传异常：" + ex.Message);
                    log.Error("上传权限异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void biImportPic_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string[] paths = Directory.GetFiles(folderBrowser.SelectedPath);
                    string[] ends = new string[] { ".jpg", ".png", ".jpeg", ".bmp" };
                    List<string> files = new List<string>();
                    foreach (var item in paths)
                    {
                        foreach (var end in ends)
                        {
                            if (item.EndsWith(end,StringComparison.CurrentCultureIgnoreCase))
                            {
                                files.Add(item);
                                break;
                            }
                        }
                    }
                    if (files.Count==0)
                    {
                          WinInfoHelper.ShowInfoWindow(this, "无任何照片可导入！");
                          return;
                    }

                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        FrmDetailInfo.Show(false);
                        foreach (var file in files)
                        {
                            try
                            {
                                Image image = Image.FromFile(file);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Image newImage = CommonClass.Get2InchPhoto(image);
                                    if (newImage != null)
                                    {
                                        newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        newImage.Dispose();
                                    }
                                    else
                                    {
                                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                    image.Dispose();
                                    byte[] bts = ms.GetBuffer();
                                    Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();

                                    string str = Path.GetFileName(file);
                                    int index = str.LastIndexOf('.');
                                    str = str.Substring(0, index);
                                    string realname = str;
                                    string staffno = null;
                                    index = str.IndexOf('_');
                                    if (index >= 0)
                                    {
                                        realname = str.Substring(0, index);
                                        staffno = str.Substring(index + 1);
                                    }
                                    string strWhere1 = "(REAL_NAME='" + realname + "' or REAL_NAME+STAFF_NO='" + str + "') and IS_DELETE = 0";
                                    string strWhere2 = null;
                                    if (!string.IsNullOrWhiteSpace(staffno))
                                    {
                                        strWhere2 = "STAFF_NO='" + staffno + "' and IS_DELETE = 0";
                                    }
                                    List<Maticsoft.Model.SMT_STAFF_INFO> models = null;
                                    if (strWhere2 != null)
                                    {
                                        models = staffBll.GetModelList(strWhere2);
                                        if (models.Count == 0)
                                        {
                                            models = staffBll.GetModelList(strWhere1);
                                        }
                                    }
                                    else
                                    {
                                        models = staffBll.GetModelList(strWhere1);
                                    }

                                    if (models.Count > 0)
                                    {
                                        models[0].PHOTO = bts;
                                        staffBll.Update(models[0]);
                                        FrmDetailInfo.AddOneMsg("导入人员照片为“" + str + "”成功.", isRed: false);
                                    }
                                    else
                                    {
                                        FrmDetailInfo.AddOneMsg("不存在“姓名_编号”为“" + str + "”人员！", isRed: true);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                FrmDetailInfo.AddOneMsg("导入照片" + file + "异常：" + ex.Message, isRed: true);
                                log.Error("导入照片" + file + "异常：" + ex.Message, ex);
                            }
                        }
                        FrmDetailInfo.AddOneMsg("导入照片结束！");
                        this.BeginInvoke(new Action(() =>
                            {
                                DoSearch(false, _byDeptTree, false, null, _orgId);
                            }));
                    });
                    waiting.Show(this);
                    
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnCloseImage_Click(object sender, EventArgs e)
        {
            try
            {
                panelImage.Visible = false;
                if (picImage.Image != null)
                {
                    picImage.Image.Dispose();
                    picImage.Image = null;
                }
            }
            catch (Exception)
            {
            }

        }

        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                biDoSearch_Click(null, null);
            }
        }


    }
}
