using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class RegisterMsgResp : BaseMsg
    {
        public string token;// 会话令牌 string 32 Y 如：“1536811918“云端生成一个唯一的临时会话令牌，对应一次连接，可用于云端校验设备，后续设备上会带上此项
        public string registerTime;// 云端本地的注册时间，毫秒级别string 32 Y 格式：“1585903632011“;Unix标准时间戳，毫秒级别，13位设备根据此值与云端进行时间同步一次
        public string errorCode = "100";// 注册代码 stringss 32 Y 100:注册成功 200:注册失败 失败服务器会关闭此连接
    }
}
