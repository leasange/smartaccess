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

namespace SmartAccess.InfoSearchMgr
{
    public partial class AccessInOutRecordInfos : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccessInOutRecordInfos));
        public AccessInOutRecordInfos()
        {
            InitializeComponent();
        }

        private void AccessInOutRecordInfos_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Init();
            }
        }

        private void Init()
        {
            dtpStart.Value = DateTime.Now.Date;
            CtrlWaiting waiting = new CtrlWaiting(() =>
           {
               var depts = DeptDataHelper.GetDepts(false);
               var doors = DoorDataHelper.GetDoors();
               var areas = AreaDataHelper.GetAreas();

               this.Invoke(new Action(() =>
                   {
                       var deptNodes = DeptDataHelper.ToTree(depts);
                       Node deptNone = new Node("--无--");
                       deptNodes.Insert(0, deptNone);

                       cboDeptTree.Nodes.AddRange(deptNodes.ToArray());
                       cboDeptTree.SelectedNode = deptNone;

                       foreach (Node item in cboDeptTree.Nodes)
                       {
                           item.Expand();
                       }

                       var doorNodes = DoorDataHelper.ToTree(areas, doors);

                       cboDoorTree.Nodes.AddRange(doorNodes.ToArray());

                       foreach (Node item in cboDoorTree.Nodes)
                       {
                           item.ExpandAll();
                       }
                   }));


           });
            waiting.Show(this, 300);
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
            string deptIds = "";//部门ID列表
            string doorIds = "";//门列表
            if (cboDoorTree.SelectedNode == null)
            {
                cboDoorTree.SelectedNode = cboDoorTree.Nodes[0];
            }
            if (cboDoorTree.SelectedNode != null && cboDoorTree.SelectedNode.Tag != null)
            {
                var doors = GetSelectNodes<Maticsoft.Model.SMT_DOOR_INFO>(cboDoorTree.SelectedNode);
                foreach (var item in doors)
                {
                    doorIds += item.ID + ",";
                }
                doorIds = doorIds.TrimEnd(',');
                if (doorIds == "")
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择至少一个门禁或者所有门禁！");
                    return;
                }
            }

            if (cboDeptTree.SelectedNode!=null&&cboDeptTree.SelectedNode.Tag != null)
            {
                var orgs = GetSelectNodes<Maticsoft.Model.SMT_ORG_INFO>(cboDeptTree.SelectedNode);
                foreach (var item in orgs)
                {
                    deptIds += item.ID + ",";
                }
                deptIds = deptIds.TrimEnd(',');
            }
            else if(!UserInfoHelper.IsManager)
            {
                var orgs = GetSelectNodes<Maticsoft.Model.SMT_ORG_INFO>(cboDeptTree.Nodes);
                foreach (var item in orgs)
                {
                    deptIds += item.ID + ",";
                }
                deptIds = deptIds.TrimEnd(',');
            }
            string strWhere = "";
            //ORG_ID in (35) and REAL_NAME like '%123%' and STAFF_NO like '%ee%' and DOOR_ID in (35)
            if (staffNo!="")
            {
                strWhere += "STAFF_NO like '%" + staffNo + "%'";
            }
            if (staffName!="")
            {
                if (!string.IsNullOrWhiteSpace(strWhere))
                {
                    strWhere += " and ";
                }
                strWhere += "REAL_NAME like '%" + staffName + "%'";
            }
            if (deptIds!="")
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                }
                strWhere += "ORG_ID in (" + deptIds + ")";
            }
            if (doorIds!="")
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                }
                strWhere += "DOOR_ID in (" + doorIds + ")";
            }
            if (strWhere!="")
            {
                strWhere += " and ";
            }
            strWhere += "RECORD_DATE >='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and RECORD_DATE <='" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            pageDataGridView.Reset();
            pageDataGridView.SqlWhere = strWhere;
            DoSearch(true);
        }
        private List<T> GetSelectNodes<T>(Node selected)
        {
            List<T> ts = new List<T>();
            if (selected.Tag is T)
            {
                T t = (T)selected.Tag;
                ts.Add(t);
            }
            foreach (Node item in selected.Nodes)
            {
                var chts = GetSelectNodes<T>(item);
                ts.AddRange(chts);
            }
            return ts;
        }

        private List<T> GetSelectNodes<T>(NodeCollection selecteds)
        {
            List<T> ts = new List<T>();
            foreach (Node selected in selecteds)
            {
               ts.AddRange(GetSelectNodes<T>(selected));
            }
            return ts;
        }


        private string sqlAll = "";
        private void DoSearch(bool searchCount = false)
        {
            string strSqlBase = "select DP.*,OI.ORG_NAME from (";
            strSqlBase += " select RR.*,SI.REAL_NAME,SI.STAFF_NO,SI.ORG_ID from ";
            strSqlBase += "	( ";
            strSqlBase += "	select CR.*,DI.DOOR_NAME,SSS.HAS_CAMERA from SMT_CARD_RECORDS CR left join SMT_DOOR_INFO DI on CR.DOOR_ID=DI.ID left join (SELECT distinct(DOOR_ID),1 as HAS_CAMERA FROM SMT_DOOR_CAMERA SDC WHERE SDC.ENABLE_CAP=1) SSS on SSS.DOOR_ID=CR.DOOR_ID";
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
                bool hascamera = item["HAS_CAMERA"] == null ? false : true;
                dgvr.CreateCells(
                    dgvData,
                    item["STAFF_NO"],
                    item["REAL_NAME"],
                    item["ORG_NAME"],
                    item["DOOR_NAME"],
                    enter ? "进门" : "出门",
                    item["RECORD_DATE"],
                    allow ? "正常" : "禁止",
                    item["RECORD_DESC"],
                    hascamera ? "查看" : "无"
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
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "门禁记录_" + pageDataGridView.PageControl.CurrentPage + ".xls", "门禁记录");
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
                             Li.Controls.Excel.ExportHelper.ExportEx(dt, "门禁记录_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "门禁记录");
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                if (dgvData.Columns[e.ColumnIndex].Name == "Col_ViewPic")
                {
                    DataRow row = (DataRow)dgvData.Rows[e.RowIndex].Tag;
                    bool hascamera = row["HAS_CAMERA"] == null ? false : true;
                    if (!hascamera)
                    {
                        return;
                    }
                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        try
                        {
                            string sn = Convert.ToString(row["CTRLR_SN"]);
                            decimal recordIndex = (decimal)row["RECORD_INDEX"];
                            DateTime recordDate = (DateTime)row["RECORD_DATE"];
                            Maticsoft.BLL.SMT_RECORDCAP_IMAGE capBll = new Maticsoft.BLL.SMT_RECORDCAP_IMAGE();
                            var capImages = capBll.GetModelList("CTRL_SN='" + sn + "' and RECORD_INDEX=" + recordIndex + " and RECORD_TIME='" + recordDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'");
                            if (capImages.Count==0)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "未查询到照片！");
                                return;
                            }
                            Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                            string url = "";
                            var dicModel = dicBll.GetModel("CAMERA_INFO", "IMAGE_SERVER");
                            if (dicModel != null)
                            {
                                url = dicModel.DATA_VALUE;
                            }
                            List<string> strs = new List<string>();
                            foreach (var item in capImages)
                            {
                                string str = Path.Combine(url, item.CAP_RELATIVE_URL);
                                strs.Add(str);
                            }
                            this.Invoke(new Action(() =>
                            {
                                picView.SetImages(strs.ToArray());
                                picView.Visible = true;
                            }));
                        }
                        catch (System.Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "查看失败：" + ex.Message);
                            log.Error("查看照片异常：", ex);
                        }
                    });
                    waiting.Show(this);

                }
            }
        }
    }
}
