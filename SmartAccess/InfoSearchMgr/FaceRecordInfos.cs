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
    public partial class FaceRecordInfos : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceRecordInfos));
        public FaceRecordInfos()
        {
            InitializeComponent();
        }

        private void FaceRecordInfos_Load(object sender, EventArgs e)
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
                Maticsoft.BLL.SMT_FACERECG_DEVICE faceBll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                var depts = DeptDataHelper.GetDepts(false);
                string strWhere = "";
                if (!UserInfoHelper.IsManager)
                {
                    strWhere = "ID IN (SELECT RF.FUN_ID FROM SMT_ROLE_FUN RF,SMT_USER_INFO UI WHERE RF.ROLE_TYPE=4 AND RF.ROLE_ID=UI.ROLE_ID AND UI.ID=" + UserInfoHelper.UserID + ")";
                }
                var facedevs = faceBll.GetModelList(strWhere);
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

                       var devNodes = FaceRecgHelper.ToFaceTree(facedevs, areas);
                       cboFaceTree.Nodes.AddRange(devNodes.ToArray());

                       foreach (Node item in cboFaceTree.Nodes)
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
            string devIds = "";//设备列表
            if (cboFaceTree.SelectedNode == null)
            {
                cboFaceTree.SelectedNode = cboFaceTree.Nodes[0];
            }
            if (cboFaceTree.SelectedNode != null && (!UserInfoHelper.IsManager||cboFaceTree.SelectedNode.Tag != null))
            {
                var devs = GetSelectNodes<Maticsoft.Model.SMT_FACERECG_DEVICE>(cboFaceTree.SelectedNode);
                foreach (var item in devs)
                {
                    devIds += item.ID + ",";
                }
                devIds = devIds.TrimEnd(',');
                if (devIds == "")
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择至少一个人脸设备或者所有人脸设备！");
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
            if (devIds!="")
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                }
                strWhere += "FACEDEV_ID in (" + devIds + ")";
            }
            if (strWhere!="")
            {
                strWhere += " and ";
            }
            strWhere += "FREC_TIME >='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and FREC_TIME <='" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
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
            string strSqlBase = "select TT.*,SFD.FACEDEV_NAME from( ";
            strSqlBase += " select T.*,SOI.ORG_NAME from( ";
            strSqlBase += "	select SFR.*,SSI.ORG_ID,SSI.STAFF_NO,SSI.REAL_NAME,SSI.STAFF_TYPE from SMT_FACE_RECORD SFR LEFT JOIN SMT_STAFF_INFO SSI ON SSI.ID=SFR.FREC_STAFF_ID)T ";
            strSqlBase += "	LEFT JOIN SMT_ORG_INFO SOI ON T.ORG_ID=SOI.ID)TT LEFT JOIN SMT_FACERECG_DEVICE SFD on TT.FACEDEV_ID=SFD.ID ";

            string strSql = "select  ROW_NUMBER() over (order by FREC_TIME desc) as RN,* from (" + strSqlBase + " ) roott where " + pageDataGridView.SqlWhere;
            strSql = "select top " + pageDataGridView.PageControl.RecordsPerPage + " * from ( " + strSql;
            strSql += ") A where RN >= " + pageDataGridView.PageControl.StartIndex + "";

            sqlAll = "select  * from (" + strSqlBase + " ) ttt where " + pageDataGridView.SqlWhere + " order by FREC_TIME desc";

            dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    int count = -1;
                    if (searchCount)
                    {
                        string countSql = "select count(1) from (" + strSqlBase + ") roott where  " + pageDataGridView.SqlWhere;
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
            dt.Columns.Add("人员类型");
            dt.Columns.Add("部门");
            dt.Columns.Add("人脸设备");
            dt.Columns.Add("通行时间");
            dt.Columns.Add("识别值");
            dt.Columns.Add("通行结果");
            foreach (DataRow item in query.Rows)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item["STAFF_NO"];
                dr[1] = item["REAL_NAME"];
                dr[2] = item["STAFF_TYPE"];
                dr[3] = item["ORG_NAME"];
                dr[4] = item["FACEDEV_NAME"];
                dr[5] = item["FREC_TIME"];
                dr[6] = item["FREC_FACE_LEVEL"];
                dr[7] = item["FREC_PARAM3"];//"正常";
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
                bool hascamera = (item["FREC_VIDEO_IMAGE"] == null || item["FREC_VIDEO_IMAGE"]==DBNull.Value) ? false : true;
                string visitor = "内部人员";
                if ( item["STAFF_TYPE"].ToString()=="VISITOR")
                {
                    visitor = "访客";
                }
                dgvr.CreateCells(
                    dgvData,
                    item["STAFF_NO"],
                    item["REAL_NAME"],
                    visitor,
                    item["ORG_NAME"],
                    item["FACEDEV_NAME"],
                    item["FREC_TIME"],
                    item["FREC_FACE_LEVEL"],
                    item["FREC_PARAM3"],//"正常"
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
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "人脸识别记录_" + pageDataGridView.PageControl.CurrentPage + ".xls", "人脸识别记录");
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
                             Li.Controls.Excel.ExportHelper.ExportEx(dt, "人脸识别记录_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "人脸识别记录");
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
                    try
                    {
                        DataRow row = (DataRow)dgvData.Rows[e.RowIndex].Tag;
                        bool hascamera = (row["FREC_VIDEO_IMAGE"] == null || row["FREC_VIDEO_IMAGE"] == DBNull.Value) ? false : true;
                        if (!hascamera)
                        {
                            return;
                        }
                        MemoryStream ms = new MemoryStream((byte[])row["FREC_VIDEO_IMAGE"]);
                        Image image = Image.FromStream(ms);
                        picView.SetImages(image);
                        picView.Visible = true;

                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "查看图片异常：" + ex.Message);
                        log.Error("查看图片异常：", ex);
                    }

                }
            }
        }
    }
}
