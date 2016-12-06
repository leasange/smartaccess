using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Access.Core;
using DevComponents.DotNetBar.Controls;

namespace SmartAccess.ConfigMgr
{
    public partial class AlarmConnectPort : UserControl
    {
        private Maticsoft.Model.SMT_ALARM_CONNECT _alarmConnect = null;
        private List<CheckBoxX> doorCheckBoxes = new List<CheckBoxX>();
        public Maticsoft.Model.SMT_ALARM_CONNECT AlarmConnect 
        {
            get
            {
                if (cbPortEnable.Checked)
                {
                    Maticsoft.Model.SMT_ALARM_CONNECT connect = new Maticsoft.Model.SMT_ALARM_CONNECT();
                    foreach (var item in doorCheckBoxes)
                    {
                        connect.DOOR_ID = (int)((Maticsoft.Model.SMT_DOOR_INFO)item.Tag).ID;
                    }
                    connect.ENB_CONNECT_ITEM = (int)(cbKeepState.Checked ? AlarmConnectItem.KeepState : AlarmConnectItem.FixedTime);
                    connect.ENB_FIRE_EVENT = cbFire.Checked;
                    connect.ENB_FIXED_TIME = iFixedTime.Value;
                    connect.ENB_FORCE_ACCESS_EVENT = cbForceAccess.Checked;
                    connect.ENB_FORCE_CLOSE_EVENT = cbForceClose.Checked;
                    connect.ENB_FORCE_PWD_EVENT = cbEnbForcePwd.Checked;
                    connect.ENB_INVALID_CARD_EVENT = cbInvalidCard.Checked;
                    connect.ENB_RELAY_EVENT = cbRelay.Checked;
                    connect.ENB_UNCLOSED_EVENT = cbUnClosed.Checked;

                    connect.CTRL_ID = -1;
                    connect.ID = -1;
                    connect.OUT_PORT = 0;
                    if (_alarmConnect!=null)
                    {
                        connect.CTRL_ID = _alarmConnect.CTRL_ID;
                        connect.ID = _alarmConnect.ID;
                        connect.OUT_PORT = _alarmConnect.OUT_PORT;
                    }
                    return connect;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value==null)
                {
                    cbPortEnable.Checked = false;
                    _alarmConnect = value;
                }
                else
                {
                    _alarmConnect = value;
                    cbPortEnable.Checked = true;
                    foreach (var item in doorCheckBoxes)
                    {
                        if (_alarmConnect.DOOR_ID==(int)((Maticsoft.Model.SMT_DOOR_INFO)item.Tag).ID)
                        {
                            item.Checked = true;
                            break;
                        }
                    }
                    AlarmConnectItem alarmItem= AlarmConnectItem.KeepState;
                    Enum.TryParse<AlarmConnectItem>(_alarmConnect.ENB_CONNECT_ITEM.ToString(), out alarmItem);
                    cbKeepState.Checked = alarmItem == AlarmConnectItem.KeepState;
                    cbFixedTime.Checked = alarmItem != AlarmConnectItem.KeepState;
                    cbFire.Checked = _alarmConnect.ENB_FIRE_EVENT;
                    iFixedTime.Value = _alarmConnect.ENB_FIXED_TIME;
                    cbForceAccess.Checked = _alarmConnect.ENB_FORCE_ACCESS_EVENT;
                    cbForceClose.Checked = _alarmConnect.ENB_FORCE_CLOSE_EVENT;
                    cbEnbForcePwd.Checked = _alarmConnect.ENB_FORCE_PWD_EVENT;
                    cbInvalidCard.Checked = _alarmConnect.ENB_INVALID_CARD_EVENT;
                    cbRelay.Checked = _alarmConnect.ENB_RELAY_EVENT;
                    cbUnClosed.Checked = _alarmConnect.ENB_UNCLOSED_EVENT;
                }
            }
        }

        public AlarmConnectPort()
        {
            InitializeComponent();
        }
        public void SetDoors(List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            doorCheckBoxes.Clear();
            foreach (Control item in groupPanelDoors.Controls)
            {
                item.Visible = false;
            }
            var drs = doors.OrderBy(m => m.CTRL_DOOR_INDEX).ToList();
            foreach (var item in drs)
            {
                if (item.CTRL_DOOR_INDEX==1)
                {
                    cbDoor1.Visible = true;
                    cbDoor1.Tag = item;
                    doorCheckBoxes.Add(cbDoor1);
                }
                else if (item.CTRL_DOOR_INDEX == 2)
                {
                    cbDoor2.Visible = true;
                    cbDoor2.Tag = item;
                    doorCheckBoxes.Add(cbDoor2);
                }
                else if (item.CTRL_DOOR_INDEX == 3)
                {
                    cbDoor3.Visible = true;
                    cbDoor3.Tag = item;
                    doorCheckBoxes.Add(cbDoor3);
                }
                else if (item.CTRL_DOOR_INDEX == 4)
                {
                    cbDoor4.Visible = true;
                    cbDoor4.Tag = item;
                    doorCheckBoxes.Add(cbDoor4);
                }
            }
        }

        private void cbPortEnable_CheckedChanged(object sender, EventArgs e)
        {
            plItems.Enabled = cbPortEnable.Checked;
        }
    }
}
