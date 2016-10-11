using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.Common.WinInfo
{
    public partial class FrmWaiting : Form
    {
        public string Tip
        {
            get {return this.lbText.Text; }
            set { this.lbText.Text = value; }
        }
        public FrmWaiting()
        {
            InitializeComponent();
        }
    }
}
