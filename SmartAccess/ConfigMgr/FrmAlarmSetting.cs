using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmAlarmSetting : DevComponents.DotNetBar.Office2007Form
    {
        private List<AlarmConnectPort> ports = new List<AlarmConnectPort>();
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAlarmSetting));
        public FrmAlarmSetting()
        {
            InitializeComponent();
            ports.Add(alarmConnectPort1);
            ports.Add(alarmConnectPort2);
            ports.Add(alarmConnectPort3);
            ports.Add(alarmConnectPort4);
            superTabControl1.SelectedTabIndex = 0;
        }

        private void FrmAlarmSetting_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var ctrls = ControllerHelper.GetList("IS_ENABLE=1", true);
                foreach (var ctrl in ctrls)
                {
                    Maticsoft.BLL.SMT_ALARM_SETTING alarmBll = new Maticsoft.BLL.SMT_ALARM_SETTING();
                    var alarmSettings = alarmBll.GetModelList("CTRL_ID=" + ctrl.ID);
                    if (alarmSettings.Count==0)
                    {
                        Maticsoft.Model.SMT_ALARM_SETTING alarmSetting = new Maticsoft.Model.SMT_ALARM_SETTING();
                        alarmSetting.CTRL_FORCE_PWD ="889988";
                        alarmSetting.CTRL_ID = ctrl.ID;
                        alarmSetting.ENABLE_CLOSED_TIMEOUT = false;
                        alarmSetting.ENABLE_FIRE = false;
                        alarmSetting.ENABLE_FORCE_ACCESS = false;
                        alarmSetting.ENABLE_FORCE_CARD = false;
                        alarmSetting.ENABLE_FORCE_CLOSE = false;
                        alarmSetting.ENABLE_FORCE_PWD = false;
                        alarmSetting.ENABLE_INVALID_CARD = false;
                        alarmSetting.ENABLE_STEAL = false;
                        alarmSetting.ID = -1;
                        alarmSetting.NOT_CLOSED_TIMEOUT = 25;
                        alarmSetting.ID = alarmBll.Add(alarmSetting);
                        alarmSettings.Add(alarmSetting);
                    }
                    this.Invoke(new Action(() =>
                    {
                        DoShow(ctrl, alarmSettings[0]);
                    }));
                }
            });
            waiting.Show(this);
        }

        private void DoShow(Maticsoft.Model.SMT_CONTROLLER_INFO ctrl, Maticsoft.Model.SMT_ALARM_SETTING alarmSetting)
        {
            alarmSetting.CONTROLLER_INFO = ctrl;
            DataGridViewRow row = new DataGridViewRow();
            string doors = "";
            foreach (var item in ctrl.DOOR_INFOS)
            {
                doors += item.DOOR_NAME + ";";
            }
            row.CreateCells(dgvData, ctrl.NAME, ctrl.SN_NO,
                alarmSetting.ENABLE_FORCE_PWD,
                alarmSetting.ENABLE_CLOSED_TIMEOUT,
                alarmSetting.ENABLE_FORCE_ACCESS,
                alarmSetting.ENABLE_FORCE_CLOSE,
                alarmSetting.ENABLE_INVALID_CARD,
                alarmSetting.ENABLE_FIRE,
                alarmSetting.ENABLE_STEAL,
                alarmSetting.ENABLE_FORCE_CARD,
                doors);
            row.Tag = alarmSetting;
            dgvData.Rows.Add(row);
            if (dgvData.Rows.Count==1)
            {
                DoSelectRow(row);
            }
        }
        private DataGridViewRow selectRow = null;
        
        private void DoShowAlarm(Maticsoft.Model.SMT_ALARM_SETTING alarmSetting, List<Maticsoft.Model.SMT_ALARM_CONNECT> conns)
        {
            for (int i = 0; i < ports.Count; i++)
            {
                var conn = conns.Find(m => m.OUT_PORT == (i+1));
                ports[i].SetDoors(alarmSetting.CONTROLLER_INFO.DOOR_INFOS);
                ports[i].AlarmConnect = conn;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DoApply();
        }

        private void DoApply(bool upload = false,bool isclose=false)
        {
            List<Maticsoft.Model.SMT_ALARM_SETTING> settings = new List<Maticsoft.Model.SMT_ALARM_SETTING>();
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                Maticsoft.Model.SMT_ALARM_SETTING alarmSetting = (Maticsoft.Model.SMT_ALARM_SETTING)item.Tag;
                alarmSetting.CTRL_FORCE_PWD = tbForcePwd.Text.Trim();
                alarmSetting.ENABLE_FORCE_PWD = (bool)selectRow.Cells[2].Value;
                alarmSetting.ENABLE_CLOSED_TIMEOUT = (bool)selectRow.Cells[3].Value;
                alarmSetting.ENABLE_FORCE_ACCESS = (bool)selectRow.Cells[4].Value;
                alarmSetting.ENABLE_FORCE_CLOSE = (bool)selectRow.Cells[5].Value;
                alarmSetting.ENABLE_INVALID_CARD = (bool)selectRow.Cells[6].Value;
                alarmSetting.ENABLE_FIRE = (bool)selectRow.Cells[7].Value;
                alarmSetting.ENABLE_STEAL = (bool)selectRow.Cells[8].Value;
                alarmSetting.ENABLE_FORCE_CARD = (bool)selectRow.Cells[9].Value;
                if (iUnClosedTimeOut.ValueObject == null)
                {
                    alarmSetting.NOT_CLOSED_TIMEOUT = 25;
                }
                else alarmSetting.NOT_CLOSED_TIMEOUT = iUnClosedTimeOut.Value;
                settings.Add(alarmSetting);
            }
            Maticsoft.Model.SMT_ALARM_SETTING selectSetting = null;
            if (selectRow!=null)
            {
                selectSetting = (Maticsoft.Model.SMT_ALARM_SETTING)selectRow.Tag;
            }
            List<Maticsoft.Model.SMT_ALARM_CONNECT> conns = new List<Maticsoft.Model.SMT_ALARM_CONNECT>();
            if (selectSetting!=null)
            {
                for (int i = 0; i < ports.Count; i++)
                {
                    Maticsoft.Model.SMT_ALARM_CONNECT conn = ports[i].AlarmConnect;
                    if (conn != null)
                    {
                        conn.OUT_PORT = i + 1;
                        conn.CTRL_ID = selectSetting.CTRL_ID;
                        conns.Add(conn);
                    }
                }
                
            }
           

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ALARM_SETTING settingBll = new Maticsoft.BLL.SMT_ALARM_SETTING();
                    foreach (var item in settings)
                    {
                        settingBll.Update(item);
                    }
                    if (selectSetting!=null)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ALARM_CONNECT where CTRL_ID=" + selectSetting.CTRL_ID);
                        Maticsoft.BLL.SMT_ALARM_CONNECT connBll = new Maticsoft.BLL.SMT_ALARM_CONNECT();
                        foreach (var item in conns)
                        {
                            item.ID = connBll.Add(item);
                        }
                    }
                    if (upload)
                    {
                        //上传
                        UploadPrivate.UploadAlarmSetting(settings);
                    }
                    WinInfoHelper.ShowInfoWindow(this, "保存成功！");
                    if (isclose)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Close();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存报警设置异常！" + ex.Message);
                    log.Error("保存报警设置异常:", ex);
                }
            });
            waiting.Show(this);
        }
        private void DoSelectRow(DataGridViewRow row)
        {
            selectRow = row;
            Maticsoft.Model.SMT_ALARM_SETTING alarmSetting = (Maticsoft.Model.SMT_ALARM_SETTING)selectRow.Tag;
            tbForcePwd.Text = alarmSetting.CTRL_FORCE_PWD;
            iUnClosedTimeOut.ValueObject = alarmSetting.NOT_CLOSED_TIMEOUT;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ALARM_CONNECT connBll = new Maticsoft.BLL.SMT_ALARM_CONNECT();
                    List<Maticsoft.Model.SMT_ALARM_CONNECT> conns = connBll.GetModelList("CTRL_ID=" + alarmSetting.CTRL_ID);
                    this.Invoke(new Action(() =>
                    {
                        DoShowAlarm(alarmSetting, conns);
                    }));

                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "配置加载异常：" + ex.Message);
                    log.Error("报警联动配置加载异常：", ex);
                }

            });
            waiting.Show(this);
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DoSelectRow(dgvData.Rows[e.RowIndex]);
                }
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "报警联动配置加载异常：" + ex.Message);
                log.Error("报警联动配置加载异常：", ex);
            }
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoApply(false, true);
        }

        private void btnOkUploaAll_Click(object sender, EventArgs e)
        {
            DoApply(true, false);
        }
    }
}
