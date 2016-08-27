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
            info.IS_ENABLE = true;
            return info;
        }
        public static Controller ToController(Maticsoft.Model.SMT_CONTROLLER_INFO info)
        {
            Controller ctrlr = new Controller();
            ControllerDoorType type= ControllerDoorType.TwoDoorsTwoDirections;
            Enum.TryParse<ControllerDoorType>(Convert.ToString(info.CTRLR_TYPE), out type);
            ctrlr.doorType = type;
            ctrlr.driverReleaseTime = info.DRIVER_DATE == null ? DateTime.MinValue : (DateTime)info.DRIVER_DATE;
            ctrlr.driverVersion = info.DRIVER_VERSION;
            ctrlr.gateway = info.GATEWAY;
            ctrlr.id = info.ID;
            ctrlr.ip = info.IP;
            ctrlr.mac = info.MAC;
            ctrlr.mask = info.MASK;
            ctrlr.model = info.CTRLR_MODEL;
            ctrlr.port = info.PORT == null ? 60000 : (int)info.PORT;
            ctrlr.sn = info.SN_NO;
            return ctrlr;
        }
        public static Maticsoft.Model.SMT_CONTROLLER_INFO AddController(Controller ctrlr)
        {
            Maticsoft.Model.SMT_CONTROLLER_INFO info = UpdateDBControllerIp(ctrlr);//如果存在则更新
            if (info!=null)
            {
                info.DOOR_INFOS = DoorDataHelper.GetDoors();
                return info;
            }
            info = ToInfo(ctrlr);
            Maticsoft.BLL.SMT_CONTROLLER_INFO bll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            decimal ctrlId= bll.Add(info);
            info.ID = ctrlId;
            int count = 1;
            int dir = 1;
            switch (ctrlr.doorType)
            {
                case ControllerDoorType.OneDoorTwoDirections:
                    count = 1;
                    dir = 2;
                    break;
                case ControllerDoorType.TwoDoorsTwoDirections:
                    count = 2;
                    dir = 2;
                    break;
                case ControllerDoorType.FourDoorsOneDirection:
                    count = 4;
                    dir = 1;
                    break;
                default:
                    break;
            }
            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            info.DOOR_INFOS = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            for (int i = 0; i < count; i++)
            {
                Maticsoft.Model.SMT_DOOR_INFO doorInfo = new Maticsoft.Model.SMT_DOOR_INFO();
                doorInfo.CTRL_DELAY_TIME = 3;
                doorInfo.CTRL_DOOR_INDEX = i + 1;
                doorInfo.CTRL_ID = ctrlId;
                doorInfo.CTRL_STYLE = 0;
                doorInfo.DOOR_NAME = "门_" + ctrlId + "_" + (i + 1);
                doorInfo.DOOR_DESC = doorInfo.DOOR_NAME;
                doorInfo.AREA_ID = -1;
                doorInfo.AREA_NAME = "";
                doorInfo.ID = -1;
                doorInfo.IS_ATTENDANCE1 = false;
                doorInfo.IS_ATTENDANCE2 = false;
                doorInfo.IS_ENABLE = true;
                doorInfo.IS_ENTER1 = true;
                doorInfo.IS_ENTER2 = dir == 1;
                doorInfo.ID = doorBll.Add(doorInfo);
                info.DOOR_INFOS.Add(doorInfo);
            }
            return info;
        }

        public static Maticsoft.Model.SMT_CONTROLLER_INFO UpdateDBControllerIp(Controller ctrlr)
        {
            Maticsoft.BLL.SMT_CONTROLLER_INFO bll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            List<Maticsoft.Model.SMT_CONTROLLER_INFO> models = bll.GetModelList("SN_NO='" + ctrlr.sn + "'");
            if (models.Count>0)
            {
                models[0].IP = ctrlr.ip;
                models[0].MASK = ctrlr.mask;
                models[0].GATEWAY = ctrlr.gateway;
                bll.Update(models[0]);
                return models[0];
            }
            return null;
        }

        public static List<Maticsoft.Model.SMT_CONTROLLER_INFO> GetList(string strWhere,bool withAreaAndDoors=false)
        {
            Maticsoft.BLL.SMT_CONTROLLER_INFO bll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            if (withAreaAndDoors)
            {
                return bll.GetModelListWithAreaDoor(strWhere);
            }
            return bll.GetModelList(strWhere);
        }
        public static List<Maticsoft.Model.SMT_CONTROLLER_INFO> GetList(List<decimal> areaIds, bool withAreaAndDoors = false)
        {
            string strWhere = "1=1";
            if (areaIds!=null&&areaIds.Count>0)
            {
                strWhere += " and AREA_ID in (";
                for (int i = 0; i < areaIds.Count; i++)
                {
                    strWhere += areaIds[i] + ",";
                }
                strWhere = strWhere.TrimEnd(',')+")";
            }
            return GetList(strWhere, withAreaAndDoors);
        }

    }
}