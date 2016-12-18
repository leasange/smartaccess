using SmartAccess.Common;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmModifyUserPwd :DevComponents.DotNetBar.Office2007Form
    {
        public FrmModifyUserPwd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbOldPwd.Text != UserInfoHelper.OldPwd)
            {
                MessageBox.Show("原始密码输入错误！");
                tbOldPwd.Focus();
                return;
            }
            if (tbNewPwd.Text == "")
            {
                MessageBox.Show("新密码不能为空！");
                tbNewPwd.Focus();
                return;
            }
            if (tbNewPwd.Text != tbRePwd.Text)
            {
                MessageBox.Show("两次输入密码不相同！");
                tbRePwd.Focus();
                return;
            }
            //"USER_NAME='" + tbUserName.Text.Trim() + "' and IS_ENABLE=1 and IS_DELETE=0 and PASS_WORD= substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','" + tbPwd.Text + "')),3,32)"
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update SMT_USER_INFO set PASS_WORD=substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','" + tbNewPwd.Text + "')),3,32) where ID='"+UserInfoHelper.UserID+"'");
                    SmtLog.InfoFormat("用户", "修改密码,用户名：{0}", UserInfoHelper.UserInfo.USER_NAME);
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "修改用户密码失败：" + ex.Message);
                }
            });
            waiting.Show(this);
        }
    }
}
