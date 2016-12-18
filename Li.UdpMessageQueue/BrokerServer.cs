using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Li.UdpMessageQueue
{
    public class BrokerServer
    {
        private UdpClient udpServer = null;
        private int serverPort = 56010;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(BrokerServer));
        private AsyncCallback SendCallBackHandle = null;
        private AsyncCallback RecieveCallBack = null;
        private List<BrokerClient> clients = new List<BrokerClient>();
        private System.Timers.Timer timerCheck = null;
        /// <summary>
        /// 远程端口
        /// </summary>
        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        }
        public BrokerServer()
            : this(56010)
        {
        }
        public BrokerServer(int serverPort = 56010)
        {
            this.serverPort = serverPort;
            SendCallBackHandle = new AsyncCallback(SendCallBack);
            RecieveCallBack = new AsyncCallback(DoRecieveCallBack);
        }
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <typeparam name="T">消息类型</typeparam>
        /// <param name="msg">消息对象</param>
        public void SendMessageAsync<T>(T msg, MessageType msgType = MessageType.ALARM)
        {
            DoSendString(Newtonsoft.Json.JsonConvert.SerializeObject(msg), msgType);
        }
        private void DoSendString(string msg, MessageType msgType = MessageType.ALARM)
        {
            string str = msgType + "." + msg;
            byte[] bts = Encoding.UTF8.GetBytes(str);
            lock (clients)
            {
                foreach (var item in clients)
                {
                    udpServer.BeginSend(bts, bts.Length, item.ClientPoint, SendCallBackHandle, null);
                }
            }
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

        public void Start()
        {
            if (udpServer==null)
            {
                udpServer = new UdpClient(serverPort);
                timerCheck = new System.Timers.Timer(20000);
                timerCheck.Elapsed += timerCheck_Elapsed;
                timerCheck.Start();
                BeginRecieve();
            }
        }

        void timerCheck_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                lock (clients)
                {
                    DateTime now = DateTime.Now;
                    clients.RemoveAll(m =>
                    {
                        bool ret= (now - m.LastHeart).TotalSeconds >= 100;
                        if (ret)
                        {
                            log.InfoFormat("客户端:Point={0},ID={1} 超时被移除!", m.ClientPoint, m.ClientId);
                        }
                        return ret;
                    });
                }
            }
            catch (Exception ex)
            {
                log.Error("判断异常：", ex);
            }
        }
        private void BeginRecieve()
        {
            try
            {
                udpServer.BeginReceive(RecieveCallBack, null);
            }
            catch (Exception ex)
            {
            }

        }
        private void DoRecieveCallBack(IAsyncResult ar)
        {
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
                byte[] bts = udpServer.EndReceive(ar, ref point);
                ParseRecieveMsg(bts,point);
            }
            catch (Exception ex)
            {
                //  log.Error("读取异常：", ex.Message);
            }
            finally
            {
                BeginRecieve();
            }
        }

        private void ParseRecieveMsg(byte[] bts, IPEndPoint point)
        {
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        MessageType type;
                        string msg = UnitsHepler.ParseMessage(bts, out type);
                        if (type == MessageType.HEART)
                        {
                            string clientId = UnitsHepler.ParseMessage<string>(msg);
                            lock (clients)
                            {
                                var client = clients.Find(m => m.ClientId == clientId);
                                if (client == null)
                                {
                                    client = new BrokerClient(point, clientId);
                                    clients.Add(client);
                                    log.InfoFormat("接收到客户端：Point={0},ID={1}", point, clientId);
                                }
                                client.LastHeart = DateTime.Now;
                                client.ClientPoint = point;
                            }
                        }
                        else if (type== MessageType.ALARM)
                        {
                            DoSendString(msg, MessageType.ALARM);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("接收客户数据解析异常：", ex);
                    }
                });
        }

        public void Stop()
        {
            try
            {
                if (udpServer != null)
                {
                    udpServer.Client.Close();
                    udpServer.Close();
                    udpServer = null;
                }
            }
            catch (Exception ex)
            { 
            }
            try
            {
                lock (clients)
                {
                    clients.Clear();
                }
            }
            catch (Exception ex)
            {
                 
            }

        }
    }
}
