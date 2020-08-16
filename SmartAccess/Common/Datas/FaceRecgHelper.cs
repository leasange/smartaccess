using Li.Access.Core.FaceDevice;
using Li.Access.Core.FaceDevice.FY;
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
        private static List<Maticsoft.Model.SMT_FACERECG_DEVICE> _devices = null;
        public static List<Maticsoft.Model.SMT_FACERECG_DEVICE> GetList(string strWhere, bool withArea = false,bool bUpdate=true)
        {
            if (!bUpdate&&_devices!=null&&_devices.Count>0)
            {
                return _devices.ToList();
            }

            Maticsoft.BLL.SMT_FACERECG_DEVICE bll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
            if (withArea)
            {
                _devices = bll.GetModelListWithArea(strWhere);
            }
            _devices = bll.GetModelList(strWhere);
            return _devices;
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

        public static IFaceRecg ToFaceController(Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            if (dev.FACEDEV_MODE== FaceDeviceModel.FY.ToString())
            {
                FyFaceRecg fyFaceRecg = new FyFaceRecg(dev.ID,dev.FACEDEV_IP);
                return fyFaceRecg;
            }
            else
            {
                BSTFaceRecg bst = new BSTFaceRecg();
                bst.InitConfig(dev.FACEDEV_IP, dev.FACEDEV_CTRL_PORT, dev.FACEDEV_HEART_PORT, dev.FACEDEV_DB_PORT, dev.FACEDEV_DB_NAME, dev.FACEDEV_DB_USER, dev.FACEDEV_DB_PWD);
                return bst;
            }
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

        public static List<DevComponents.AdvTree.Node> ToFaceTree(List<Maticsoft.Model.SMT_FACERECG_DEVICE> faceDevices, List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            var nodes = AreaDataHelper.ToTree(areas);
            var faceDevs = faceDevices.ToList();
            foreach (var item in nodes)
            {
                DoCreateAreaDevice(item, faceDevs);
            }

            for (int i = faceDevs.Count - 1; i >= 0; i--)
            {
                var item = faceDevs[i];
                DevComponents.AdvTree.Node devNode = new DevComponents.AdvTree.Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                devNode.Image = Properties.Resources.editor;
                devNode.Tag = item;
                nodes.Insert(0, devNode);
            }
            DevComponents.AdvTree.Node root = new DevComponents.AdvTree.Node("所有人脸识别设备");
            root.Image = Properties.Resources.house1818;
            root.Nodes.AddRange(nodes.ToArray());
            nodes.Clear();
            nodes.Add(root);
            return nodes;
        }

        private static void DoCreateAreaDevice(DevComponents.AdvTree.Node areaNode, List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE zone = areaNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            if (zone != null)
            {
                var fdev = devs.FindAll(m => m.AREA_ID == zone.ID);
                for (int i = fdev.Count - 1; i >= 0; i--)
                {
                    var item = fdev[i];
                    DevComponents.AdvTree.Node doorNode = new DevComponents.AdvTree.Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                    doorNode.Tag = item;
                    doorNode.Image = Properties.Resources.door1818;
                    areaNode.Nodes.Insert(0, doorNode);
                    devs.Remove(item);
                }
            }
            foreach (DevComponents.AdvTree.Node item in areaNode.Nodes)
            {
                DoCreateAreaDevice(item, devs);
            }
        }
    }
}
