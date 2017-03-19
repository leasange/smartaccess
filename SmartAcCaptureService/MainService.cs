using Li.SmartAcsServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace SmartAcCaptureService
{
    public partial class MainService : ServiceBase
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainService));
        public MainService()
        {
            InitializeComponent();
        }
        public void Start(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                AcsService.StartCaptureServices();
            }
            catch (Exception ex)
            {
                log.Error("记录读取服务启动异常", ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                
                AcsService.StopAllServices();
            }
            catch (Exception ex)
            {
                log.Error("服务停止异常", ex);
                throw;
            }
        }
    }
}
