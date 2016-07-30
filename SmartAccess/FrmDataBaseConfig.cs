using SmartAccess.Common.Config;
using SmartAccess.Common.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess
{
    public partial class FrmDataBaseConfig : DevComponents.DotNetBar.Office2007Form
    {
        public FrmDataBaseConfig()
        {
            InitializeComponent();
            cbVerType.SelectedIndex = 0;
        }

        public DatabaseConfigClass GetInputConfig()
        {
            DatabaseConfigClass config = new DatabaseConfigClass();
            config.serverName = tbServerName.Text.Trim();
            config.verType = cbVerType.SelectedIndex;
            config.user = tbUser.Text.Trim();
            config.pwd = tbPwd.Text;
            config.database = tbDatabase.Text.Trim();
            return config;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(tbServerName.Text))
            {
                MessageBox.Show("服务器名称不能为空！");
                tbServerName.Focus();
                return false;
            }
            if (cbVerType.SelectedIndex==1)
            {
                if (string.IsNullOrWhiteSpace(tbUser.Text))
                {
                    MessageBox.Show("用户名不能为空！");
                    tbUser.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(tbPwd.Text))
                {
                    MessageBox.Show("密码不能为空！");
                    tbPwd.Focus();
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(tbDatabase.Text))
            {
                MessageBox.Show("数据库名称不能为空！");
                tbDatabase.Focus();
                return false;
            }
            return true;
        }
        private void cbVerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVerType.SelectedIndex==0)
            {
                tbUser.Enabled = false;
                tbPwd.Enabled = false;
            }
            else
            {
                tbUser.Enabled = true;
                tbPwd.Enabled = true;
            }
        }

        private void FrmDataBaseConfig_Load(object sender, EventArgs e)
        {
            DatabaseConfigClass config = SysConfig.GetSqlServerServerConfig();
            if (config==null)
            {
                return;
            }
            tbServerName.Text = config.serverName;
            cbVerType.SelectedIndex = config.verType;
            tbUser.Text = config.user;
            tbPwd.Text = config.pwd;
            tbDatabase.Text = config.database;
        }

        private void btnTestDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    using (SqlConnection conn = DatabaseHelper.ConnectDatabase(GetInputConfig().ToString()))
                    {
                        lbMsg.Text = "测试连接成功！";
                    }
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "测试连接异常，" + ex.Message + "！";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (!SysConfig.SetSqlServerConfig(GetInputConfig()))
                {
                    MessageBox.Show("保存失败！");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
