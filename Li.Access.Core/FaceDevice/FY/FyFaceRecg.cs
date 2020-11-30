using Li.Access.Core.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY
{
    public class FyFaceRecg : IFaceRecg
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FyFaceRecg));
        private decimal dev_id;
        private string dev_ip;
        private string restUrl = "";
        private static CookieContainer cookieContainer = new CookieContainer();

        public bool IsHeartbeating
        {
            get
            {
                return true;
            }
        }

        public FyFaceRecg(decimal id, string ip)
        {
            this.dev_id = id;
            this.dev_ip = ip;
            Maticsoft.BLL.SMT_DATADICTIONARY_INFO bll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
            var models = bll.GetModelList("DATA_TYPE='SYSTEM_CONFIG' and DATA_KEY='ACS_REST_URL'");
            if (models.Count>0)
            {
                restUrl = models[0].DATA_VALUE;
                if (!string.IsNullOrWhiteSpace(restUrl))
                {
                    restUrl = restUrl.TrimEnd('\\', '/');
                }
                log.Info("获取到ACS服务地址为：" + restUrl);
            }
            else
            {
                log.Error("ACS服务地址不存在！");
            }
        }

        private RespRet<TResult> PostData<TResult>(string url,object data)
        {
            WebClientEx webClient = new WebClientEx();
            webClient.CookieContainer = cookieContainer;
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Set(HttpRequestHeader.ContentType, "application/json");
            ComReq<object> comReq = new Datas.ComReq<object>()
            {
                dev_id = dev_id,
                dev_ip = dev_ip,
                dev_model= GetDeviceModel(),
                data = data
            };
            string ret = webClient.UploadString(restUrl + url, Newtonsoft.Json.JsonConvert.SerializeObject(comReq));
            RespRet<TResult> respRet = Newtonsoft.Json.JsonConvert.DeserializeObject<RespRet<TResult>>(ret);
            return respRet;
        }

        public bool AddOrModifyFaces(out string tempMsg, params StaffFace[] staffFaces)
        {
            tempMsg = "";
            if (string.IsNullOrWhiteSpace(restUrl))
            {
                tempMsg = "ACS服务地址为空！";
                return false;
            }
            foreach (var staffFace in staffFaces)
            {
                RespRet<ContinueRet> respRet = PostData<ContinueRet>("/addOrModifyFace", staffFace);
                staffFace.update_result = respRet.IsSuccess;
                tempMsg = respRet.message;
                if (respRet.result != null)
                {
                    if (!respRet.result.isContinue)
                    {
                        tempMsg = respRet.result.errorMsg;
                        return true;
                    }
                }
                else if(!respRet.IsSuccess)
                {
                    tempMsg = respRet.result.errorMsg;
                    return true;
                }
            }
            return true;
        }

        public bool ClearFaces()
        {
            if (string.IsNullOrWhiteSpace(restUrl))
            {
                return false;
            }
            string data=null;
            RespRet<ContinueRet> respRet = PostData<ContinueRet>("/clearFaces", data);
            return respRet.IsSuccess;
        }

        public bool DeleteFaces(List<string> deleteprivates)
        {
            if (string.IsNullOrWhiteSpace(restUrl))
            {
                return false;
            }
            RespRet<ContinueRet> respRet = PostData<ContinueRet>("/deleteFaces", deleteprivates);
            return respRet.IsSuccess;
        }

        public void Dispose()
        {
            
        }

        public FaceDeviceModel GetDeviceModel()
        {
            return FaceDeviceModel.FY;
        }

        public bool IsFaceExists(string id)
        {
            //isFaceExists
            if (string.IsNullOrWhiteSpace(restUrl))
            {
                return false;
            }
            RespRet<ContinueRet> respRet = PostData<ContinueRet>("/isFaceExists", id);
            return respRet.IsSuccess;
        }

        public bool ModifyTextInfo(out string errorMsg, params StaffFace[] staffFaces)
        {
            return AddOrModifyFaces(out errorMsg, staffFaces);
        }

        public void BeginHeartbeat()
        {
            
        }

        public void SetRealRecordCallback(FaceRealRecordHandle faceRealRecordHandle)
        {
            throw new NotImplementedException();
        }

        public bool StartPlayVideo(IntPtr winHandle)
        {
            throw new NotImplementedException();
        }

        public void StopPlayVideo(IntPtr winHandle)
        {
            throw new NotImplementedException();
        }
    }
}
