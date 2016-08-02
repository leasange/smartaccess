using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartAccess
{
    static class Program
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("客户端启动...");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.ThreadException += Application_ThreadException;
           // Application.Run(new FrmLogin());
            Application.Run(new SmartAccess.VerInfoMgr.FrmGetPicture());
            
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception!=null)
            {
                log.Error("未捕获异常", e.Exception);
                throw e.Exception;
            }
        }
    }
}
