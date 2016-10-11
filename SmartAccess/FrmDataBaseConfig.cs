using SmartAccess.Common.Config;
using SmartAccess.Common.Database;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

            if (CheckInput())
            {
                string connStr = GetInputConfig().ToString();
                CtrlWaiting waiting = new CtrlWaiting("连接中...",() =>
                 {
                     try
                     {
                         using (SqlConnection conn = DatabaseHelper.ConnectDatabase(connStr))
                         {
                             conn.Close();
                             this.Invoke(new Action(() =>
                             {
                                 lbMsg.Text = "测试连接成功！";
                             }));
                         }
                     }
                     catch (Exception ex)
                     {
                         this.Invoke(new Action(() =>
                         {
                             lbMsg.Text = "测试连接异常，" + ex.Message + "！";
                         }));
                     }
                 });
                waiting.ShowDialog(this);
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
        
        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            DatabaseConfigClass config = GetInputConfig();
            if (CheckInput())
            {
                bool exsit = false;
                config.database = "master";
                string connStr = GetInputConfig().ToString();
                CtrlWaiting waiting = new CtrlWaiting("创建中...",() =>
                {
                    try
                    {
                        using (SqlConnection conn = DatabaseHelper.ConnectDatabase(connStr))
                        {
                            using (SqlCommand command = conn.CreateCommand())
                            {
                                command.CommandType = System.Data.CommandType.Text;
                                command.CommandText = "select count(*) From master.dbo.sysdatabases where name='SmartAccess'";//查询数据库路径
                                var single = command.ExecuteScalar();
                                int num = 0;
                                if (object.Equals(single, null) || object.Equals(single, DBNull.Value))
                                {
                                    num = 0;
                                }
                                else
                                {
                                    num = int.Parse(single.ToString());
                                }
                                if (num == 0)
                                {
                                    exsit = false;
                                }
                                exsit = true;
                            }
                        }
                        exsit = true;
                    }
                    catch (Exception ex)
                    {
                        exsit = false;
                    }
                });
                waiting.ShowDialog(this);
                if (exsit)
                {
                    if (MessageBox.Show("数据库已存在，是否重新创建？\r\n原始数据库会备份至服务器目录：C:\\SmartAccessBak 下。", "确定", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }
            //创建和备份数据库
           
            CtrlWaiting waiting1 = new CtrlWaiting("创建中...", () =>
            {
                try
                {
                    DoCreateDataBase(config);
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("创建数据库成功！");
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("创建数据库异常：" + ex.Message);
                    }));
                }

            });
            waiting1.Show(this);
        }
        private void DoCreateDataBase(DatabaseConfigClass config = null)
        {
            config.database = "master";
            string sqlstring = config.ToString();
            Stream s = this.GetType().Assembly.GetManifestResourceStream("SmartAccess.Common.Database.smartaccess.sql");
            StreamReader sr = new StreamReader(s, Encoding.UTF8);
            string createDBSql = sr.ReadToEnd();
            s.Dispose();
            using (SqlConnection conn = DatabaseHelper.ConnectDatabase(sqlstring))
            {
                string[] sqlList = createDBSql.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select filename from sysdatabases where name='master'";//查询数据库路径
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        throw new Exception("数据库创建失败，为获取数据库到路径");
                    }
                    string dbpath = reader["filename"].ToString();
                    dbpath = Path.GetDirectoryName(dbpath);
                    reader.Dispose();
                    int result;
                    foreach (string sqlItem in sqlList)
                    {
                        string sql = sqlItem.Trim('\r', '\n', ' ');
                        if (sql.Length > 2)
                        {
                            if (sql.Contains("CREATE DATABASE"))
                            {
                                sql = sql.Replace("${DBPATH}", dbpath);
                            }
                            else if (sql.Contains("BACKUP DATABASE"))
                            {
                                if (!Directory.Exists("C:\\SmartAccessBak"))
                                {
                                    Directory.CreateDirectory("C:\\SmartAccessBak");
                                }
                                sql = sql.Replace("${DATE}", DateTime.Now.ToString("_yyyyMMdd_HHmmss"));
                            }
                            command.CommandText = sql;
                            result = command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
