using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common;
using Li.Controls.Excel;

namespace SmartAccess.InfoSearchMgr
{
    public partial class OprLogsInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(OprLogsInfo));
        public OprLogsInfo()
        {
            InitializeComponent();
        }

        private void OprLogsInfo_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddDays(-1);
            dtpEnd.Value = DateTime.Now;
            cboLevel.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value>=dtpEnd.Value)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间应该小于结束时间！");
                return;
            }
            string strWhere = "";
            if (tbName.Text.Trim() != "")
            {
                strWhere += "OPR_REALNAME like '%" + tbName.Text.Trim() + "%'";
            }
            if(cboLevel.SelectedIndex>0)
            {
                if (!string.IsNullOrWhiteSpace(strWhere))
	            {
		           strWhere+=" and ";
	            }
                strWhere += " LOG_LEVEL=" + (cboLevel.SelectedIndex - 1);
            }
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strWhere += " and ";
            }
            strWhere += " OPR_TIME>='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            strWhere += " and OPR_TIME<='" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            //strWhere += " order by OPR_TIME desc";
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }
        private void DoSearch(bool searchCount=false)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_LOG_INFO logBll = new Maticsoft.BLL.SMT_LOG_INFO();
                    if (searchCount)
                    {
                        int count = logBll.GetRecordCount(pageDataGridView.SqlWhere);
                        this.Invoke(new Action(() =>
                        {
                            pageDataGridView.Reset();
                            pageDataGridView.PageControl.TotalRecords = count;
                        }));
                    }
                    var ds = logBll.GetListByPage(pageDataGridView.SqlWhere, "OPR_TIME desc", pageDataGridView.PageControl.StartIndex, pageDataGridView.PageControl.EndIndex);
                    var models = logBll.DataTableToList(ds.Tables[0]);
                    this.Invoke(new Action(() =>
                    {
                        ShowModels(models);
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "查询日志异常：" + ex.Message);
                    log.Error("查询日志异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void ShowModels(List<Maticsoft.Model.SMT_LOG_INFO> models)
        {
            dgvData.Rows.Clear();
            foreach (var item in models)
            {
                string str = "信息";
                switch (item.LOG_LEVEL)
                {
                    case 0:
                        str = "调试";
                        break;
                    case 1:
                        str = "信息";
                        break;
                    case 2:
                        str = "警告";
                        break;
                    case 3:
                        str = "错误";
                        break;
                    default:
                        break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvData,
                    item.OPR_REALNAME,
                    item.OPR_TIME,
                    str,
                    item.LOG_TYPE,
                    item.OPR_CONTENT
                    );
                dgvData.Rows.Add(row);
            }
        }

        private void pageDataGridView1_PageControl_ExportCurrent(object sender, Li.Controls.PageEventArgs args)
        {
            ExportHelper.ExportEx(dgvData, "操作日志" + pageDataGridView.PageControl.CurrentPage + ".xls", "操作日志" + pageDataGridView.PageControl.CurrentPage);
        }

        private void pageDataGridView1_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false);
        }

        private void pageDataGridView1_PageControl_ExportAll(object sender, Li.Controls.PageEventArgs args)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_LOG_INFO logBll = new Maticsoft.BLL.SMT_LOG_INFO();
                    var models = logBll.GetModelList(pageDataGridView.SqlWhere + " order by OPR_TIME desc");
                    DataTable dt = new DataTable();

                    foreach (DataGridViewColumn item in dgvData.Columns)
                    {
                        dt.Columns.Add(item.HeaderText);
                    }
                    foreach (var item in models)
                    {
                        string str = "信息";
                        switch (item.LOG_LEVEL)
                        {
                            case 0:
                                str = "调试";
                                break;
                            case 1:
                                str = "信息";
                                break;
                            case 2:
                                str = "警告";
                                break;
                            case 3:
                                str = "错误";
                                break;
                            default:
                                break;
                        }
                        DataRow row = dt.NewRow();
                        row[0] = item.OPR_REALNAME;
                        row[1] = item.OPR_TIME;
                        row[2] = str;
                        row[3] = item.LOG_TYPE;
                        row[4] = item.OPR_CONTENT;
                        dt.Rows.Add(row);
                    }
                    this.Invoke(new Action(() =>
                    {
                        ExportHelper.ExportEx(dt, "操作日志" + dtpStart.Value.ToString("yyyyMMddHHmmss") + "_" + dtpEnd.Value.ToString("yyyyMMddHHmmss") + ".xls", "操作日志" + dtpStart.Value.ToString("yyyyMMddHHmmss") + "_" + dtpEnd.Value.ToString("yyyyMMddHHmmss"));
                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "导出操作日志异常：" + ex.Message);
                    log.Error("导出操作日志异常：", ex);
                }
            });
            waiting.Show(this);
        }
    }
}
