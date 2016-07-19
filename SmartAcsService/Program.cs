using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace SmartAcsService
{
    static class Program
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("服务开始启动...");

            if (args!=null&&args.Length>0&&args[0]=="-cmd")
            {
                new MainService().Start(args);
                while (true)
                {
                    Console.ReadLine();
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new MainService() 
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
