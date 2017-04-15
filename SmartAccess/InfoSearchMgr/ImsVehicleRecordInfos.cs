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
using Li.Camera;

namespace SmartAccess.InfoSearchMgr
{
    public partial class ImsVehichleRecordInfos : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(ImsVehichleRecordInfos));
        public ImsVehichleRecordInfos()
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
            string vehicleNo = tbVehicleNo.Text.Trim();//证件号
            string staffName = tbName.Text.Trim();//姓名
            string strWhere = "ThroughTime>='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThroughTime<='" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss")+"'";

            if (!string.IsNullOrWhiteSpace(vehicleNo))
            {
                strWhere += " and PlateNo like '%" + vehicleNo + "%' ";
            }
            if (!string.IsNullOrWhiteSpace(staffName))
            {
                strWhere += " and Name like '%" + staffName + "%' ";
            }

            pageDataGridView.Reset();
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }

        private string sqlAll = "";
        private void DoSearch(bool searchCount = false)
        {
            string strWhere = pageDataGridView.SqlWhere;//WHERE REAL_NAME like '%唐%' and CER_NO like '%11%'
            string strSqlBase = "select ROW_NUMBER() over  (order by ThroughTime desc) as RN, * from IMS_VEHICLE_RECORD vir where "  + strWhere;
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

                dr[0] = item["PlateNo"];
                dr[1] = item["Name"];
                dr[2] = item["Depart"];
                dr[3] = item["AccessChannel"];
                dr[4] = item["ThroughForward"];
                dr[5] = item["ThroughTime"];
                dr[6] = item["ThroughResult"];
                dr[7] = item["CapturePic"];
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
                    item["PlateNo"],
                    item["Name"],
                    item["Depart"],
                    item["AccessChannel"],
                    item["ThroughForward"],
                    item["ThroughTime"],
                    item["ThroughResult"],
                    item["CapturePic"]
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
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "过车记录_" + pageDataGridView.PageControl.CurrentPage + ".xls", "过车记录");
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
                             Li.Controls.Excel.ExportHelper.ExportEx(dt, "过车记录_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "查验记录");
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
                if (name == "Col_CapPic")
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
