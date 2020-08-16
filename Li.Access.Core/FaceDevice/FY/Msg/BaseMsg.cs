using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class BaseMsg
    {
        public string msgType = null;
        public string deviceNo = null;
    }
    public class BaseMsgWithId : BaseMsg
    {
        public string msgID;
    }
    public class BaseMsgWithToken : BaseMsg
    {
        public string token = null;
    }
    public class BaseMsgWithIdAndToken : BaseMsgWithId
    {
        public string token = null;
    }
    public class BaseMsgWithError : BaseMsgWithIdAndToken
    {
        public string errorCode;// 状态码 string 32 Y 状态码：“100“表示接口调用成功“200“表示接口调用失败
        public string msg;// 具体信息 string 128 Y 如："操作成功"
    }
    public class BaseMsgWithErrorNoToken: BaseMsgWithId
    {
        public string errorCode;// 状态码 string 32 Y 状态码：“100“表示接口调用成功“200“表示接口调用失败
        public string msg;// 具体信息 string 128 Y 如："操作成功"
    }
}
