using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ControlDevMgr
{
    public partial class FrmAddOrModifyFaceDev : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_FACERECG_DEVICE _dev;
        public Maticsoft.Model.SMT_FACERECG_DEVICE Device
        {
            get { return _dev; }
            set { _dev = value; }
        }
        public FrmAddOrModifyFaceDev()
        {
            InitializeComponent();
        }

        public FrmAddOrModifyFaceDev(Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            InitializeComponent();
            this._dev = dev;
            if (this._dev != null)
            {
                this.Text = "修改人脸识别设备";
            }
            else
            {
                this.Text = "添加人脸识别设备";
            }
        }

        private void cbVideoCount1_CheckedChanged(object sender, EventArgs e)
        {
            tbRtsp2.ReadOnly = cbVideoCount1.Checked;
            tbRtsp3.ReadOnly = cbVideoCount1.Checked;
        }
    }
}
