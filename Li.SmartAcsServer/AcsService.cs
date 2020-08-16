using Li.Access.Core.Datas;
using Li.Access.Core.FaceDevice;
using Li.Access.Core.FaceDevice.FY;
using Li.SmartAcsServer.AcsRestService;
using Li.SmartAcsServer.CaptureService;
using Li.SmartAcsServer.FyFaceService;
using Li.SmartAcsServer.PrivateService;
using Li.SmartAcsServer.RecordsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Li.SmartAcsServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class AcsService : IAcsService
    {
        private static int _serviceType = 0;//0 RecordTaskService ,1 CaptureTaskService
        /// <summary>
        /// 程序开启时，启动所有服务
        /// </summary>
        public static void StartAllServices()
        {
            Maticsoft.DBUtility.DbHelperSQL.connectionString = SunCreate.Common.ConfigHelper.GetConfigString("SqlServerConnectString");
            int interval = SunCreate.Common.ConfigHelper.GetConfigInt("RecordReadInterval");
            //启动记录读取服务
            _serviceType = 0;
            AcsTaskRestService.Instance.Start();
            RecordTaskService.Instance.Start(interval);
            FaceRecordTaskService.Instance.Start(interval);
            AutoAccessTaskService.Instance.Start();
            int fyFaceServerPort = SunCreate.Common.ConfigHelper.GetConfigInt("FyFaceServerPort");
            FyFaceTaskService.Instance.Start(fyFaceServerPort);
        }
        //启动抓拍服务
        public static void StartCaptureServices()
        {
            Maticsoft.DBUtility.DbHelperSQL.connectionString = SunCreate.Common.ConfigHelper.GetConfigString("SqlServerConnectString");
            int interval = SunCreate.Common.ConfigHelper.GetConfigInt("ScanInterval");
            //启动抓拍服务
            _serviceType = 1;
            CaptureTaskService.Instance.Start(interval);
        }
        /// <summary>
        /// 程序退出时退出所有服务
        /// </summary>
        public static void StopAllServices()
        {
            if (_serviceType==0)
            {
                AcsTaskRestService.Instance.Stop();
                RecordTaskService.Instance.Stop();
                FaceRecordTaskService.Instance.Stop();
                FyFaceTaskService.Instance.Stop();
            }
            else if (_serviceType==1)
            {
                CaptureTaskService.Instance.Stop();
            }
            FyFaceTaskService.Instance.Stop();
        }

        public RespRet<ContinueRet> AddOrModifyFace(ComReq<StaffFace> comReq)
        {
            IServerFaceRecg faceRecg = null;
            if (comReq.dev_model == FaceDeviceModel.FY)
            {
                faceRecg = FyServerFaceRecg.Instance;
            }
            ContinueRet continueRet = faceRecg.AddOrModifyFace(comReq);
            return RespRet<ContinueRet>.Ret(continueRet.isSuccess ? 0 : 1, continueRet.errorMsg, continueRet);
        }

        public RespRet<ContinueRet> ClearFaces(ComReq<string> comReq)
        {
            IServerFaceRecg faceRecg = null;
            if (comReq.dev_model == FaceDeviceModel.FY)
            {
                faceRecg = FyServerFaceRecg.Instance;
            }
            ContinueRet continueRet = faceRecg.IsFaceExists(comReq);
            return RespRet<ContinueRet>.Ret(continueRet.isSuccess ? 0 : 1, continueRet.errorMsg, continueRet);
        }

        public RespRet<ContinueRet> DeleteFaces(ComReq<List<string>> comReq)
        {
            IServerFaceRecg faceRecg = null;
            if (comReq.dev_model == FaceDeviceModel.FY)
            {
                faceRecg = FyServerFaceRecg.Instance;
            }
            ContinueRet continueRet = faceRecg.DeleteFaces(comReq);
            return RespRet<ContinueRet>.Ret(continueRet.isSuccess ? 0 : 1, continueRet.errorMsg, continueRet);
        }

        public RespRet<string> GetDate()
        {
            return RespRet<string>.Ret(0, "成功", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public RespRet<ContinueRet> IsFaceExists(ComReq<string> comReq)
        {
            IServerFaceRecg faceRecg = null;
            if (comReq.dev_model == FaceDeviceModel.FY)
            {
                faceRecg = FyServerFaceRecg.Instance;
            }
            ContinueRet continueRet = faceRecg.IsFaceExists(comReq);
            return RespRet<ContinueRet>.Ret(continueRet.isSuccess ? 0 : 1, continueRet.errorMsg, continueRet);
        }
    }
}
