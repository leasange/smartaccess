﻿using System;
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

namespace SmartAccess.VerInfoMgr
{
    public partial class StaffInfoMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(StaffInfoMgr));
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
                DoSearch(true, true,false,null, orgId);
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
                            strWhere += " and ORG_ID=" + orgId;
                        }
                    }
                    if (cbIsForbbiden.Checked)
                    {
                        strWhere += " and IS_FORBIDDEN=1";
                    }
                    if ((cbHasCard.Checked&&cbHasNoCard.Checked)||(!cbHasCard.Checked&&!cbHasNoCard.Checked))
                    {}
                    else if(cbHasCard.Checked)
                    {
                        strWhere += " and  SI.ID in ( select SC.STAFF_ID  from SMT_STAFF_CARD SC,SMT_CARD_INFO CI where SC.CARD_ID=CI.ID group by SC.STAFF_ID )";
                    }
                    else
                    {
                        strWhere += " and  SI.ID not in ( select SC.STAFF_ID  from SMT_STAFF_CARD SC,SMT_CARD_INFO CI where SC.CARD_ID=CI.ID group by SC.STAFF_ID )";
                    }
                    if ((cbHasDoor.Checked && cbHasNoDoor.Checked) || (!cbHasDoor.Checked && !cbHasNoDoor.Checked))
                    { }
                    else if(cbHasDoor.Checked)
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
                row.CreateCells(dgvStaffs,
                    item.STAFF_NO,
                    item.REAL_NAME,
                    item.ORG_NAME,
                    cards.TrimEnd(';'),
                    count,
                    item.IS_FORBIDDEN? "已挂失" : "正常",
                    item.VALID_STARTTIME.ToString("yyyy-MM-dd") + " 至 " + item.VALID_ENDTIME.ToString("yyyy-MM-dd"),
                    item.TELE_PHONE,
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
            DoSearch(true,true,false,null,-1,300);
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false, _byDeptTree,false,null, _orgId);
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
                            string errMsg="";
                            bool ret = UploadPrivate.Upload(staffInfo, out errMsg);
                            if (!ret||!string.IsNullOrWhiteSpace(errMsg))
                            {
                                WinInfoHelper.ShowInfoWindow(this, "权限上传异常：" + errMsg);
                                return;
                            }
                            else
                            {
                                WinInfoHelper.ShowInfoWindow(this, "权限上传成功！");
                            }
                        });
                        waiting.Show(this);
                    }
                }
            }
        }
        private DataGridViewRow GetSelectRow()
        {
            if (dgvStaffs.SelectedRows.Count>0)
            {
                if (dgvStaffs.SelectedRows.Count>1)
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
            if (dgvStaffs.SelectedCells.Count>1)
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
            DataGridViewRow row = GetSelectRow();
            if (row==null)
            {
                return;
            } 
            if (MessageBox.Show("确定注销选择人员？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            Maticsoft.Model.SMT_STAFF_INFO staffInfo = row.Tag as Maticsoft.Model.SMT_STAFF_INFO;
            CtrlWaiting ctrlwaiting = new CtrlWaiting(() =>
            {
                try
                {
                    try
                    {
                        Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
                        staffInfo.IS_DELETE = true;
                        staffInfo.DEL_TIME = DateTime.Now;
                        bll.Update(staffInfo);
                    }
                    catch (Exception ex)
                    {
                        log.Error("注销人员异常1：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "注销异常：" + ex.Message);
                        staffInfo.IS_DELETE = false;
                        return;
                    }

                    
                    string errMsg="";
                    bool ret = UploadPrivate.Upload(staffInfo, out errMsg);
                    if (!ret||!string.IsNullOrWhiteSpace(errMsg))
                    {
                        WinInfoHelper.ShowInfoWindow(this, "注销时，权限删除存在异常：" + errMsg);
                    }
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_STAFF_CARD where STAFF_ID=" + staffInfo.ID);
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_STAFF_DOOR where STAFF_ID=" + staffInfo.ID);

                    this.Invoke(new Action(() =>
                        {
                            dgvStaffs.Rows.Remove(row);
                        }));
                    WinInfoHelper.ShowInfoWindow(this, "注销成功！");
                }
                catch (Exception ex)
                {
                    log.Error("注销人员异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "注销异常：" + ex.Message);
                }

            });
            ctrlwaiting.Show(this);
        }
        //销卡
        private void biDeleteCard_Click(object sender, EventArgs e)
        {
            DoDeleteCard(false);
        }

        private void DoDeleteCard(bool resetCard=false)
        {
            DataGridViewRow row = GetSelectRow();
            if (row == null)
            {
                return;
            }
            if (MessageBox.Show("确定进行选择人员" + (resetCard ? "换卡或发卡" : "销卡") + "？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
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
                    if (resetCard)//(发卡/换卡)
                    {
                        using (ICardIssueDevice issDevice = new MF800ACardIssueDevice())
                        {
                            CardIssueConfig config = SysConfig.GetCardIssueConfig();
                            try
                            {
                                issDevice.OpenCom(config.comPort, config.comBuad);
                                string num = issDevice.ReadCardX();
                                issDevice.Close();
                                if (num == null)
                                {
                                    WinInfoHelper.ShowInfoWindow(this, "未读取到卡号！");
                                    return;
                                }
                                else
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
                                        if (delete)
                                        {
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
                                                                string str = "未发卡";
                                                                foreach (var cc in staff.CARDS)
                                                                {
                                                                    str += cc.CARD_NO + ";";
                                                                }
                                                                str = str.TrimEnd(';');
                                                                old.Cells[3].Value = str;
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
                                            }));
                                        }
                                    }
                                    else
                                    {
                                        string errMsg;
                                        bool ret = InternalDeleteCard(staffInfo, out errMsg);//销卡
                                        if (!ret)
                                        {
                                            WinInfoHelper.ShowInfoWindow(this, "原始卡片注销异常：" + errMsg);
                                            return;
                                        }
                                        Maticsoft.BLL.SMT_CARD_INFO cardBll = new Maticsoft.BLL.SMT_CARD_INFO();
                                        var cardInfos = cardBll.GetModelList("CARD_NO='" + num + "'");
                                        if (cardInfos.Count == 0)//没有此卡
                                        {
                                            Maticsoft.Model.SMT_CARD_INFO card = new Maticsoft.Model.SMT_CARD_INFO();
                                            card.CARD_NO = num;
                                            card.CARD_DESC = num;
                                            card.CARD_TYPE = 0;
                                            card.CARD_WG_NO = DataHelper.ToWGAccessCardNo(num);
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
                                            row.Cells[3].Value = cardInfo.CARD_NO;
                                        }));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("发生异常：", ex);
                                WinInfoHelper.ShowInfoWindow(this, "发生异常：" + ex.Message);
                            }
                        }
                    }
                    else//销卡
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
                            }));
                        }
                        else
                        {
                            log.Error("销卡异常：" + errMsg);
                            WinInfoHelper.ShowInfoWindow(this, "销卡异常：" + errMsg);
                        }
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
        private bool InternalDeleteCard(Maticsoft.Model.SMT_STAFF_INFO staffInfo,out string errMsg)
        {
            Maticsoft.BLL.SMT_STAFF_INFO bll = new Maticsoft.BLL.SMT_STAFF_INFO();
            staffInfo.DELETE_CARD = true;
            try
            {
                bool ret = UploadPrivate.Upload(staffInfo, out errMsg);
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
            using (ICardIssueDevice issDevice = new MF800ACardIssueDevice())
            {
                CardIssueConfig config = SysConfig.GetCardIssueConfig();
                try
                {
                    issDevice.OpenCom(config.comPort, config.comBuad);
                    string num = issDevice.ReadCardX();
                    issDevice.Close();
                    if (string.IsNullOrWhiteSpace(num))
                    {
                        WinInfoHelper.ShowInfoWindow(this, "未有读到卡！");
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
            
        }

        private void biChangeCard_Click(object sender, EventArgs e)
        {
            DoDeleteCard(true);
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
            DataGridViewRow row = GetSelectRow();
            if (row == null)
            {
                return;
            }
            Maticsoft.Model.SMT_STAFF_INFO staffInfo = row.Tag as Maticsoft.Model.SMT_STAFF_INFO;
            if (staffInfo.PHOTO==null||staffInfo.PHOTO.Length==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "该人员没有照片！");
                return;
            }
            saveImageDlg.FileName = staffInfo.REAL_NAME + "[" + staffInfo.STAFF_NO + "]";
            if (saveImageDlg.ShowDialog(this)==DialogResult.OK)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(staffInfo.PHOTO))
                    {
                        using (Image image = Image.FromStream(ms))
                        {
                            image.Save(saveImageDlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            WinInfoHelper.ShowInfoWindow(this, "保存照片成功！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存照片异常：" + ex.Message);
                    log.Error("保存照片异常：", ex);
                    return;
                }
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
                    WinInfoHelper.ShowInfoWindow(this, "复制权限异常："+ex.Message);
                    log.Error("复制权限异常:", ex);
                    return;
                }
            });
            waiting.Show(this);
        }

        private void biOneKeyUpload_Click(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting("正在上传权限...",() =>
            {
                try
                {
                    //Maticsoft.BLL.SMT_STAFF_INFO staffbll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    //var staffs = staffbll.GetModelList("");
                    string errMsg = "";
                    bool ret = UploadPrivate.UploadAllPrivate(out errMsg);
                    if (errMsg=="")
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
    }
}
