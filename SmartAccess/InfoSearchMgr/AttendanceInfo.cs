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
                            goto End;//直接结束
                        }
                        DateTime earliest= dt.Date+setting.DUTY_ON_EARLIEST.TimeOfDay;
                        DateTime ontime1 = dt.Date + setting.DUTY_ON_TIME1.TimeOfDay;
                        DateTime offtime1 = dt.Date + setting.DUTY_OFF_TIME1.TimeOfDay;

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
                            if (!setting.DUTY_ONLY_ON||isweekend)
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
                    End:
                        dt = dt.AddDays(1);
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "生成报表异常：" + ex.Message);
                    log.Error("生成报表异常:"+ex.Message, ex);
                }
            });
            waiting.Show(this);
        }

    }
}
