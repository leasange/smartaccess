using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common.Datas;
using DevComponents.AdvTree;
using System.IO;
using SmartAccess.VerInfoMgr;

namespace SmartAccess.InfoSearchMgr
{
    public partial class ImsPeopleRecordInfos : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(ImsPeopleRecordInfos));
        public ImsPeopleRecordInfos()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value>=dtpEnd.Value)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            string staffNo = tbStaffNo.Text.Trim();//证件号
            string staffName = tbName.Text.Trim();//姓名
            string strWhere = "";

            if (!string.IsNullOrWhiteSpace(staffNo))
            {
                strWhere = "where STAFF_NO like '%" + staffNo + "%' ";
            }
            if (!string.IsNullOrWhiteSpace(staffName))
            {
                if (strWhere=="")
                {
                    strWhere = " where ";
                }
                else
                {
                    strWhere += " and ";
                }
                strWhere += "REAL_NAME like '%" + staffName + "%' ";
            }

            pageDataGridView.Reset();
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }

        private string sqlAll = "";
        private void DoSearch(bool searchCount = false)
        {
            string strWhere = pageDataGridView.SqlWhere;//WHERE REAL_NAME like '%唐%' and CER_NO like '%11%'
            string strSqlBase = "SELECT ROW_NUMBER() over (order by ThroughTime desc) as RN,* FROM(SELECT RCDS2.*,SSOI.ORG_ID,SSOI.ORG_NAME,SSOI.REAL_NAME,SSOI.STAFF_NO FROM (SELECT RCDS.*,SSC.STAFF_ID FROM (select IPR.*,SCI.ID as CARD_ID from IMS_PEOPLE_RECORD IPR LEFT JOIN SMT_CARD_INFO SCI ON IPR.CardNo=SCI.CARD_NO where IPR.ThroughTime>='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and IPR.ThroughTime<'" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') RCDS LEFT JOIN SMT_STAFF_CARD SSC ON RCDS.CARD_ID=SSC.CARD_ID) RCDS2 LEFT JOIN (SELECT SSI.*,SOI.ORG_NAME FROM SMT_STAFF_INFO SSI LEFT JOIN SMT_ORG_INFO SOI ON SSI.ORG_ID=SOI.ID) SSOI ON RCDS2.STAFF_ID=SSOI.ID) T " + strWhere;
            string strSql = "SELECT TOP " + pageDataGridView.PageControl.RecordsPerPage + " * FROM(" + strSqlBase + ") A WHERE RN>=" + pageDataGridView.PageControl.StartIndex;
            sqlAll = strSqlBase;
            dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    int count = -1;
                    if (searchCount)
                    {
                        string countSql = "select count(1) from (" + strSqlBase + ") TT";
                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(countSql);
                        count = (int)ds.Tables[0].Rows[0][0];
                        if (count <= 0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "没有记录！");
                        }
                    }
                    DataTable dt = null;
                    if (count!=0)
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
            dt.Columns.Add("门禁通道");
            dt.Columns.Add("通行方向");
            dt.Columns.Add("通行时间");
            dt.Columns.Add("通行结果");
            dt.Columns.Add("抓拍照片");
            dt.Columns.Add("库内照片");
            dt.Columns.Add("比对结果");
            dt.Columns.Add("相似度");
            foreach (DataRow item in query.Rows)
            {
                DataRow dr = dt.NewRow();

                dr[0] = item["STAFF_NO"];
                dr[1] = item["REAL_NAME"];
                dr[2] = item["ORG_NAME"];
                dr[3] = item["AccessChannel"];
                dr[4] = item["ThroughForward"];
                dr[5] = item["ThroughTime"];
                dr[6] = item["ThroughResult"];
                dr[7] = item["CapturePic"];
                dr[8] = item["OriginPic"];
                dr[9] = item["CompareResult"];
                dr[10] = item["Similarity"];
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void DoShowGrid(DataTable dt)
        {
            this.dgvData.Rows.Clear();
            if (dt==null)
            {
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(
                    dgvData,
                    item["STAFF_NO"],
                    item["REAL_NAME"],
                    item["ORG_NAME"],
                    item["AccessChannel"],
                    item["ThroughForward"],
                    item["ThroughTime"],
                    item["ThroughResult"],
                    item["CapturePic"],
                    item["OriginPic"],
                    item["CompareResult"],
                    item["Similarity"]
                    );
                dgvr.Tag = item;
                this.dgvData.Rows.Add(dgvr);
            }
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false);
        }

        private void pageDataGridView_PageControl_ExportCurrent(object sender, Li.Controls.PageEventArgs args)
        {
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "查验记录_" + pageDataGridView.PageControl.CurrentPage + ".xls", "查验记录");
        }

        private void pageDataGridView_PageControl_ExportAll(object sender, Li.Controls.PageEventArgs args)
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
                             Li.Controls.Excel.ExportHelper.ExportEx(dt, "查验记录_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "查验记录");
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
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string pic = "";
                string name = dgvData.Columns[e.ColumnIndex].Name;
                if (name == "Col_CapPic" || name == "Col_OrigPic")
                {
                    object obj = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    pic = obj == null ? null : (string)obj;
                }
                if (!string.IsNullOrWhiteSpace(pic))
                {
                    try
                    {
                        if (picImage.Image != null)
                        {
                            picImage.Image.Dispose();
                            picImage.Image = null;
                        }

                        WebImageReader.ReadImageAsync(pic, (o, ee) =>
                            {
                                if (o == null)
                                {
                                    log.Error("获取图片错误：", ee);
                                    WinInfoHelper.ShowInfoWindow(this, "获取图片错误：" + ee.Message);
                                }
                                else
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        if (picImage.Image != null)
                                        {
                                            picImage.Image.Dispose();
                                            picImage.Image = null;
                                        }
                                        picImage.Image = o;
                                        panelImage.Visible = true;
                                        panelImage.BringToFront();
                                    }));
                                }
                            });

                    }
                    catch (Exception ex)
                    {
                        log.Error("初始化图片路径错误：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "获取图片错误：" + ex.Message);
                    }
                }
            }
        }
    }
}
