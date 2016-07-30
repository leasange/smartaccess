using Li.Access.Core;
using Li.Access.Core.BJTWHCardIssue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestAccessCtrler
{
    public partial class FrmCardIssue : Form
    {
        private ICardIssueDevice device = null;
        public FrmCardIssue()
        {
            InitializeComponent();
        }

        private void btnOpenOrClose_Click(object sender, EventArgs e)
        {
            if (device==null)
            {
                try
                {
                    device = new MF800ACardIssueDevice();
                    device.OpenCom((cbComPort.SelectedIndex + 1), ComBuad.CBR_14400);
                    btnOpenOrClose.Text = "关闭";
                }
                catch (Exception ex)
                {
                    device = null;
                    MessageBox.Show(ex.Message);    
                }
            }
            else
            {
                device.Close();
                device = null;
                btnOpenOrClose.Text = "打开";
            }
        }

        private void btnReadNo_Click(object sender, EventArgs e)
        {
            if (device != null)
            {
                byte[] bts = device.ReadCard();
                if (bts != null)
                {
                    string str = "";
                    foreach (var item in bts)
                    {
                        str += Convert.ToString(item, 16).ToUpper();
                    }
                    tbNo.Text = str;
                }
                else tbNo.Text = "";
            }
            else tbNo.Text = "";
        }
    }
}
