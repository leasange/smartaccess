using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SmartServiceConfig
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Init()
        {
            try
            {
                try
                {
                    string val = ConfigurationManager.AppSettings["UseConnStr"];
                    bool ch = false;
                    bool.TryParse(val, out ch);
                    cbUseConnStr.Checked = ch;
                }
                catch (System.Exception ex)
                {

                }

                ConfigHelper.SetConfigExePath(Path.Combine(Application.StartupPath, "SmartAcCaptureService.exe"));
                string connStr = ConfigHelper.GetConfigString("SqlServerConnectString");
                tbConnStr.Text = connStr;
                if (!string.IsNullOrWhiteSpace(connStr))
                {
                    cboVer.SelectedIndex = 1;
                }
                string[] temps = connStr.Split(';');
                foreach (var item in temps)
                {
                    string[] tps = item.Split('=');
                    if (tps.Length==2)
                    {
                        string key = tps[0].Trim();
                        string val = tps[1].Trim();
                        if (string.Compare("Server",key,true)==0)
                        {
                            tbServer.Text = val;
                        }
                        else if (string.Compare("Database", key, true) == 0)
                        {
                            tbDb.Text = val;
                        }
                        else if (string.Compare("User ID", key, true) == 0)
                        {
                            tbUser.Text = val;
                        }
                        else if (string.Compare("Password", key, true) == 0)
                        {
                            tbPwd.Text = val;
                        }
                        else if (string.Compare("Integrated Security",key,true)==0)
                        {
                            if (string.Compare("True",val,true)==0||string.Compare("SSPI",val,true)==0)
                            {
                                cboVer.SelectedIndex = 0;
                            }
                            else
                            {
                                cboVer.SelectedIndex = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库配置加载异常:" + ex.Message);
            }

        }
        private void Save()
        {
            try
            {
                string connStr = "";
                if (!cbUseConnStr.Checked)
                {
                    if (tbServer.Text.Trim()=="")
                    {
                        MessageBox.Show("服务器不能为空！");
                        tbServer.Focus();
                        return;
                    }
                    if (tbDb.Text.Trim()=="")
                    {
                        MessageBox.Show("数据库不能为空！");
                        tbDb.Focus();
                        return;
                    }
                    if (cboVer.SelectedIndex==-1)
                    {
                        MessageBox.Show("请选择连接类型！");
                        cboVer.Focus();
                        return;
                    }
                    if (cboVer.SelectedIndex==1)
                    {
                        if (tbUser.Text.Trim()=="")
                        {
                            MessageBox.Show("用户名不能为空！");
                            tbUser.Focus();
                            return;
                        }
                        if (tbPwd.Text == "")
                        {
                            MessageBox.Show("密码不能为空！");
                            tbPwd.Focus();
                            return;
                        }
                    }
                    connStr = string.Format("Server={0};Database={1};", tbServer.Text.Trim(), tbDb.Text.Trim());
                    if (cboVer.SelectedIndex==0)
                    {
                        connStr += "Integrated Security=SSPI";
                    }
                    else
                    {
                        connStr += string.Format("User ID={0};Password={1};Trusted_Connection=False", tbUser.Text.Trim(), tbPwd.Text);
                    }
                }
                else
                {
                    if (tbConnStr.Text.Trim() == "")
                    {
                        MessageBox.Show("数据库连接字符串不能为空！");
                        tbConnStr.Text = "Server=(local);Database=SmartAccess;User ID=sa;Password=123456;Trusted_Connection=False";
                        return;
                    }
                    connStr = tbConnStr.Text.Trim();
                }
                try
                {
                	ConfigurationManager.AppSettings["UseConnStr"] = cbUseConnStr.Checked.ToString();
                }
                catch (System.Exception ex)
                {
                	
                }
                bool ret = ConfigHelper.SetConfigValue("SqlServerConnectString", connStr);
                if (ret)
                {
                    try
                    {
                        Process pro1 = new Process();
                        pro1.StartInfo.FileName = "net";
                        pro1.StartInfo.Arguments = "stop SmartAcCaptureService";
                        pro1.StartInfo.CreateNoWindow = true;
                        pro1.Start();
                        pro1.WaitForExit(6000);

                        Process pro2 = new Process();
                        pro2.StartInfo.FileName = "net";
                        pro2.StartInfo.Arguments = "start SmartAcCaptureService";
                        pro2.StartInfo.CreateNoWindow = true;
                        pro2.Start();
                        pro2.WaitForExit(4000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("重启服务SmartAcCaptureService异常，请手动重启，异常信息：" + ex.Message);
                        System.Diagnostics.Process.Start("services.msc");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }

        }

        private void cbUseConnStr_CheckedChanged(object sender, EventArgs e)
        {
            tbConnStr.Enabled = cbUseConnStr.Checked;
        }

        private void cboVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUser.Enabled = cboVer.SelectedIndex == 1;
            tbPwd.Enabled = cboVer.SelectedIndex == 1;
        }
    }
}
