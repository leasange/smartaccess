using NT.Net.App;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using SmartKey;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.DogKey
{
    /// <summary>
    /// 加密狗检查器
    /// </summary>
    public class DogChecker
    {
        private static long handle = -1;
        private static string appid=null;
        private static long pin1 = 0, pin2 = 0, pin3 = 0, pin4 = 0;
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(DogChecker));
        private static bool hasError = true;
        static DogChecker()
        {
            try
            {
                FileStream fs = File.OpenRead(Application.StartupPath + "\\dogkey.data");
                byte[] bts=new byte[fs.Length];
                fs.Read(bts, 0, (int)fs.Length);
                fs.Close();
                fs.Dispose();
                string keyValue = "@Sxjfi890376$%^&lz!!lfdsjiQQXXif&*()+!~";
                string str = Encoding.UTF8.GetString(bts);
                str = EncryptUtils.DESDecrypt(str, keyValue.Substring(0, 8),keyValue.Substring(8,8));
                string[] temps = str.Split('\r', '\n');
                foreach (var item in temps)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        continue;
                    }
                    if (item.StartsWith("APPID="))
                    {
                        appid = item.Substring("APPID=".Length);
                    }
                    else if (item.StartsWith("PIN1="))
                    {
                        pin1 = long.Parse(item.Substring("PIN1=".Length));
                    }
                    else if (item.StartsWith("PIN2="))
                    {
                        pin2 = long.Parse(item.Substring("PIN2=".Length));
                    }
                    else if (item.StartsWith("PIN3="))
                    {
                        pin3 = long.Parse(item.Substring("PIN3=".Length));
                    }
                    else if (item.StartsWith("PIN4="))
                    {
                        pin4 = long.Parse(item.Substring("PIN4=".Length));
                    }
                }
                hasError = false;
            }
            catch (Exception ex)
            {
                hasError = true;
                log.Error("dog key file log error:", ex);
            }
        }
        public static bool Login()
        {
            try
            {
                try
                {
                    if (handle != -1)
                    {
                        NT158App.NT158Logout(handle);
                        handle = -1;
                    }
                }
                catch (Exception)
                {
                }

                long[] keyHandles;
                long keyNum = 0;
                long ret = NT158App.NT158Find(appid, out keyHandles, ref keyNum);
                if (ret != 0 || keyNum <= 0)
                {
                    log.Error("加密狗加载错误：" + ret);
                    return false;
                }
                handle = keyHandles[0];
                ret = NT158App.NT158Login(handle, pin1, pin2, pin3, pin4);
                NT158App.NT158Led(handle, 1);
                if (ret != 0)
                {
                    log.Error("加密狗登陆错误：" + ret);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("加密狗加载异常：", ex);
                return false;
            }
        }
        private static bool GetNowTime(out DateTime now)
        {
            now = DateTime.MinValue;
            try
            {
                if (UserInfoHelper.UserInfo != null)
                {
                    DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("SELECT CONVERT(varchar(100), GETDATE(), 20)");
                    now = DateTime.Parse(Convert.ToString(ds.Tables[0].Rows[0][0]));
                }
                else
                {
                    now = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                log.Error("获取当前时间异常：", ex);
                return false;
            }

            return true;
        }
        public static bool CheckValid()
        {
            if (hasError)
            {
                return false;
            }
            DateTime dtStart;
            DateTime dtEnd;
            if (GetDotTime(out dtStart, out dtEnd))
            {
                DateTime now;
                if(GetNowTime(out now))
                {
                    if (now>dtStart&&now<dtEnd)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool GetDotTime(out DateTime dtStart, out DateTime dtEnd)
        {
            dtStart = DateTime.MinValue;
            dtEnd = DateTime.MinValue;
            try
            {
                if (hasError)
                {
                    return false;
                }
                byte[] buffer = new byte[19];
                long ret = NT158App.NT158ReadFile(handle, 0, 128 + 19, buffer);
                if (ret != 0)
                {
                    log.Error("读取时间1异常：" + ret);
                    return false;
                }
                if (!DateTime.TryParse(Encoding.UTF8.GetString(buffer), out dtStart))
                {
                    log.Error("时间1异常：" + ret);
                    return false;
                }

                ret = NT158App.NT158ReadFile(handle, 0, 128 + 2 * 19, buffer);
                if (ret != 0)
                {
                    log.Error("读取时间2异常：" + ret);
                    return false;
                }
                if (!DateTime.TryParse(Encoding.UTF8.GetString(buffer), out dtEnd))
                {
                    log.Error("时间2异常：" + ret);
                    return false;
                }
                return true;
            }
            catch (System.Exception ex)
            {
                log.Error("读取时间异常：", ex);
                return false;
            }
        }
        private static System.Timers.Timer timer = new System.Timers.Timer();
        public static void StartTimeChecker()
        {
            timer.Interval = 10000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        private static bool close = false;
        private static void DoCheckAndClose()
        {
            if (Login())
            {
                if (CheckValid())
                {
                    close = false;
                    return;
                }
                else
                {
                    if (close)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        if (Application.OpenForms.Count > 0)
                        {
                            Application.OpenForms[0].Invoke(new Action(() =>
                            {
                                MessageBox.Show(Application.OpenForms[0], "授权加密狗已过期(或不在有效时间内)，请插入有效加密狗！");
                            }));
                            if (!Login() && !CheckValid())
                            {
                                WinInfoHelper.ShowInfoWindow(null, "如果未插入有效加密狗，系统将在10s后自动关闭！");
                                close = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (close)
                {
                    Application.Exit();
                }
                else
                {
                    if (Application.OpenForms.Count > 0)
                    {
                        Application.OpenForms[0].Invoke(new Action(() =>
                        {
                            MessageBox.Show(Application.OpenForms[0], "授权加密狗未插入，请插入加密狗！");
                        }));
                        if (!Login() && !CheckValid())
                        {
                            WinInfoHelper.ShowInfoWindow(null, "如果未插入有效加密狗，系统将在10s后自动关闭！");
                            close = true;
                        }  
                    }
                }
            }
        }
        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            try
            {
                DoCheckAndClose();
            }
            catch (Exception ex)
            {
                log.Error("加密狗检查异常：", ex);
            }
            timer.Start();
        }
    }
}
