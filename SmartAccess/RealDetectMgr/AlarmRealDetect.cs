using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Li.Access.Core;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.RealDetectMgr
{
    public partial class AlarmRealDetect : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AlarmRealDetect));
        public static AlarmRealDetect Instace = null;
        public AlarmRealDetect()
        {
            InitializeComponent();
            Instace = this;
        }

        private void AlarmRealDetect_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            timerLoad.Stop();
            DateTime now = DateTime.Now;
            string strSql = "select top 100 percent SAI.*,SDI.DOOR_NAME from SMT_ALARM_INFO SAI left join SMT_DOOR_INFO SDI on SAI.DOOR_ID=SDI.ID where " + "ALARM_TIME >='" + now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' and ALARM_TIME <='" + now.AddHours(12).ToString("yyyy-MM-dd HH:mm:ss") + "' order by ALARM_TIME";
            strSql = "select ttt.*,SSI.REAL_NAME from (" + strSql + ") ttt left join SMT_STAFF_INFO SSI on ttt.STAFF_ID=SSI.ID";
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        DataSet qds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
                        var dt = qds.Tables[0];
                        Dictionary<decimal, DataRow> newids = new Dictionary<decimal, DataRow>();
                        foreach (DataRow item in dt.Rows)
                        {
                            newids.Add((decimal)item["ID"], item);
                        }
                        lock (dgvData)
                        {
                            List<decimal> oldids = new List<decimal>();
                            List<DataGridViewRow> rmrows = new List<DataGridViewRow>();
                            foreach (DataGridViewRow item in dgvData.Rows)
                            {
                                oldids.Add((decimal)item.Tag);
                                decimal id = (decimal)item.Tag;
                                if (!newids.ContainsKey(id))
                                {
                                    rmrows.Add(item);
                                }
                                else
                                {
                                    newids.Remove(id);
                                }
                            }
                            this.Invoke(new Action(() =>
                                {
                                    foreach (var item in rmrows)
                                    {
                                        dgvData.Rows.Remove(item);
                                    }
                                }));
                        }
                        this.BeginInvoke(new Action(() =>
                            {
                                try
                                {
                                    DoShowGrid(newids);
                                }
                                catch (Exception ex)
                                {
                                    log.Error("显示报警错误：", ex);
                                }

                            }));
                    }
                    catch (Exception ex)
                    {
                        log.Error("加载报警错误：", ex);
                    }
                    finally
                    {
                        this.Invoke(new Action(() =>
                                  {
                                      timerLoad.Start();
                                  }));
                    }
                });
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            InitData();
        }

        private void DoShowGrid(Dictionary<decimal, DataRow> dt)
        {
            if (dt == null)
            {
                return;
            }
            //this.dgvData.Rows.Clear();
            foreach (DataRow item in dt.Values)
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
                dgvr.Tag = (decimal)item["ID"];
                RecordReasonNo res = (RecordReasonNo)(byte)item["ALARM_TYPE"];
                if (res == RecordReasonNo.Fire ||
                    res == RecordReasonNo.Threat ||
                    res == RecordReasonNo.ForcedOpen ||
                    res == RecordReasonNo.EmergencyCall ||
                    res == RecordReasonNo.GuardAgainstTheft ||
                    res == RecordReasonNo.H7X24HourZone)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (res == RecordReasonNo.DeniedAccessNoPRIVILEGE ||
                    res == RecordReasonNo.DeniedAccessWrongPASSWORD ||
                    res == RecordReasonNo.DeniedAccessInvalidTimezone ||
                    res == RecordReasonNo.OpenTooLong ||
                    res == RecordReasonNo.ForcedClose)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                }
                this.dgvData.Rows.Insert(0,dgvr);
            }
            if (this.dgvData.Rows.Count>0)
            {
                this.dgvData.ClearSelection();
                this.dgvData.Rows[0].Selected = true;
            }
        }

        public void AddRealAlarm(decimal alarmId)
        {
            string strSql = "select SAI.*,SDI.DOOR_NAME from SMT_ALARM_INFO SAI left join SMT_DOOR_INFO SDI on SAI.DOOR_ID=SDI.ID where SAI.ID=" + alarmId;
            strSql = "select ttt.*,SSI.REAL_NAME from (" + strSql + ") ttt left join SMT_STAFF_INFO SSI on ttt.STAFF_ID=SSI.ID";
            DataSet qds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
            var dt = qds.Tables[0];
            Dictionary<decimal, DataRow> newids = new Dictionary<decimal, DataRow>();
          
            foreach (DataRow item in dt.Rows)
            {
                newids.Add((decimal)item["ID"], item);
            }
            if (newids.Count==0)
	            {
		             return;
	            }
            var dr = newids.Values.First();
            string str = dr["ALARM_NAME"] + ",门：" + dr["DOOR_NAME"] + ",卡号：" + dr["CARD_NO"] + ",姓名：" + dr["REAL_NAME"];
            WinInfoHelper.ShowInfoWindow(this, "发生新报警==>\r\n" + str);

            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    DoShowGrid(newids);
                }
                catch (Exception ex)
                {
                    log.Error("显示报警错误：", ex);
                }
            }));
        }
    }
}
