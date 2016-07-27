using Li.Access.Core;
using Li.Access.Core.WGAccesses;
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
    public partial class FrmModifyCtrlrIp : DevComponents.DotNetBar.Office2007Form
    {
        private Controller _ctrller = null;
        public FrmModifyCtrlrIp(Controller ctrlr)
        {
            InitializeComponent();
            _ctrller = ctrlr;
        }

        private void FrmModifyCtrlrIp_Load(object sender, EventArgs e)
        {
            tbSn.Text = _ctrller.sn;
            tbMac.Text = _ctrller.mac;
            ipAdd.Value = _ctrller.ip;
            ipMask.Value = _ctrller.mask;
            ipGateway.Value = _ctrller.gateway;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _ctrller.ip = ipAdd.Value;
            _ctrller.mask = ipMask.Value;
            _ctrller.gateway = ipGateway.Value;


            IAccessCore access = new WGAccess();
            access.SetControllerIP(_ctrller);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
