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
        public FrmAlarmSetting()
        {
            InitializeComponent();
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
        }
    }
}
