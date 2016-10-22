using NT.Net.App;
using SmartAccess.Common.Config;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using SmartAccess.DogKey;
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
                try
                {
                    Maticsoft.BLL.SMT_USER_INFO userbll = new Maticsoft.BLL.SMT_USER_INFO();
                    var users = userbll.GetModelList("USER_NAME='" + tbUserName.Text.Trim() + "' and IS_ENABLE=1 and IS_DELETE=0 and PASS_WORD= substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','" + tbPwd.Text + "')),3,32)");
                    if (users.Count > 0)
                    {
                        UserInfoHelper.UserInfo = users[0];
                        UserInfoHelper.OldPwd = tbPwd.Text;
                        PrivateMgr.LoadPrivates();
                    }
                    this.Invoke(new Action(() =>
                    {
                        if (users.Count > 0)
                        {
                            DoEnter();
                        }
                        else
                        {
                            MessageBox.Show("输入用户信息错误！");
                        }
                    }));
                }
                catch (System.Exception ex)
                {
                	this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("登陆失败：" + ex.Message);
                    }));
                }

            });
            waiting.Show(this);

        }
        //执行进入系统
        private void DoEnter()
        {
            this.Enabled = false;
            try
            {
                frmMain = new FrmMain();
                frmMain.FormClosed += frmMain_FormClosed;
                frmMain.Show();
                frmMain.BringToFront();
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("进入系统异常：" + ex.Message);
                this.Enabled = true;
            }
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Point downPosition = Point.Empty;
        //private bool moving = false;
        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left )
            {
                Point p = this.Location;
               // moving = true;
                Point m = Cursor.Position;
                this.Location = new Point(p.X + m.X - downPosition.X, p.Y + m.Y - downPosition.Y);
                //moving = false;
                downPosition = m;
            }
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                downPosition = Cursor.Position;
            }
        }

        private void CheckDog()
        {
            timerDogCheck.Stop();
            if (!DogChecker.Login())
            {
                SetDogError("未插入授权加密狗！");
                timerDogCheck.Start();
            }
            else if (!DogChecker.CheckValid())
            {
                SetDogError("加密狗已过期(或不在有效时间内)！");
                timerDogCheck.Start();
            }
            else
            {
                SetDogError("", true);
                DogChecker.StartTimeChecker();
            }
        }
        private void SetDogError(string msg,bool valid=false)
        {
            lbDogTips.Visible = !valid;
            if (!valid)
            {
                lbDogTips.Text = msg;
            }
            btnLogin.Enabled = valid;
            btnICMS.Enabled = valid;
            tbUserName.Enabled = valid;
            tbPwd.Enabled = valid;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CheckDog();
        }

        private void timerDogCheck_Tick(object sender, EventArgs e)
        {
            CheckDog();
        }
    }
}
