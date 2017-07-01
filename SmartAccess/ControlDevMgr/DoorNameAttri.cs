using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ControlDevMgr
{
    public partial class DoorNameAttri : UserControl
    {
        public DoorNameAttriData Data
        {
            get
            {
                DoorNameAttriData data = new DoorNameAttriData
                 {
                     doorNo = _doorNo,
                     doorName = this.tbDoorName.Text.Trim(),
                     doorEnable = cbEnable.Checked,
                     doorSecond = iiTime.Value,
                     visitor=cbIsAllowVisitor.Checked
                 };
                if (cbType1.Checked)
                {
                    data.doorCtrlType = 0;
                }
                else if (cbType2.Checked)
                {
                    data.doorCtrlType = 1;
                }
                else if (cbType3.Checked)
                {
                    data.doorCtrlType = 2;
                }
                return data;
            }
            set
            {
                this.DoorNo = value.doorNo;
                this.DoorName = value.doorName;
                this.IsDoorEnable = value.doorEnable;
                if (value.doorCtrlType == 0)
                {
                    cbType1.Checked = true;
                }
                else if (value.doorCtrlType == 1)
                {
                    cbType2.Checked = true;
                }
                else if (value.doorCtrlType == 2)
                {
                    cbType3.Checked = true;
                }
                iiTime.Value = value.doorSecond;
                cbIsAllowVisitor.Checked = value.visitor;
            }
        }

        private int _doorNo = 1;
        public int DoorNo
        {
            get
            {
                return _doorNo;
            }
            set
            {
                _doorNo = value;
                lbNo.Text = _doorNo + "号门：";
            }
        }
        public string DoorName
        {
            get
            {
                return this.tbDoorName.Text.Trim();
            }
            set
            {
                this.tbDoorName.Text = value;
            }
        }

        public bool IsDoorEnable
        {
            get
            {
                return this.cbEnable.Checked;
            }
            set
            {
                this.cbEnable.Checked = value;
            }
        }
        public DoorNameAttri()
        {
            InitializeComponent();
        }
    }
}
