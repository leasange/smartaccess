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
    public partial class AccessPasswordMgr : UserControl
    {
        public AccessPasswordMgr()
        {
            InitializeComponent();
        }


        private void superTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (superTabControl.SelectedTab == stiSuperPwd && stiSuperPwd.Tag == null)
            {
                stiSuperPwd.Tag = "True";
                superPasswordMgr.RefreshDatas();
            }
        }
    }
}
