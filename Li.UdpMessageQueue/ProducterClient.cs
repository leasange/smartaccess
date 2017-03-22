using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Li.UdpMessageQueue
{
    /// <summary>
    /// 生产着
    /// </summary>
    public class ProducterClient
    {
        private IPEndPoint ipBrokerServer;
        private string _ipBrokerServer = null;
        private UdpClient udpClient = null;
        public ProducterClient(string brokerServer)
        {
            _ipBrokerServer = brokerServer;
            udpClient = new UdpClient();
            InitRemotePoint();
        }
        private void InitRemotePoint()
        {
            if (string.IsNullOrWhiteSpace(_ipBrokerServer))
            {
                return;
            }
            string[] ips = _ipBrokerServer.Split(':');
            if (ips.Length == 1)
            {
                ipBrokerServer = new IPEndPoint(IPAddress.Parse(ips[0].Trim()), 56010);
            }
            else if (ips.Length > 0)
            {
                ipBrokerServer = new IPEndPoint(IPAddress.Parse(ips[0].Trim()), int.Parse(ips[1].Trim()));
            }
        }
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <typeparam name="T">消息类型</typeparam>
        /// <param name="msg">消息对象</param>
        public void SendMessageAsync<T>(T msg, MessageType msgType = MessageType.ALARM)
        {
            string str = msgType + "." + Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            byte[] bts = Encoding.UTF8.GetBytes(str);
            udpClient.Send(bts, bts.Length, ipBrokerServer);
        }
    }
}
