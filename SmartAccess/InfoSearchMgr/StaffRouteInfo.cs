using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.InfoSearchMgr
{
    public partial class StaffRouteInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccessInOutRecordInfos));
        public StaffRouteInfo()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value >= dtpEnd.Value)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            string staffNo = tbStaffNo.Text.Trim();//证件号
            string staffName = tbName.Text.Trim();//姓名
            string strWhere = "";

            //ORG_ID in (35) and REAL_NAME like '%123%' and STAFF_NO like '%ee%' and DOOR_ID in (35)
            if (staffNo != "")
            {
                strWhere += "STAFF_NO like '%" + staffNo + "%'";
            }
            if (staffName != "")
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                }
                strWhere += "REAL_NAME like '%" + staffName + "%'";
            }
           
            if (strWhere != "")
            {
                strWhere += " and ";
            }
            strWhere += "RECORD_DATE >='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and RECORD_DATE <='" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            pageDataGridView.Reset();
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }

        private string sqlAll = "";
        private void DoSearch(bool searchCount = false)
        {
            string strSqlBase = "select DP.*,OI.ORG_NAME from (";
            strSqlBase += " select RR.*,SI.REAL_NAME,SI.STAFF_NO,SI.ORG_ID from ";
            strSqlBase += "	( ";
            strSqlBase += "	select CR.*,DI.DOOR_NAME from SMT_CARD_RECORDS CR left join SMT_DOOR_INFO DI on CR.DOOR_ID=DI.ID ";
            strSqlBase += " ) RR ";
            strSqlBase += " left join SMT_STAFF_INFO SI on RR.STAFF_ID=SI.ID ";
            strSqlBase += " ) DP left join SMT_ORG_INFO OI on DP.ORG_ID=OI.ID ";
            string strSql = "select  ROW_NUMBER() over (order by RECORD_DATE desc) as RN,* from (" + strSqlBase + " ) ttt where " + pageDataGridView.SqlWhere;
            strSql = "select top " + pageDataGridView.PageControl.RecordsPerPage + " * from ( " + strSql;
            strSql += ") A where RN >= " + pageDataGridView.PageControl.StartIndex + "";

            sqlAll = "select  * from (" + strSqlBase + " ) ttt where " + pageDataGridView.SqlWhere + " order by RECORD_DATE desc";

            dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    int count = -1;
                    if (searchCount)
                    {
                        string countSql = "select count(1) from (" + strSqlBase + ") ttt where  " + pageDataGridView.SqlWhere;
                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(countSql);
                        count = (int)ds.Tables[0].Rows[0][0];
                        if (count <= 0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "没有记录！");
                        }
                    }
                    DataTable dt = null;
                    if (count != 0)
                    {
                        DataSet qds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
                        dt = qds.Tables[0];
                    }

                    this.Invoke(new Action(() =>
                    {
                        if (searchCount)
                        {
                            pageDataGridView.PageControl.TotalRecords = count;
                        }

                        DoShowGrid(dt);
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

        private DataTable ToDataTable(DataTable query)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("证件号");
            dt.Columns.Add("人员姓名");
            dt.Columns.Add("部门");
            dt.Columns.Add("门禁");
            dt.Columns.Add("进入/出来");
            dt.Columns.Add("时间");
            dt.Columns.Add("通行结果");
            dt.Columns.Add("通行描述");
            foreach (DataRow item in query.Rows)
            {
                bool enter = item["IS_ENTER"] == null ? true : (bool)item["IS_ENTER"];
                bool allow = item["IS_ALLOW"] == null ? true : (bool)item["IS_ALLOW"];
                DataRow dr = dt.NewRow();
                dr[0] = item["STAFF_NO"];
                dr[1] = item["REAL_NAME"];
                dr[2] = item["ORG_NAME"];
                dr[3] = item["DOOR_NAME"];
                dr[4] = enter ? "进门" : "出门";
                dr[5] = item["RECORD_DATE"];
                dr[6] = allow ? "正常" : "禁止";
                dr[7] = item["RECORD_DESC"];
                dt.Rows.Add(dr);
            }
            return dt;
        }


        private void DoShowGrid(DataTable dt)
        {
            this.dgvData.Rows.Clear();
            if (dt == null)
            {
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                bool enter = item["IS_ENTER"] == null ? true : (bool)item["IS_ENTER"];
                bool allow = item["IS_ALLOW"] == null ? true : (bool)item["IS_ALLOW"];

                dgvr.CreateCells(
                    dgvData,
                    item["STAFF_NO"],
                    item["REAL_NAME"],
                    item["ORG_NAME"],
                    item["DOOR_NAME"],
                    enter ? "进门" : "出门",
                    item["RECORD_DATE"],
                    allow ? "正常" : "禁止",
                    item["RECORD_DESC"]
                    );
                this.dgvData.Rows.Add(dgvr);
            }
        }

        private void pageDataGridView1_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false);
        }

        private void pageDataGridView1_PageControl_ExportCurrent(object sender, Li.Controls.PageEventArgs args)
        {
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "人员轨迹_" + pageDataGridView.PageControl.CurrentPage + ".xls", "人员轨迹");
        }

        private void pageDataGridView1_PageControl_ExportAll(object sender, Li.Controls.PageEventArgs args)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    DataSet qds = Maticsoft.DBUtility.DbHelperSQL.Query(sqlAll);
                    DataTable dt = qds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "没有记录导出！");
                        return;
                    }
                    dt = ToDataTable(dt);
                    this.Invoke(new Action(() =>
                    {
                        Li.Controls.Excel.ExportHelper.ExportEx(dt, "人员轨迹_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "人员轨迹");
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

        private void StaffRouteInfo_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddDays(-1);
            dtpEnd.Value = DateTime.Now;
        }

    }
}
