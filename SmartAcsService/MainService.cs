﻿using Li.SmartAcsServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;

namespace SmartAcsService
{
    public partial class MainService : ServiceBase
    {
        private ServiceHost host = null;
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
                AcsService.StartAllServices();
            }
            catch (Exception ex)
            {
                log.Error("记录读取服务启动异常", ex);
                throw;
            }
            try
            {
                host = new ServiceHost(typeof(AcsService));
                host.Open();
            }
            catch (Exception ex)
            {
                log.Error("发布服务启动异常", ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                try
                {
                    host.Close();
                }
                catch (Exception)
                { 
                }
                
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
