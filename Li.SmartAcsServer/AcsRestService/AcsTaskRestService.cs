using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Li.SmartAcsServer.AcsRestService
{
    public class AcsTaskRestService
    {
        private static AcsTaskRestService _restService;
        public static AcsTaskRestService Instance
        {
            get
            {
                if (_restService==null)
                {
                    _restService = new AcsTaskRestService();
                }
                return _restService;
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AcsTaskRestService));
        private ServiceHost host = null;
        public AcsTaskRestService()
        {
        }
        public void Start()
        {
            try
            {
                host = new WebServiceHost(typeof(AcsService));
                host.Open();
                try
                {
                    string address = host.BaseAddresses[0].ToString();
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    if (!dicBll.Exists("SYSTEM_CONFIG", "ACS_REST_URL"))
                    {
                        dicBll.Add(new Maticsoft.Model.SMT_DATADICTIONARY_INFO()
                        {
                            DATA_TYPE = "SYSTEM_CONFIG",
                            DATA_KEY = "ACS_REST_URL",
                            DATA_VALUE = address,
                            DATA_NAME = "门禁服务REST地址",
                            DATA_CONTENT = "门禁服务REST地址"
                        });
                    }
                }
                catch (Exception ex)
                {
                    log.Error("保存数据库配置异常：" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                log.Error("发布服务启动异常", ex);
            }
        }
        public void Stop()
        {
            if (host != null)
            {
                host.Close();
            }
        }
    }
}
