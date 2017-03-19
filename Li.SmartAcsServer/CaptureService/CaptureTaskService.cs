using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using Li.UdpMessageQueue;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.SmartAcsServer.CaptureService
{
    /// <summary>
    /// 记录提取服务
    /// </summary>
    public class CaptureTaskService
    {
        private static CaptureTaskService _instance = null;
        public static CaptureTaskService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CaptureTaskService();
                }
                return _instance;
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(CaptureTaskService));
        private List<Controller> _controllers = null;
        protected CaptureTaskService()
        {

        }

        /// <summary>
        /// 启动记录提起服务
        /// </summary>
        public void Start(int interval = 3)
        {
            log.Info("开始启动记录读取服务...");
        }
        private void TestDb()
        {
            try
            {
                DoLoadCtrlr();
            }
            catch (Exception)
            {
                //  throw;
            }
        }

        public void Stop()
        {
            log.Info("停止记录读取服务...");
        }

        private void DoLoadCtrlr()
        {
            try
            {
                log.Info("加载控制器...");
                Maticsoft.BLL.SMT_CONTROLLER_INFO bll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = bll.GetModelList("1=1");
                if (ctrls.Count > 0)
                {
                    log.Info("控制器个数:" + ctrls.Count);
                    List<Controller> ctls = new List<Controller>();
                    foreach (Maticsoft.Model.SMT_CONTROLLER_INFO item in ctrls)
                    {
                        Controller ctl = new Controller();
                        ctl.id = item.ID;
                        ctl.sn = item.SN_NO;
                        ctl.ip = item.IP;
                        ctl.port = item.PORT == null ? 60000 : (int)item.PORT;
                        if (ctl.port <= 0 || ctl.port > 65535)
                        {
                            ctl.port = 60000;
                        }
                        ctl.mac = item.MAC;
                        ctl.mask = item.MASK;
                        ctl.model = item.CTRLR_MODEL;
                        ctl.gateway = item.GATEWAY;
                        ctls.Add(ctl);
                    }
                    _controllers = ctls;
                }
            }
            catch (Exception ex)
            {
                log.Error("加载控制器异常：", ex);
            }
        }
    }
}
