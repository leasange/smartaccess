using Li.Access.Core.FaceDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    /// <summary>
    /// 人脸识别设备管理
    /// </summary>
    public class FaceRecgHelper
    {
        public static List<Maticsoft.Model.SMT_FACERECG_DEVICE> GetList(string strWhere, bool withArea = false)
        {
            Maticsoft.BLL.SMT_FACERECG_DEVICE bll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
            if (withArea)
            {
                return bll.GetModelListWithArea(strWhere);
            }
            return bll.GetModelList(strWhere);
        }

        public static List<Maticsoft.Model.SMT_FACERECG_DEVICE> GetList(List<decimal> areaIds, bool withArea = false)
        {
            string strWhere = "1=1";
            if (areaIds != null && areaIds.Count > 0)
            {
                strWhere += " and AREA_ID in (";
                for (int i = 0; i < areaIds.Count; i++)
                {
                    strWhere += areaIds[i] + ",";
                }
                strWhere = strWhere.TrimEnd(',') + ")";
            }
            return GetList(strWhere, withArea);
        }

        public static BSTFaceRecg ToFaceController(Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            BSTFaceRecg bst = new BSTFaceRecg();
            bst.InitConfig(dev.FACEDEV_IP, dev.FACEDEV_CTRL_PORT,dev.FACEDEV_HEART_PORT, dev.FACEDEV_DB_PORT, dev.FACEDEV_DB_NAME, dev.FACEDEV_DB_PWD);
            return bst;
        }
    }
}
