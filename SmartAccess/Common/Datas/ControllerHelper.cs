using Li.Access.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    /// <summary>
    /// 控制器操作帮助类
    /// </summary>
    public class ControllerHelper
    {
        public static Maticsoft.Model.SMT_CONTROLLER_INFO  ToInfo(Controller ctrlr)
        {
            Maticsoft.Model.SMT_CONTROLLER_INFO info = new Maticsoft.Model.SMT_CONTROLLER_INFO();
            info.AREA_ID = -1;
            info.CTRLR_DESC = "";
            info.CTRLR_MODEL = ctrlr.model;
            info.CTRLR_TYPE = (int)ctrlr.doorType;
            info.DRIVER_DATE = ctrlr.driverReleaseTime;
            info.DRIVER_VERSION = ctrlr.driverVersion;
            info.GATEWAY = ctrlr.gateway;
            info.IP = ctrlr.ip;
            info.MAC = ctrlr.mac;
            info.MASK = ctrlr.mask;
            info.NAME = ctrlr.ip;
            info.ORDER_VALUE = 100;
            info.ORG_ID = -1;
            info.PORT = ctrlr.port;
            info.SN_NO = ctrlr.sn;
            return info;
        }
        public static decimal AddController(Controller ctrlr)
        {
            Maticsoft.Model.SMT_CONTROLLER_INFO info = ToInfo(ctrlr);
            Maticsoft.BLL.SMT_CONTROLLER_INFO bll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            return bll.Add(info);
        }
    }
}
