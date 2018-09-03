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
            bst.InitConfig(dev.FACEDEV_IP, dev.FACEDEV_CTRL_PORT, dev.FACEDEV_HEART_PORT, dev.FACEDEV_DB_PORT, dev.FACEDEV_DB_NAME, dev.FACEDEV_DB_USER, dev.FACEDEV_DB_PWD);
            return bst;
        }
        public static BSTVideoBase ToFaceVideo(Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            BSTVideoBase videoBase=null;
            if (dev.FVIDEO_RTSP_COUNT==1)
            {
                videoBase = new BSTVideoRTSP();
                BSTVideoRTSP vv = (BSTVideoRTSP)videoBase;
                vv.RTSP = dev.FVIDEO_RTSP;
            }
            else
            {
                videoBase = new BSTVideoRTSP3();
                BSTVideoRTSP3 vv = (BSTVideoRTSP3)videoBase;
                vv.RTSP1 = dev.FVIDEO_RTSP;
                vv.RTSP2 = dev.FVIDEO_RTSP2;
                vv.RTSP3 = dev.FVIDEO_RTSP3;
            }
            videoBase.Face_LEVEL = dev.FVIDEO_FACE_LEVEL==null?"0.8":((decimal)dev.FVIDEO_FACE_LEVEL).ToString("0.00");
            videoBase.RIO_X = dev.FVIDEO_RIO_X == null ? "0" : ((decimal)dev.FVIDEO_RIO_X).ToString("0.00");
            videoBase.RIO_Y = dev.FVIDEO_RIO_Y == null ? "0" : ((decimal)dev.FVIDEO_RIO_Y).ToString("0.00");
            videoBase.RIO_W = dev.FVIDEO_RIO_W == null ? "1" : ((decimal)dev.FVIDEO_RIO_W).ToString("0.00");
            videoBase.RIO_H = dev.FVIDEO_RIO_H == null ? "1" : ((decimal)dev.FVIDEO_RIO_H).ToString("0.00");
            videoBase.SINGLE = dev.FVIDEO_SINGLE;
            videoBase.TITLE1 = dev.FVIDEO_TITLE1;
            videoBase.TITLE2 = dev.FVIDEO_TITLE2;
            videoBase.HostIP = dev.FACEDEV_IP;
            return videoBase;
        }
    }
}
