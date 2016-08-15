using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
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
                ConfigHelper.SetConfigExePath(Path.Combine(Application.StartupPath, "SmartAcsService.exe"));
                tbConnStr.Text = ConfigHelper.GetConfigString("SqlServerConnectString");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库配置加载异常:"+ex.Message);
            }

        }
        private void Save()
        {
            try
            {
                if (tbConnStr.Text.Trim() == "")
                {
                    MessageBox.Show("数据库连接字符串不能为空！");
                    tbConnStr.Text = "Server=(local);Database=SmartAccess;User ID=sa;Password=123456;Trusted_Connection=False";
                    return;
                }
                bool ret = ConfigHelper.SetConfigValue("SqlServerConnectString", tbConnStr.Text.Trim());
                if (ret)
                {
                    try
                    {
                        ServiceController service = new ServiceController("SmartAcsService");
                        if (service.Status == ServiceControllerStatus.Running)
                        {
                            service.Stop();
                            service.WaitForStatus(ServiceControllerStatus.Stopped);
                        }
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("重启服务SmartAcsService异常，请手动重启，异常信息：" + ex.Message);
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
    }
}
