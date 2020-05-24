using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice
{
    public class BSTDevice
    {
        public decimal _id;
        public string _ip;
        public int _port;
        public int _heartPort;
        public int _dbPort;
        public string _dbName;
        public string _dbUser;
        public string _dbPwd;
        public string _devName;
    }
    public abstract class BSTVideoBase
    {
        public string Face_LEVEL;//“0.80”,					//分数阈值（0~1）
        public string HostIP;// : “192.168.9.70”,				//设备IP地址
        public string RIO_X;// : “0”,							//检测区域左上角横坐标（0~1）
        public string RIO_Y;// : “0”,							//检测区域左上角纵坐标（0~1）
        public string RIO_H;// : “1”,							//检测区域高度（0~1）
        public string RIO_W;// : “1”,							//检测区域宽度（0~1）
        public string SINGLE;// : “Y”,						//模式选择（Y为单人，N为多人）
        public string TITLE1;// : “博思廷”,					//标题一
        public string TITLE2;// : “BST”,						//标题二
    }
    public class BSTVideoRTSP : BSTVideoBase
    {
        public string RTSP;//“rtsp://192.168.9.11:554/user=admin_password=tlJwpbo6_channel=1_stream=0.sdp?real_stream”,								//RTSP地址
    }
    public class BSTVideoRTSP3 : BSTVideoBase
    {
        public string RTSP1;//“rtsp://192.168.9.11:554/user=admin_password=tlJwpbo6_channel=1_stream=0.sdp?real_stream”,
        public string RTSP2;//RTSP地址
        public string RTSP3;
    }
}
