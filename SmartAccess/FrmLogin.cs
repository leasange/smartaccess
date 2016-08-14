using SmartAccess.Common.Config;
using SmartAccess.Common.WinInfo;
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
            Maticsoft.DBUtility.DbHelperSQL.connectionString = SysConfig.GetSqlServerConnectString();
            if (tbUserName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！");
                tbUserName.Focus();
                return;
            }
            if (tbPwd.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                tbPwd.Focus();
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_USER_INFO userbll = new Maticsoft.BLL.SMT_USER_INFO();
                var users = userbll.GetModelList("USER_NAME='" + tbUserName.Text.Trim() + "' and IS_ENABLE=1 and IS_DELETE=0 and PASS_WORD= substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','" + tbPwd.Text + "')),3,32)");
                this.Invoke(new Action(() =>
                        {
                            if (users.Count > 0)
                            {

                                DoEnter();

                            }
                            else
                            {
                                MessageBox.Show("不存在此用户！");
                            }
                        }));
            });
            waiting.Show(this);

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
