using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ModelMgr
{
    public partial class VerModelMgr : UserControl
    {
        public VerModelMgr()
        {
            InitializeComponent();
        }

        private void biNewVerModel_Click(object sender, EventArgs e)
        {
            FrmVerModelEditor newModel = new FrmVerModelEditor();
            newModel.ShowDialog(this);
        }

        private void biModifyModel_Click(object sender, EventArgs e)
        {
            FrmVerModelEditor modifyModel = new FrmVerModelEditor();
            modifyModel.ShowDialog(this);
        }
    }
}
