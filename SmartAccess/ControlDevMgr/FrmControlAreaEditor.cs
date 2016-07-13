using SmartAccess.Common.Database;
using SmartAccess.Common.Datas;
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
    public partial class FrmControlAreaEditor : DevComponents.DotNetBar.Office2007Form
    {
        public FrmControlAreaEditor()
        {
            InitializeComponent();
        }

        public bool IsAdd { get; set; }

        public decimal? ParentAreaID { get; set; }

        public Maticsoft.Model.SMT_CONTROLLER_ZONE Area { get; set; }

        private void FrmControlAreaEditor_Load(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                this.Text = "添加区域";
            }
            else
            {

            }
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAreaName.Text))
	        {
                MessageBox.Show("区域名称不能为空！");
                tbAreaName.Focus();
                return;
	        }
            try
            {
                Area = new Maticsoft.Model.SMT_CONTROLLER_ZONE();
                Area.ZONE_NAME = tbAreaName.Text.Trim();
                Area.ZONE_DESC = tbAreaDesc.Text.Trim();
                Area.PAR_ID = ParentAreaID == null ? 0 : (decimal)ParentAreaID;
                Area.ORDER_VALUE = 100;
                Area.ID = AreaDataHelper.AddArea(Area);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }
    }
}
