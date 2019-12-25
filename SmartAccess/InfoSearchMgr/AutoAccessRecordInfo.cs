using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using Li.Access.Core;
using System.Threading;

namespace SmartAccess.InfoSearchMgr
{
    public partial class AutoAccessRecordInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AutoAccessRecordInfo));
        public AutoAccessRecordInfo()
        {
            InitializeComponent();

            btnAdd.Visible = btnCancel.Visible = PrivateMgr.FUN_POINTS.Contains(SYS_FUN_POINT.AUTOACCESS_EDIT);

            var list = AccessStateItem.GetStatesList();
            foreach (var item in list)
            {
                if (item.state == AccessState.RequestCancel)
                {
                    list.Remove(item);
                    break;
                }
            }
            cboState.DataSource = list;
            dtpStart.Value = DateTime.Now.Date.AddDays(-7);
            dtpEnd.Value = DateTime.Now.Date.AddDays(7);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value >= dtpEnd.Value)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            string strWhere = "";
            string timeStart = dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string timeEnd = dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            strWhere += "((ACC_START_TIME >='" + timeStart + "' and ACC_START_TIME <='" + timeEnd + "') ";
            strWhere += " or (ACC_END_TIME >='" + timeStart + "' and ACC_END_TIME <='" + timeEnd + "') ";
            strWhere += " or (ACC_ADD_TIME >='" + timeStart + "' and ACC_ADD_TIME <='" + timeEnd + "') ";
            strWhere += " or (ACC_STATE_TIME >='" + timeStart + "' and ACC_STATE_TIME <='" + timeEnd + "')) ";
            if (!string.IsNullOrWhiteSpace(tbAppName.Text))
            {
                strWhere += " and ACC_APP_NAME like '%" + tbAppName.Text.Trim() + "%'";
            }
            if (cboState.SelectedItem != null)
            {
                AccessStateItem asi = (AccessStateItem)cboState.SelectedItem;
                if (asi.state != AccessState.None)
                {
                    strWhere += " and ACC_STATE=" + (int)asi.state;
                }
            }

            pageDataGridView.Reset();
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }
        private void DoSearch(bool searchCount = false)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                    	dgvData.Rows.Clear();
                    }));
                    Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD bll = new Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD();
                    int count = -1;
                    if (searchCount)
                    {
                        count = bll.GetRecordCount(pageDataGridView.SqlWhere);
                        if (count <= 0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "没有记录！");
                        }
                    }
                    List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> records = null;
                    if (count != 0)
                    {
                        records = bll.GetModelListEx(pageDataGridView.SqlWhere, pageDataGridView.PageControl.StartIndex, pageDataGridView.PageControl.EndIndex);
                    }

                    this.Invoke(new Action(() =>
                    {
                        if (searchCount)
                        {
                            pageDataGridView.PageControl.TotalRecords = count;
                        }

                        DoShowGrid(records);
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("查询记录异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "查询记录异常：" + ex.Message);
                }

            });
            waiting.Show(this);
        }

        private void DoShowGrid(List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> records)
        {
            if (records == null)
            {
                return;
            }
            foreach (var item in records)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dgvData);
                string sys = item.ACC_FROM_SYS;
                AutoAccessSys.SysNames.TryGetValue(item.ACC_FROM_SYS, out sys);
                dgvr.Cells[0].Value = sys;
                dgvr.Cells[1].Value = item.ACC_APP_NAME+"["+item.ACC_APP_ID+"]";
                dgvr.Cells[2].Value = item.STAFF_REAL_NAME;
                dgvr.Cells[3].Value = item.DOOR_NAME;
                dgvr.Cells[4].Value = item.ACC_START_TIME;
                dgvr.Cells[5].Value = item.ACC_END_TIME;
                dgvr.Cells[6].Value = item.ACC_ADD_TIME;
                dgvr.Cells[7].Value = item.ACC_STATE_TIME;
                AccessStateItem asi = new AccessStateItem() { state = (AccessState)item.ACC_STATE };
                dgvr.Cells[8].Value = asi.Text;
                dgvr.Cells[8].Style.ForeColor = asi.StateColor;
                dgvr.Tag = item;
                dgvData.Rows.Add(dgvr);
            }
        }

        private void pageDataGridView_PageControl_ExportCurrent(object sender, Li.Controls.PageEventArgs args)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("无查询记录！");
                return;
            }
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "自动授权记录_" + pageDataGridView.PageControl.CurrentPage + ".xls", "自动授权记录");
        }
        private DataTable ToDataTable(List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> records)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn item in dgvData.Columns)
            {
                dt.Columns.Add(item.HeaderText);
            }

            foreach (var item in records)
            {
                DataRow dr = dt.NewRow();
                string sys = item.ACC_FROM_SYS;
                AutoAccessSys.SysNames.TryGetValue(item.ACC_FROM_SYS, out sys);
                dr[0] = sys;
                dr[1] = item.ACC_APP_NAME + "[" + item.ACC_APP_ID + "]";
                dr[2] = item.STAFF_REAL_NAME;
                dr[3] = item.DOOR_NAME;
                dr[4] = item.ACC_START_TIME;
                dr[5] = item.ACC_END_TIME;
                dr[6] = item.ACC_ADD_TIME;
                dr[7] = item.ACC_STATE_TIME;
                AccessStateItem asi = new AccessStateItem() { state = (AccessState)item.ACC_STATE };
                dr[8] = asi.Text;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void pageDataGridView_PageControl_ExportAll(object sender, Li.Controls.PageEventArgs args)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("无查询记录！");
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> records = null;
                    Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD bll = new Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD();
                    records = bll.GetModelListEx(pageDataGridView.SqlWhere, -1, -1);
                    if (records.Count == 0)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "没有记录导出！");
                        return;
                    }
                    var dt = ToDataTable(records);
                    this.Invoke(new Action(() =>
                    {
                        Li.Controls.Excel.ExportHelper.ExportEx(dt, "自动授权记录_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "自动授权记录");
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("导出记录异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "导出记录异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAutoAccessAdd frmAdd = new FrmAutoAccessAdd();
            if (frmAdd.ShowDialog(this) == DialogResult.OK)
            {
                DoSearch(true);
                WinInfoHelper.ShowInfoWindow(this, "记录添加成功，如未有查询到结果，请稍等一下，手动刷新！");
            }
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var rows = dgvData.SelectedRows;

                foreach (DataGridViewRow row in rows)
                {
                    Maticsoft.Model.SMT_AUTO_ACCESS_RECORD record = row.Tag as Maticsoft.Model.SMT_AUTO_ACCESS_RECORD;
                    if (record != null)
                    {/*
                      Init = 0, //初始未授权状态
        Private = 1,//已授权
        PrivateError = 2,//授权失败
        Canceled = 3,//已取消授权
        PrivateExpire = 4,//授权结束/已过期
        RequestCancel = 9,//申请取消授权*/
                        if (record.ACC_STATE == (int)AccessState.Init ||
                            record.ACC_STATE == (int)AccessState.Private)
                        {
                            btnCancel.Enabled = true;
                        }
                        else
                        {
                            btnCancel.Enabled = false;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var rows = dgvData.SelectedRows;
            Maticsoft.BLL.SMT_AUTO_ACCESS accBll = new Maticsoft.BLL.SMT_AUTO_ACCESS();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                foreach (DataGridViewRow row in rows)
                {
                    Maticsoft.Model.SMT_AUTO_ACCESS_RECORD record = row.Tag as Maticsoft.Model.SMT_AUTO_ACCESS_RECORD;
                    if (record != null)
                    {
                        if (record.ACC_STATE == (int)AccessState.Init ||
                            record.ACC_STATE == (int)AccessState.Private)
                        {
                            var state = record.ACC_STATE;
                            Maticsoft.Model.SMT_AUTO_ACCESS accModel = new Maticsoft.Model.SMT_AUTO_ACCESS();
                            accModel.ACC_ADD_TIME = DateTime.Now;
                            accModel.ACC_APP_ID = record.ACC_APP_ID;
                            accModel.ACC_APP_NAME = record.ACC_APP_NAME;
                            accModel.ACC_DOOR_ID = record.ACC_DOOR_ID;
                            accModel.ACC_END_TIME = record.ACC_END_TIME;
                            accModel.ACC_FROM_SYS = record.ACC_FROM_SYS;
                            accModel.ACC_STAFF_ID = record.ACC_STAFF_ID;
                            accModel.ACC_START_TIME = record.ACC_START_TIME;
                            accModel.ACC_STATE = (int)AccessState.RequestCancel;
                            accModel.ACC_STATE_TIME = DateTime.Now;
                            try
                            {
                                accBll.Add(accModel);
                                this.Invoke(new Action(() =>
                                {
                                    row.Cells[8].Value = "取消中...";
                                }));
                            }
                            catch (Exception ex)
                            {
                                log.Error("操作异常", ex);
                                record.ACC_STATE = state;
                                WinInfoHelper.ShowInfoWindow(this, "操作异常：" + ex.Message);
                                return;
                            }
                        }
                    }

                }
                Thread.Sleep(2000);
                DoSearch(false);
                WinInfoHelper.ShowInfoWindow(this, "请求取消成功，如未有查询到结果，请稍等一下，手动刷新！");
            });
            waiting.Show(this);
        }
    }
}
