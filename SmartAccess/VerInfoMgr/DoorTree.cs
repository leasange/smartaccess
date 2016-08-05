using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.VerInfoMgr
{
    public partial class DoorTree : UserControl
    {
        public DoorTree()
        {
            InitializeComponent();
        }

        private void DoorTree_Load(object sender, EventArgs e)
        {
            CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            });
            ctrlWaiting.Show(this, 300);
        }
    }
}
