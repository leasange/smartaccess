using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Li.UdpMessageQueue
{
    /// <summary>
    /// 广播服务
    /// </summary>
    public class BroadcastServer
    {
        private UdpClient udpServer = null;
        private int broadcastPort = 56010;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(BroadcastServer));
        private AsyncCallback SendCallBackHandle = null;
        private List<BrokerClient> _brokerClient = null;
        /// <summary>
        /// 远程端口
        /// </summary>
        public int BroadcastPort
        {
            get { return broadcastPort; }
            set { broadcastPort = value; }
        }
        public BroadcastServer()
        {
            udpServer = new UdpClient();
            udpServer.EnableBroadcast = true;
            SendCallBackHandle = new AsyncCallback(SendCallBack);
        }
        public BroadcastServer(int broadcastPort):this()
        {
            this.broadcastPort = broadcastPort;
        }
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <typeparam name="T">消息类型</typeparam>
        /// <param name="msg">消息对象</param>
        public void SendMessageAsync<T>(T msg,MessageType msgType= MessageType.ALARM)
        {
            string str = msgType + "." + Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            
            byte[] bts = Encoding.UTF8.GetBytes(str);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, broadcastPort);
            udpServer.BeginSend(bts, bts.Length, endPoint, SendCallBackHandle, null);
        }
        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                int i = udpServer.EndSend(ar);
            }
            catch (Exception ex)
            {
                log.Error("发送消息异常：", ex);
            }

        }
    }
}
