using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class MapsMgr : UserControl
    {
        public MapsMgr()
        {
            InitializeComponent();
        }

        private void biNewMap_Click(object sender, EventArgs e)
        {
            FrmEditMap editMap = new FrmEditMap();
            editMap.ShowDialog(this);
        }
    }
}
