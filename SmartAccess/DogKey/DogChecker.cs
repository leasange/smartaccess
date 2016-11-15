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
                    log.Error("加密狗登陆错误：" + GetError(ret));
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
        private static string GetError(long ret)
        {
            string str = "成功";
            switch (ret)
            {
                case 0: ; str = "成功"; break;
                case 1: ; str = "指定应用程序ID的锁未找到"; break;

                case 2: ; str = "参数不合法"; break;

                case 3: ; str = "未找到加密锁"; break;

                case 4: ; str = "未找到加密锁HANDLE"; break;

                case 5: ; str = "权限不足"; break;

                case 6: ; str = "驱动未打开"; break;

                case 7: ; str = "不支持该特性"; break;

                case 8: ; str = "内部错误"; break;

                case 20: ; str = "HID读操作错误"; break;

                case 21: ; str = "HID读操作错误 - 数据不足"; break;

                case 22: ; str = "HID写操作错误"; break;

                case 23: ; str = "HID写操作错误 - 数据不足"; break;

                case 24: ; str = "HID读操作错误 - 超时"; break;

                case 25: ; str = "HID读操作错误 - 未定义错误"; break;

                case 26: ; str = "HID读操作错误 - 超时"; break;

                case 27: ; str = "HID读操作错误 - 未定义错误"; break;

                case 28: ; str = "设备未连接或半途拔掉"; break;

                case 50: ; str = "内部错误"; break;

                case 51: ; str = "内部错误"; break;

                case 52: ; str = "内部错误"; break;

                case 102: ; str = "内部错误"; break;

                case 103: ; str = "内部错误"; break;

                case 104: ; str = "内部错误"; break;

                case 105: ; str = "内部错误"; break;

                case 106: ; str = "内部错误"; break;

                case 107: ; str = "内部错误"; break;

                case 108: ; str = "内部错误"; break;

                case 109: ; str = "内部错误"; break;

                case 110: ; str = "内部错误"; break;

                case 111: ; str = "内部错误"; break;

                case 112: ; str = "内部错误"; break;

                case 113: ; str = "内部错误"; break;

                case 114: ; str = "内部错误"; break;

                case 115: ; str = "文件大小必须为8的倍数"; break;

                case 116: ; str = "文件系统未加载"; break;

                case 202: ; str = "文件系统未初始化"; break;

                case 203: ; str = "文件系统格式错误"; break;

                case 204: ; str = "不支持的文件系统类型"; break;

                case 205: ; str = "不存在此文件"; break;

                case 206: ; str = "数据文件大小不一致"; break;

                case 207: ; str = "没有更多的文件了"; break;

                case 208: ; str = "文件系统空间不足"; break;

                case 209: ; str = "已达到最大文件数限制"; break;

                case 500: ; str = "内部错误"; break;

                case 501: ; str = "权限不足"; break;

                case 502: ; str = "内部错误"; break;

                case 503: ; str = "内部错误"; break;

                case 504: ; str = "内部错误"; break;

                case 505: ; str = "内部错误"; break;

                case 506: ; str = "内部错误"; break;

                case 507: ; str = "登录密码错误"; break;

                case 508: ; str = "数据写失败"; break;

                case 509: ; str = "此ID可执行文件不存在"; break;

                case 510: ; str = "文件系统不存在"; break;

                case 511: ; str = "升级错误"; break;

                case 512: ; str = "设备已进入安全模式"; break;

                case 513: ; str = "BS模式用户登录失败"; break;

                case 514: ; str = "未知错误"; break;
                default:
                    break;
            }
            if (ret != 0)
            {
                return str;
            }
            return "";
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
                    log.Error("读取时间1异常：" + GetError(ret));
                    return false;
                }
                if (!DateTime.TryParse(Encoding.UTF8.GetString(buffer), out dtStart))
                {
                    log.Error("时间1异常：" + GetError(ret));
                    return false;
                }

                ret = NT158App.NT158ReadFile(handle, 0, 128 + 2 * 19, buffer);
                if (ret != 0)
                {
                    log.Error("读取时间2异常：" + GetError(ret));
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
