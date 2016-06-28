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
    public partial class ControlAreaMgr : UserControl
    {
        public ControlAreaMgr()
        {
            InitializeComponent();
        }

        private void biAddRootArea_Click(object sender, EventArgs e)
        {
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.ShowDialog(this);
        }
    }
}
