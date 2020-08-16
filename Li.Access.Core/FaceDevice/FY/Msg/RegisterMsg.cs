using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class RegisterMsg : BaseMsg
    {
        public string rand;// 随机数 string 64 Y 如：“12N8Y9DKIO“
        public string protocolVersion;// 接口版本号 string 32 Y 接口版本号，如：V1.0
        public string hardwareVersion;// 硬件版本号 string 32 Y 如："A2"
        public string softwareVersion;// 软件版本号 string 32 Y 如："2.1.9 2020-02-13" 版本号 编译时间
        public string algVersion;// 算法版本号 string 32 Y 如："1.0.2-1.2.0"
        public string sign;// 签名 string 64 Y sign = MD5(deviceNo + registerTime;// + rand + deviceNo)大写字符串
        public string ip;//自定义IP
    }
}
