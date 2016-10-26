using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class AccessPasswordMgr : UserControl
    {
        public AccessPasswordMgr()
        {
            InitializeComponent();
        }


        #region 超级通行密码
        private bool _isCodeSetPwd = false;
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (_isCodeSetPwd)
            {
                return;
            }
            if (tbPassword.Text.Length>0)
            {
                string str = "";
                foreach (var item in tbPassword.Text)
                {
                    if (item>='0'&&item<='9')//数字输入
                    {
                        str += item;
                    }
                }
               
                if (tbPassword.Text.Length!=str.Length)
                {
                    int c = tbPassword.SelectionStart;
                    _isCodeSetPwd = true;
                    tbPassword.Text = str;
                    tbPassword.SelectionStart = c - 1;
                    _isCodeSetPwd = false;
                }
            }
        }
        #endregion

        private void cbVisiblePwd_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = cbVisiblePwd.Checked ? '\0' : '*';
        }
    }
}
