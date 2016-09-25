using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ModelMgr
{
    public partial class FrmInputModelName : DevComponents.DotNetBar.Office2007Form
    {
        private string _name = "";
        public string ModelName
        {
            get
            {
                return _name;
            }
        }
        public FrmInputModelName(string name)
        {
            InitializeComponent();
            this.tbName.Text = name;
            _name = name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbName.Text.Trim()))
            {
                MessageBox.Show("名称不能为空！");
                return;
            }
            this.DialogResult = DialogResult.OK;
            _name = this.tbName.Text.Trim();
            this.Close();
        }
    }
}
