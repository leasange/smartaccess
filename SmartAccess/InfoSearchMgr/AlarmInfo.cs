using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Access.Core;
using DevComponents.DotNetBar;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common.Datas;
using DevComponents.AdvTree;

namespace SmartAccess.InfoSearchMgr
{
    public partial class AlarmInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AlarmInfo));
        public AlarmInfo()
        {
            InitializeComponent();
        }

        private void AlarmInfo_Load(object sender, EventArgs e)
        {
            InitAlarmTypes();
            InitDoors();
            dtpStart.Value = DateTime.Now.Date;
        }

        private void InitAlarmTypes()
        {
            var types = AlarmTypeName.GetAlarmTypes();
            ComboBoxItem cbi = new ComboBoxItem("none", "--无--");
            cbi.Tag = null;
            cboAlarmType.Items.Add(cbi);
            foreach (var item in types)
            {
                ComboBoxItem cbii = new ComboBoxItem(item.Name, item.Name);
                cbii.Tag = item;
                cboAlarmType.Items.Add(cbii);
            }
            cboAlarmType.SelectedIndex = 0;
        }
        private void InitDoors()
        {
            CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
            {
                try
                {
                    var doors = DoorDataHelper.GetDoors();
                    var areas = AreaDataHelper.GetAreas();
                    this.Invoke(new Action(() =>
                    {
                        var nodes = DoorDataHelper.ToTree(areas, doors);
                        cboDoor.Nodes.Clear();
                        cboDoor.Nodes.AddRange(nodes.ToArray());
                        cboDoor.AdvTree.ExpandAll();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "门禁列表加载异常：" + ex.Message);
                }
            });
            ctrlWaiting.Show(this, 300);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            if (cboDoor.SelectedNode!=null&&cboDoor.SelectedNode.Level>0)
            {
                doors = GetSelectNodes<Maticsoft.Model.SMT_DOOR_INFO>(cboDoor.SelectedNode);
            }
            if (dtpStart.Value >= dtpEnd.Value)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            string doorIds = "";//门列表
            foreach (var item in doors)
            {
                doorIds += item.ID + ",";
            }
            doorIds = doorIds.TrimEnd(',');
            string strWhere = "";
            if (!string.IsNullOrWhiteSpace(doorIds))
            {
                strWhere = "DOOR_ID in (" + doorIds + ") and ";
            }
            if(cboAlarmType.SelectedItem!=null)
            {
                ComboBoxItem item = (ComboBoxItem)cboAlarmType.SelectedItem;
                if (item.Tag!=null)
                {
                    AlarmTypeName typeName = (AlarmTypeName)item.Tag;
                    strWhere += " ALARM_TYPE=" + (int)typeName.Reason+ " and ";
                }
            }
            strWhere += "ALARM_TIME >='" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and ALARM_TIME <='" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
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
        private string sqlAll = "";
        private void DoSearch(bool searchCount = false)
        {
            string strSqlBase = "select SAI.*,SSI.REAL_NAME from SMT_ALARM_INFO SAI left join SMT_STAFF_INFO SSI on SAI.STAFF_ID=SSI.ID where " + pageDataGridView.SqlWhere;

            string strSql = "select  ROW_NUMBER() over (order by ttt.ALARM_TIME desc) as RN,ttt.*,SDI.DOOR_NAME from (" + strSqlBase + " ) ttt left join SMT_DOOR_INFO SDI on ttt.DOOR_ID=SDI.ID";

            strSql = "select top " + pageDataGridView.PageControl.RecordsPerPage + " * from ( " + strSql;
            strSql += ") A where RN >= " + pageDataGridView.PageControl.StartIndex + "";

            sqlAll = "select  * from (" + strSql + " ) ttt";/*ttt where " + pageDataGridView.SqlWhere + " order by RECORD_DATE desc";*/

            dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    int count = -1;
                    if (searchCount)
                    {
                        string countSql = "select count(1) from (" + strSqlBase + ") ttt";
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
                dgvr.CreateCells(
                    dgvData,
                    item["ALARM_NAME"],
                    item["ALARM_TIME"],
                    item["DOOR_NAME"],
                    item["CARD_NO"],
                    item["REAL_NAME"],
                    item["ALARM_CONTENT"]
                    );
                RecordReasonNo res = (RecordReasonNo)(byte)item["ALARM_TYPE"];
                if (res== RecordReasonNo.Fire||
                    res == RecordReasonNo.Threat||
                    res == RecordReasonNo.ForcedOpen||
                    res == RecordReasonNo.EmergencyCall||
                    res == RecordReasonNo.GuardAgainstTheft||
                    res == RecordReasonNo.H7X24HourZone)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (res== RecordReasonNo.DeniedAccessNoPRIVILEGE||
                    res == RecordReasonNo.DeniedAccessWrongPASSWORD||
                    res == RecordReasonNo.DeniedAccessInvalidTimezone||
                    res == RecordReasonNo.OpenTooLong||
                    res == RecordReasonNo.ForcedClose)
                {
                     dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                }
                this.dgvData.Rows.Add(dgvr);
            }
        }
        private DataTable ToDataTable(DataTable query)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("报警名称");
            dt.Columns.Add("报警时间");
            dt.Columns.Add("门禁");
            dt.Columns.Add("卡号");
            dt.Columns.Add("关联人姓名");
            dt.Columns.Add("内容");
            foreach (DataRow item in query.Rows)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item["ALARM_NAME"];
                dr[1] = item["ALARM_TIME"];
                dr[2] = item["DOOR_NAME"];
                dr[3] = item["CARD_NO"];
                dr[4] = item["REAL_NAME"];
                dr[5] = item["ALARM_CONTENT"];
                dt.Rows.Add(dr);
            }
            return dt;
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
                        Li.Controls.Excel.ExportHelper.ExportEx(dt, "报警记录_" + dtpStart.Value.ToString("yyyyMMdd") + dtpEnd.Value.ToString("yyyyMMdd") + ".xls", "报警记录");
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

        private void pageDataGridView_PageControl_ExportCurrent(object sender, Li.Controls.PageEventArgs args)
        {
            Li.Controls.Excel.ExportHelper.ExportEx(dgvData, "报警记录_" + pageDataGridView.PageControl.CurrentPage + ".xls", "报警记录");
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false);
        }

    }
}
