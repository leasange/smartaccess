using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Li.UdpMessageQueue
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        NONE,//未知
        ALARM,//报警
        HEART,//心跳
    }

    public class UnitsHepler
    {
        private static object lockObj = new object();
        /// <summary> 
        /// 获取操作系统已用的端口号 
        /// </summary> 
        /// <returns></returns> 
        public static List<int> GetAllUsedNetPorts()
        {
            lock (lockObj)
            {
                //获取本地计算机的网络连接和通信统计数据的信息 
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

                //返回本地计算机上的所有Tcp监听程序 
                IPEndPoint[] ipsTCP = ipGlobalProperties.GetActiveTcpListeners();

                //返回本地计算机上的所有UDP监听程序 
                IPEndPoint[] ipsUDP = ipGlobalProperties.GetActiveUdpListeners();

                //返回本地计算机上的Internet协议版本4(IPV4 传输控制协议(TCP)连接的信息。 
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

                List<int> allPorts = new List<int>();
                foreach (IPEndPoint ep in ipsTCP) allPorts.Add(ep.Port);
                foreach (IPEndPoint ep in ipsUDP) allPorts.Add(ep.Port);
                foreach (TcpConnectionInformation conn in tcpConnInfoArray) allPorts.Add(conn.LocalEndPoint.Port);

                return allPorts;
            }
        }
        /// <summary>
        /// 获取下一个可用的网络端口
        /// </summary>
        /// <param name="start">从start开始</param>
        /// <returns>可用网络端口，没有可有端口为-1</returns>
        public static int GetNextAvailableNetPort(int start = 0)
        {
            lock (lockObj)
            {
                List<int> list = GetAllUsedNetPorts();
                for (int i = start; i < IPEndPoint.MaxPort; i++)
                {
                    if (!list.Contains(i))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
        //打包消息
        public static byte[] PacketMessage(object msg, MessageType msgType)
        {
            string str = msgType + "." + Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            byte[] bts = Encoding.UTF8.GetBytes(str);
            return bts;
        }
        //解析byte[]消息为字符串
        public static string ParseMessage(byte[] bts,out MessageType msgType)
        {
            string str = Encoding.UTF8.GetString(bts);
            int ind = str.IndexOf('.');
            msgType = MessageType.NONE;
            if (ind > 0)
            {
                string strMsgType = str.Substring(0, ind);

                if (Enum.TryParse<MessageType>(strMsgType, out msgType))
                {
                    str = str.Substring(ind + 1);
                }
                else
                {
                    msgType = MessageType.NONE;
                }
            }
            return str;
        }
        //解析str消息为对象
        public static T ParseMessage<T>(string msg)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(msg);
        }
    }
}
