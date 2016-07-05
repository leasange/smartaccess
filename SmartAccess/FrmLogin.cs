using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess
{
    /// <summary>
    /// 登陆窗口
    /// </summary>
    public partial class FrmLogin : DevComponents.DotNetBar.Office2007Form
    {
        private FrmMain frmMain = null;
        public FrmLogin()
        {
            InitializeComponent();
           // styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
        }

        #region 按钮事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
        #endregion

        //执行登陆
        private void DoLogin()
        {
            DoEnter();
        }
        //执行进入系统
        private void DoEnter()
        {
            this.Enabled = false;
            frmMain = new FrmMain();
            frmMain.FormClosed += frmMain_FormClosed;
            frmMain.Show();
            frmMain.BringToFront();
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

        //主窗口关闭事件
        void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason== CloseReason.None)
            {
                this.Enabled = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnICMS_Click(object sender, EventArgs e)
        {
            FrmDataBaseConfig config = new FrmDataBaseConfig();
            config.ShowDialog(this);
        }
    }
}
