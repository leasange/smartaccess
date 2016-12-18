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
    public partial class DoorReaderAttri : UserControl
    {

        private bool _isEnter1 = true;
        private bool _isNoEnter = true;
        public bool IsNoEnter
        {
            get { return _isNoEnter; }
            set
            { 
                _isNoEnter = value;
                lbNo.Text = _doorNo + "号门" + (_isNoEnter ? "进门" : "出门") + " 读卡器：";
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
                lbNo.Text = _doorNo + "号门" + (_isNoEnter ? "进门" : "出门") + " 读卡器：";
            }
        }
        public DoorReaderAttriData Data
        {
            get
            {
                return new DoorReaderAttriData()
                {
                    doorNo = _doorNo,
                    isAttend = cbIsAttend.Checked,
                    isEnter = cbIsEnter.Checked,
                    isNoEnter = _isNoEnter,
                    isEnter1=_isEnter1
                };
            }
            set 
            {
                _doorNo = value.doorNo;
                _isNoEnter=value.isNoEnter;
                lbNo.Text = _doorNo + "号门" + (_isNoEnter ? "进门" : "出门") + " 读卡器：";
                cbIsEnter.Checked = value.isEnter;
                cbIsAttend.Checked = value.isAttend;
                _isEnter1 = value.isEnter1;
            }
        }
        public DoorReaderAttri()
        {
            InitializeComponent();
        }
    }

}
