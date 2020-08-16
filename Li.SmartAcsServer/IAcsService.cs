using Li.Access.Core.Datas;
using Li.Access.Core.FaceDevice;
using Li.SmartAcsServer.AcsRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Li.SmartAcsServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IAcsService
    {
        // TODO: 在此添加您的服务操作
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getDate")]
        RespRet<string> GetDate();

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/addOrModifyFace")]
        RespRet<ContinueRet> AddOrModifyFace(ComReq<StaffFace> comReq);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/deleteFaces")]
        RespRet<ContinueRet> DeleteFaces(ComReq<List<string>> comReq);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/clearFaces")]
        RespRet<ContinueRet> ClearFaces(ComReq<string> comReq);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/isFaceExists")]
        RespRet<ContinueRet> IsFaceExists(ComReq<string> comReq);
    }
}
