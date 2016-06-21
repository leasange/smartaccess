using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SmartAccess
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //             Timer t = new Timer();
            //             t.Interval = 1000;
            //             t.Tick +=
            //                 delegate(object o, EventArgs ee)
            //                 {
            //                     t.Stop();
            //                     this.BringToFront();
            //                     t.Dispose();
            //                 };
            //             t.Start();
            ExpandablePanel fexpanel = splitContainer.Panel1.Controls[splitContainer.Panel1.Controls.Count-1] as ExpandablePanel;
           // fexpanel.Height = splitContainer.Panel1.Height - fexpanel.TitleHeight * (splitContainer.Panel1.Controls.Count - 1);
            foreach (Control item in splitContainer.Panel1.Controls)
            {
                ExpandablePanel expanel = item as ExpandablePanel;
                if (expanel != null)
                {
                    expanel.ExpandedChanging += expanel_ExpandedChanging;
                    expanel.ExpandedChanged += expanel_ExpandedChanged;
                }
            }
            fexpanel.Expanded = false;
            fexpanel.Expanded = true;
        }

        void expanel_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!e.NewExpandedValue)
            {
                return;
            }
            foreach (Control item in splitContainer.Panel1.Controls)
            {
                ExpandablePanel expanel = item as ExpandablePanel;
                if (expanel != null)
                {
                    if (expanel != sender)
                    {
                        expanel.Controls[0].Visible = false;
                        expanel.Expanded = false;
                    }
                }
            }
        }

        private void expanel_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (!e.NewExpandedValue)
            {
                return;
            }
            ExpandablePanel expanel = (ExpandablePanel)sender;
            expanel.Height = splitContainer.Panel1.Height - expanel.TitleHeight * (splitContainer.Panel1.Controls.Count - 1);
            expanel.Controls[0].Visible = true;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (CheckDoExitSystem())
            {
                DoExitSystem();
            }
        }
        private bool CheckDoExitSystem()
        {
            return DevComponents.DotNetBar.TaskDialog.Show("退出系统", eTaskDialogIcon.Help, "退出", "确定退出系统？", eTaskDialogButton.Ok | eTaskDialogButton.Cancel) == eTaskDialogResult.Ok;
        }
        //退出系统
        private void DoExitSystem()
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = !CheckDoExitSystem();
            }
        }
    }
}
