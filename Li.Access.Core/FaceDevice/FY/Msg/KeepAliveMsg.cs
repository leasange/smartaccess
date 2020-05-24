using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class KeepAliveMsg : BaseMsg
    {
        public string token;// 会话令牌 string 32 Y 如：“1536811918“
        public string locationx;// 经度 string 32 N 如：116.481499，小数点后不得超过6位, 选配GPS或4G模块时上报
        public string locationy;// 纬度 string 32 N 如：39.990475，小数点后不得超过6位，选配GPS或4G模块时上报
    }
}
