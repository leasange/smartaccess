using SmartAccess.Common.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SmartAccess.Common
{
    public enum LogLevel
    {
        DEBUG,
        INFO,
        WARN,
        ERROR
    }
    /// <summary>
    /// 日志记录类
    /// </summary>
    public class SmtLog
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(SmtLog));
        private static void DoSave(string logType, LogLevel  level,string msg)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_LOG_INFO logBll = new Maticsoft.BLL.SMT_LOG_INFO();
                        Maticsoft.Model.SMT_LOG_INFO model = new Maticsoft.Model.SMT_LOG_INFO();
                        model.OPR_CONTENT = msg;
                        model.LOG_LEVEL = (int)level;
                        model.OPR_TIME = DateTime.Now;
                        model.LOG_TYPE = logType;
                        model.OPR_USERID = UserInfoHelper.UserID;

                        if (string.IsNullOrWhiteSpace(UserInfoHelper.UserInfo.REAL_NAME))
                        {
                            model.OPR_REALNAME = UserInfoHelper.UserInfo.USER_NAME;
                        }
                        else model.OPR_REALNAME = UserInfoHelper.UserInfo.USER_NAME + "(" + UserInfoHelper.UserInfo.REAL_NAME + ")";
                        logBll.Add(model);
                    }
                    catch (Exception ex)
                    {
                        log.Error("保存日志到数据库异常：" + ex.Message + "=>" + logType + "," + level + "," + msg);
                    }
                }));
        }
        public static void Debug(string logType, string msg)
        {
            DoSave(logType, LogLevel.DEBUG, msg);
        }
        public static void DebugFormat(string logType, string format, params object[] args)
        {
            string msg = string.Format(format, args);
            Debug(logType, msg);
        }
        public static void Info(string logType, string msg)
        {
            DoSave(logType, LogLevel.INFO, msg);
        }
        public static void InfoFormat(string logType, string format,params object[] args)
        {
            string msg = string.Format(format, args);
            Info(logType, msg);
        }
        public static void Warn(string logType, string msg)
        {
            DoSave(logType, LogLevel.WARN, msg);
        }
        public static void WarnFormat(string logType, string format, params object[] args)
        {
            string msg = string.Format(format, args);
            Warn(logType, msg);
        }
        public static void Error(string logType, string msg)
        {
            DoSave(logType, LogLevel.ERROR, msg);
        }
        public static void ErrorFormat(string logType, string format, params object[] args)
        {
            string msg = string.Format(format, args);
            Error(logType, msg);
        }
    }
}
