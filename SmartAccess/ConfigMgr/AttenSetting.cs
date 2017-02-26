using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common;

namespace SmartAccess.ConfigMgr
{
    public partial class AttenSetting : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AttenSetting));
        private Maticsoft.Model.SMT_ATTEN_SETTING setting;
        public AttenSetting()
        {
            InitializeComponent();
        }

        private void AttenSetting_Load(object sender, EventArgs e)
        {
            cboLatePunish.SelectedIndex = 1;
            cboLeavePunish.SelectedIndex = 1;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ATTEN_SETTING settingBll = new Maticsoft.BLL.SMT_ATTEN_SETTING();
                    var settings = settingBll.GetModelList("DUTY_TYPE=0");//查找正常班
                    if (settings.Count == 0)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "无正常班设置！");
                        return;
                    }
                    setting = settings[0];
                    this.Invoke(new Action(() =>
                    {
                        DateTime now = DateTime.Now.Date;
                        dtiOnDuty.Value = now + setting.DUTY_ON_TIME1;
                        dtiOffDuty.Value = now + setting.DUTY_OFF_TIME1;
                        dtiEarliestTime.Value = now + setting.DUTY_ON_EARLIEST;
                        iiLateMin.Value = setting.DUTY_LATE_MIN;
                        iiLateMax.Value = setting.DUTY_LATE_MAX;
                        iiLeaveMin.Value = setting.DUTY_LEAVE_MIN;
                        iiLeaveMax.Value = setting.DUTY_LEAVE_MAX;
                        if (setting.DUTY_LATE_PUNISH == 0)
                        {
                            cboLatePunish.SelectedIndex = 0;
                        }
                        else if (setting.DUTY_LATE_PUNISH == 1)
                        {
                            cboLatePunish.SelectedIndex = 2;
                        }
                        else
                        {
                            cboLatePunish.SelectedIndex = 1;
                        }

                        if (setting.DUTY_LEAVE_PUNISH == 0)
                        {
                            cboLeavePunish.SelectedIndex = 0;
                        }
                        else if (setting.DUTY_LEAVE_PUNISH == 1)
                        {
                            cboLeavePunish.SelectedIndex = 2;
                        }
                        else
                        {
                            cboLeavePunish.SelectedIndex = 1;
                        }
                        cbOnlyOn.Checked = setting.DUTY_ONLY_ON;

                        if (setting.DUTY_SAT_TYPE == 0)
                        {
                            cbSatSetting0.Checked = true;
                        }
                        else if (setting.DUTY_SAT_TYPE == 1)
                        {
                            cbSatSetting1.Checked = true;
                        }
                        else
                        {
                            cbSatSetting2.Checked = true;
                        }

                        if (setting.DUTY_SUN_TYPE == 0)
                        {
                            cbSunSetting0.Checked = true;
                        }
                        else if (setting.DUTY_SUN_TYPE == 1)
                        {
                            cbSunSetting1.Checked = true;
                        }
                        else
                        {
                            cbSunSetting2.Checked = true;
                        }

                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "读取正常班设置异常！");
                    log.Error("读取考勤设置异常：", ex);
                }
            });
            waiting.Show(this);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (setting == null)
            {
                setting = new Maticsoft.Model.SMT_ATTEN_SETTING();
                setting.ID = -1;
                setting.DUTY_TYPE = 0;
            }
            setting.DUTY_ON_TIME1 = dtiOnDuty.Value.TimeOfDay;
            setting.DUTY_OFF_TIME1 = dtiOffDuty.Value.TimeOfDay;
            setting.DUTY_ON_EARLIEST = dtiEarliestTime.Value.TimeOfDay;
            setting.DUTY_LATE_MIN = iiLateMin.Value;
            setting.DUTY_LATE_MAX = iiLateMax.Value;
            setting.DUTY_LEAVE_MIN = iiLeaveMin.Value;
            setting.DUTY_LEAVE_MAX = iiLeaveMax.Value;
            if (cboLatePunish.SelectedIndex == 0)
            {
                setting.DUTY_LATE_PUNISH = 0;
            }
            else if (cboLatePunish.SelectedIndex == 2)
            {
                setting.DUTY_LATE_PUNISH = 1;
            }
            else
            {
                setting.DUTY_LATE_PUNISH = 0.5M;
            }

            if (cboLeavePunish.SelectedIndex == 0)
            {
                setting.DUTY_LEAVE_PUNISH = 0;
            }
            else if (cboLeavePunish.SelectedIndex == 2)
            {
                setting.DUTY_LEAVE_PUNISH = 1;
            }
            else
            {
                setting.DUTY_LEAVE_PUNISH = 0.5M;
            }

            setting.DUTY_ONLY_ON = cbOnlyOn.Checked;


            if (cbSatSetting0.Checked)
            {
                setting.DUTY_SAT_TYPE = 0;
            }
            else if (cbSatSetting1.Checked)
            {
                setting.DUTY_SAT_TYPE = 1;
            }
            else
            {
                setting.DUTY_SAT_TYPE = 2;
            }

            if (cbSunSetting0.Checked)
            {
                setting.DUTY_SUN_TYPE = 0;
            }
            else if (cbSunSetting1.Checked)
            {
                setting.DUTY_SUN_TYPE = 1;
            }
            else
            {
                setting.DUTY_SUN_TYPE = 2;
            }
            CtrlWaiting waiting = new CtrlWaiting("正在保存...", () =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ATTEN_SETTING settingBll = new Maticsoft.BLL.SMT_ATTEN_SETTING();
                    if (setting.ID == -1)
                    {
                        settingBll.Add(setting);
                        SmtLog.Info("设置", "设置考勤正常班");
                    }
                    else
                    {
                        settingBll.Update(setting);
                        SmtLog.Info("设置", "更新考勤正常班");
                    }
                    WinInfoHelper.ShowInfoWindow(this, "保存成功。");
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存设置异常！" + ex.Message);
                    log.Error("保存正常班设置异常：" + ex.Message, ex);
                }
            });
            waiting.Show(this);
        }

    }
}
