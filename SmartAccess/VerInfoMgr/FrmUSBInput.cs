using Li.Access.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmUSBInput : DevComponents.DotNetBar.Office2007Form
    {
        private string cardNo = "";
        public string CardNo
        {
            get { return cardNo; }
        }
        public FrmUSBInput()
        {
            InitializeComponent();
        }

        private void FrmUSBInput_KeyDown(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyValue == '\r')
            {
                if (cardNo=="")
                {
                    this.Close();
                    return;
                }
                uint no=0;
                uint.TryParse(cardNo,out no);
                byte[] bts= DataHelper.GetBytesFromInt(no);
                cardNo = DataHelper.GetHexString(bts, 0, 4,false);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            cardNo += (char)e.KeyValue;
            this.Text = cardNo;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUSBInput_Load(object sender, EventArgs e)
        {
           // Point p = Cursor.Position;
           // this.Location = new Point(p.X - this.Width / 2, p.Y - this.Height / 2);
        }
    }
}
