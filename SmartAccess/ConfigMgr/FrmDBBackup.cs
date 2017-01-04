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
    public partial class FrmDBBackup : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmDBBackup));
        public FrmDBBackup()
        {
            InitializeComponent();
        }

        private void FrmDBBackup_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("SELECT STP.command,JOB.enabled FROM msdb.dbo.sysjobs JOB WITH( NOLOCK) INNER JOIN msdb. dbo.sysjobsteps STP WITH(NOLOCK )  ON STP .job_id = JOB .job_id WHERE JOB.name='backup_smart_access'");
                    DataTable dt = ds.Tables[0];
                    bool benable = false;
                    string path = "";
                    int days = 1;
                    if (dt.Rows.Count > 0)
                    {
                        string cmd = dt.Rows[0][0].ToString();
                        byte enable = (byte)dt.Rows[0][1];
                        benable = enable == 1;
                        int idx = cmd.IndexOf("master.dbo.xp_delete_file");
                        if (idx >= 0)
                        {
                            int first = cmd.IndexOf('\'', idx);
                            int second = cmd.IndexOf('\'', first + 1);
                            path = cmd.Substring(first + 1, second - first - 1);
                        }
                        idx = cmd.IndexOf("SET @OLD_DATE");
                        if (idx >= 0)//=GETDATE()-5
                        {
                            int first = cmd.IndexOf("GETDATE()", idx) + "GETDATE()".Length;
                            if (cmd[first] == '-')
                            {
                                int end = cmd.IndexOf(' ', first + 1);
                                if (end < 0)
                                {
                                    end = cmd.IndexOf('\r', first + 1);
                                    if (end < 0)
                                    {
                                        end = cmd.IndexOf('\n', first + 1);
                                    }
                                }
                                string day = cmd.Substring(first + 1, end - first - 1).Trim('\r', '\n', ' ');
                                days = int.Parse(day);
                            }
                        }
                    }
                    this.Invoke(new Action(() =>
                     {
                         cbAutoBk.Checked = benable;
                         tbPath.Text = path;
                         iiDays.Value = days;
                     }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载自动备份配置异常！" + ex.Message);
                    log.Error("加载自动备份配置异常：", ex);
                }
            });
            waiting.Show(this);
        }
        private bool DoCheck()
        {
            if (string.IsNullOrWhiteSpace(tbPath.Text))
            {
                MessageBox.Show("备份目录不能为空！");
                tbPath.Focus();
                return false;
            }
            return true;
        }
        private bool DoSave()
        {
            string sql = FrmDataBaseConfig.GetFileSql("smartaccess_createbackupjob.sql");
            string path = this.tbPath.Text.Trim();
            path=path.TrimEnd('\\','/');
            sql = sql.Replace("${PATH}", path);
            sql = sql.Replace("${ENABLE}", cbAutoBk.Checked ? "1" : "0");
            sql = sql.Replace("${DAYS}", iiDays.Value.ToString());
            var sqls = sql.Split(new string[] { "GO\r" }, StringSplitOptions.RemoveEmptyEntries);
            bool b = false;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    foreach (var item in sqls)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(item);
                    }
                    b = true;
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存自动备份配置异常！" + ex.Message);
                    log.Error("保存自动备份配置异常：", ex);
                }
            });
            waiting.ShowDialog(this);
            return b;
        }

        private void DoExcute()
        {
            string sql = FrmDataBaseConfig.GetFileSql("smartaccess_excutebackup.sql");
            string path = this.tbPath.Text.Trim();
            path = path.TrimEnd('\\', '/');
            sql = sql.Replace("${PATH}", path);
            var sqls = sql.Split(new string[] { "GO\r" }, StringSplitOptions.RemoveEmptyEntries);
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    foreach (var item in sqls)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(item);
                    }
                    this.Invoke(new Action(() =>
                    {
                        WinInfoHelper.ShowInfoWindow(this, "立即备份成功！");
                    }));
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.ErrorCode==-2146232060)//
                    {
                        WinInfoHelper.ShowInfoWindow(this, "备份异常,请启动Sql Server服务器中服务“SQL Server 代理 (MSSQLSERVER)”！");
                    }
                    else
                    {
                        WinInfoHelper.ShowInfoWindow(this, "立即备份异常！" + ex.Message);
                    }
                    log.Error("立即备份异常：", ex);
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "立即备份异常！" + ex.Message);
                    log.Error("立即备份异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (DoCheck())
            {
                if(DoSave())
                {
                    this.Close();
                }
            }
        }

        private void btnStartBk_Click(object sender, EventArgs e)
        {
            if (DoCheck())
            {
                if (DoSave())
                {
                    DoExcute();
                }
            }
        }
    }
}
