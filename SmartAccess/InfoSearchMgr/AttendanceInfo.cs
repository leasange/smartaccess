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
using Li.Controls.Excel;

namespace SmartAccess.InfoSearchMgr
{
    public partial class AttendanceInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AttendanceInfo));
        public AttendanceInfo()
        {
            InitializeComponent();
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date>dtpEnd.Value.Date)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            if (MessageBox.Show(this,"确保服务器已将所有刷卡记录提取。\r\n确定生成时间段："+dtpStart.Value.ToString("yyyy-MM-dd")+" 至 "+dtpEnd.Value.ToString("yyyy-MM-dd")+" 的考勤报表？","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }
            StartCreateReport();
        }
        class Record
        {
            public decimal StaffId;
            public DateTime RecordTime;
        }
        private void StartCreateReport()
        {
            DateTime dtStart = dtpStart.Value.Date;
            DateTime dtEnd = dtpEnd.Value.Date;

            CtrlWaiting waiting = new CtrlWaiting("正在生成...",() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ATTEN_SETTING settingBll = new Maticsoft.BLL.SMT_ATTEN_SETTING();
                    var settings = settingBll.GetModelList("DUTY_TYPE=0");//查找正常班
                    if (settings.Count==0)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "生成报表中断：无正常班设置，请设置正常班！");
                        return;
                    }

                    DateTime dt = dtStart;
                    Maticsoft.Model.SMT_ATTEN_SETTING setting = settings[0];
                    Maticsoft.BLL.SMT_ATTEN_REPORT reportBll = new Maticsoft.BLL.SMT_ATTEN_REPORT();
                    
                    while (dt<=dtEnd)
                    {
                        bool isweekend = false;
                        int weekendType = 0;
                        if(dt.DayOfWeek== DayOfWeek.Saturday)
                        {
                            isweekend = true;
                            weekendType = setting.DUTY_SAT_TYPE;
                        }
                        else if (dt.DayOfWeek==DayOfWeek.Sunday)
                        {
                            isweekend = true;
                            weekendType = setting.DUTY_SUN_TYPE;
                        }
                        if (isweekend&&weekendType==1)//全天上班
                        {
                            isweekend = false;
                        }
                        else if (isweekend&&weekendType==0)//全天休息
                        {
                            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ATTEN_REPORT where ATTEN_DATE='" + dt.ToString("yyyy-MM-dd") + "'");
                            goto End;//直接结束
                        }
                        DateTime earliest= dt.Date+setting.DUTY_ON_EARLIEST;
                        DateTime ontime1 = dt.Date + setting.DUTY_ON_TIME1;
                        DateTime offtime1 = dt.Date + setting.DUTY_OFF_TIME1;

                        string sql = string.Format("select t.RECORD_DATE,t.STAFF_ID from SMT_CARD_RECORDS t where t.RECORD_REASON='Swipe' and t.STAFF_ID>=0 and t.RECORD_DATE>='{0} 00:00:00' and t.RECORD_DATE<'{1} 00:00:00' and t.STAFF_ID in (select ssi.ID from SMT_STAFF_INFO ssi where ssi.IS_DELETE=0)", dt.ToString("yyyy-MM-dd"), dt.AddDays(1).ToString("yyyy-MM-dd"));
                        DataTable dateTable = Maticsoft.DBUtility.DbHelperSQL.Query(sql).Tables[0];

                        List<Record> records = new List<Record>();
                        foreach (DataRow item in dateTable.Rows)
                        {
                            Record record = new Record();
                            record.StaffId = (decimal)item[1];
                            record.RecordTime = (DateTime)item[0];
                            records.Add(record);
                        }
                        var g= records.GroupBy(m => m.StaffId);
                        List<decimal> staffIds = new List<decimal>();
                        foreach (var list in g)
                        {
                            List<Record> l= list.ToList();//获取一个职员当天的刷卡记录
                            staffIds.Add(l[0].StaffId);

                            Maticsoft.Model.SMT_ATTEN_REPORT report = new Maticsoft.Model.SMT_ATTEN_REPORT();
                            report.ATTEN_DATE = dt.Date;
                            report.STAFF_ID = l[0].StaffId;
                            report.ATTEN_SWIPE_TIMES = setting.DUTY_SWING_TIMES;

                            #region 上班计算
                            List<Record> onRecords = l.FindAll(m => m.RecordTime >= earliest && m.RecordTime <= ontime1.AddMinutes(setting.DUTY_LATE_MAX));
                            if (onRecords.Count==0)//上班未打卡，算旷工
                            {
                                report.ATTEN_ON_STATE = "旷工(上班)";
                                report.ATTEN_AWAY_DAY = setting.DUTY_LATE_PUNISH;
                                report.ATTEN_UNSWIPE_TIMES = 1;
                            }
                            else
                            {
                                DateTime minDate = onRecords.Min(m => m.RecordTime);
                                report.ATTEN_ON_TIME = minDate.TimeOfDay;
                                if (minDate<=ontime1.AddMinutes(setting.DUTY_LATE_MIN))//正常上班
                                {
                                    report.ATTEN_ON_STATE = "正常";
                                }
                                else/* if (minDate<=ontime1.AddMinutes(setting.DUTY_LATE_MAX))*///迟到
                                {
                                    report.ATTEN_ON_STATE = "迟到";
                                    report.ATTEN_LATE_MIN = (int)(minDate - ontime1).TotalMinutes;
                                }
                            }
                            #endregion

                            #region 下班计算
                            if (!setting.DUTY_ONLY_ON||!isweekend)
                            {
                                onRecords = l.FindAll(m => m.RecordTime >= offtime1.AddMinutes(-setting.DUTY_LEAVE_MAX));
                                if (onRecords.Count == 0)//下班未打卡，算旷工
                                {
                                    report.ATTEN_OFF_STATE = "旷工(下班)";
                                    if (report.ATTEN_AWAY_DAY == null)
                                    {
                                        report.ATTEN_AWAY_DAY = 0;
                                    }
                                    report.ATTEN_AWAY_DAY += setting.DUTY_LATE_PUNISH;
                                    if (report.ATTEN_UNSWIPE_TIMES == null)
                                    {
                                        report.ATTEN_UNSWIPE_TIMES = 0;
                                    }
                                    report.ATTEN_UNSWIPE_TIMES += 1;
                                }
                                else
                                {
                                    DateTime maxDate = onRecords.Max(m => m.RecordTime);
                                    report.ATTEN_OFF_TIME = maxDate.TimeOfDay;
                                    if (maxDate < offtime1.AddMinutes(-setting.DUTY_LEAVE_MIN))//早退
                                    {
                                        report.ATTEN_OFF_STATE = "早退";
                                        report.ATTEN_LEAVE_MIN = (int)(offtime1 - maxDate).TotalMinutes;
                                    }
                                    else if (maxDate < offtime1.AddMinutes(setting.DUTY_EXTRA_MIN))
                                    {
                                        report.ATTEN_OFF_STATE = "正常";
                                    }
                                    else
                                    {
                                        report.ATTEN_OFF_STATE = "加班";
                                        report.ATTEN_EXTRA_MIN = (int)(maxDate - offtime1).TotalMinutes;
                                    }
                                }
                            }
                            #endregion

                            var exist = reportBll.GetModelList("ATTEN_DATE='" + dt.Date.ToString("yyyy-MM-dd 00:00:00") + "' and  STAFF_ID=" + report.STAFF_ID);
                            if (exist.Count>0)
                            {
                                report.ID = exist[0].ID;
                                reportBll.Update(report);
                            }
                            else
                            {
                                reportBll.Add(report);
                            }
                        }
                        sql = "select ID from SMT_STAFF_INFO where IS_DELETE=0 ";
                        if (staffIds.Count>0)
                        {
                           sql+=" and Id not in (" + string.Join(",", staffIds.ToArray()) + ")";
                        }
                        DataTable staffTables = Maticsoft.DBUtility.DbHelperSQL.Query(sql).Tables[0];
                        foreach (DataRow sid in staffTables.Rows)
                        {
                            Maticsoft.Model.SMT_ATTEN_REPORT report = new Maticsoft.Model.SMT_ATTEN_REPORT();
                            report.ATTEN_DATE = dt.Date;
                            report.STAFF_ID = (decimal)sid[0];
                            report.ATTEN_SWIPE_TIMES = setting.DUTY_SWING_TIMES;
                            report.ATTEN_ON_STATE = "旷工";
                            if (isweekend)
                            {
                                report.ATTEN_AWAY_DAY = 0.5M;
                            }
                            else
                            {
                                report.ATTEN_AWAY_DAY = 1M;
                                report.ATTEN_OFF_STATE = "旷工";
                            }

                            report.ATTEN_UNSWIPE_TIMES = setting.DUTY_SWING_TIMES;
                            var exist = reportBll.GetModelList("ATTEN_DATE='" + dt.Date.ToString("yyyy-MM-dd 00:00:00") + "' and  STAFF_ID=" + report.STAFF_ID);
                            if (exist.Count > 0)
                            {
                                report.ID = exist[0].ID;
                                reportBll.Update(report);
                            }
                            else
                            {
                                reportBll.Add(report);
                            }
                        }

                    End:
                        dt = dt.AddDays(1);
                    }
                    WinInfoHelper.ShowInfoWindow(this, "生成报表结束！");
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "生成报表异常：" + ex.Message);
                    log.Error("生成报表异常:"+ex.Message, ex);
                }
            });
            waiting.Show(this);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            string deptIds = "";
            string staffNo = tbStaffNo.Text.Trim();//证件号
            string staffName = tbName.Text.Trim();//姓名
            string startTime = dtpStart.Value.Date.ToString("yyyy-MM-dd");
            string endTime = dtpEnd.Value.Date.ToString("yyyy-MM-dd");
            if (cboDeptTree.SelectedNode != null && cboDeptTree.SelectedNode.Tag != null)
            {
                var orgs = GetSelectNodes<Maticsoft.Model.SMT_ORG_INFO>(cboDeptTree.SelectedNode);
                foreach (var item in orgs)
                {
                    deptIds += item.ID + ",";
                }
                deptIds = deptIds.TrimEnd(',');
            }

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
               try
               {
                   Maticsoft.BLL.SMT_ATTEN_REPORT reportBll = new Maticsoft.BLL.SMT_ATTEN_REPORT();
                   var list = reportBll.GetModelListEx(staffNo, staffName, deptIds,startTime,endTime);
                   if (list.Count==0)
                   {
                       WinInfoHelper.ShowInfoWindow(this, "未查询到考勤信息，是否忘记生成报表！");
                       return;
                   }
                   this.Invoke(new Action(() =>
                   {
                       foreach (var item in list)
                       {
                           DataGridViewRow row = new DataGridViewRow();
                           row.CreateCells(dgvData,
                               item.STAFF_NO,
                               item.REAL_NAME,
                               item.ORG_NAME,
                               item.ATTEN_DATE.ToString("yyyy-MM-dd dddd"),
                               item.ATTEN_SWIPE_TIMES,
                               item.ATTEN_ON_TIME,
                               item.ATTEN_ON_STATE,
                               item.ATTEN_OFF_TIME,
                               item.ATTEN_OFF_STATE,
                               item.ATTEN_UNSWIPE_TIMES,
                               item.ATTEN_LATE_MIN,
                               item.ATTEN_LEAVE_MIN,
                               item.ATTEN_EXTRA_MIN
                               );
                           dgvData.Rows.Add(row);
                       }
                   }));
               }
               catch (System.Exception ex)
               {
                   log.Error("查询考勤信息异常：", ex);
                   WinInfoHelper.ShowInfoWindow(this, "查询异常：" + ex.Message);
               }
            });
            waiting.Show(this);
        }

        private void AttendanceInfo_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.Date.AddDays(-7);
            dtpEnd.Value = DateTime.Now.Date;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var depts = DeptDataHelper.GetDepts(false);
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
                }));
            });
            waiting.Show(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "无考勤信息导出！");
                return;
            }
            ExportHelper.ExportEx(dgvData, "考勤" + dtpStart.Value.Date.ToString("yyyyMMdd") + "_" + dtpEnd.Value.Date.ToString("yyyyMMdd") + ".xls", "考勤" + dtpStart.Value.Date.ToString("yyyyMMdd") + "_" + dtpEnd.Value.Date.ToString("yyyyMMdd"));
        }
    }
}
