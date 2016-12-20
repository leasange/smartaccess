using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Li.UdpMessageQueue
{
    /// <summary>
    /// 消费者
    /// </summary>
    public class ConsumerClient
    {
        private UdpClient udpClient = null;
        private IPEndPoint ipBrokerServer;
        private string _ipBrokerServer=null;

        public string IpBrokerServer
        {
            get { return _ipBrokerServer; }
            set 
            { 
                _ipBrokerServer = value;
                InitRemotePoint();
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(BroadcastClient));
        private AsyncCallback RecieveCallBack = null;
        private System.Timers.Timer timerSend = null;
        private string clientId = "";
        public event MessageRecieveCallBack MessageRecieved;
        public ConsumerClient()
            : this(null)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brokerServer">[IP]:[PORT]</param>
        public ConsumerClient(string brokerServer)
        {
            _ipBrokerServer = brokerServer;
            RecieveCallBack = new AsyncCallback(DoRecieveCallBack);
            clientId = Guid.NewGuid().ToString("N");
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
        public void Start()
        {
            if (udpClient == null)
            {
                udpClient = new UdpClient(UnitsHepler.GetNextAvailableNetPort(10000));
                udpClient.Client.ReceiveTimeout = 4000;
                timerSend = new System.Timers.Timer(10000);
                timerSend.Elapsed += timerSend_Elapsed;
                timerSend.Start();
                try
                {
                    SendHeartbeat();
                }
                catch (Exception ex)
                {
                    log.Error("发送心跳异常", ex);
                }
                BeginRecieve();
            }
        }

        private void timerSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                SendHeartbeat();
            }
            catch (Exception ex)
            {
                log.Error("发送心跳异常", ex);
            }
        }
        public void Stop()
        {
            try
            {
                if (udpClient!=null)
                {
                    udpClient.Client.Close();
                    udpClient.Close();
                    udpClient = null;
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (timerSend!=null)
                {
                    timerSend.Elapsed -= timerSend_Elapsed;
                    timerSend.Dispose();
                    timerSend = null;
                }

            }
            catch (Exception)
            {
                 
            }
        }

        public void SendHeartbeat()
        {
            if (udpClient != null)
            {
                byte[] bts = UnitsHepler.PacketMessage(clientId, MessageType.HEART);
                udpClient.Send(bts, bts.Length, ipBrokerServer);
            }
        }

        private void BeginRecieve()
        {
            try
            {
                udpClient.BeginReceive(RecieveCallBack, null);
            }
            catch (Exception ex)
            {
                log.Error("BeginRecieve Error:", ex);
                if (udpClient==null)
                {
                    return;
                }
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    Thread.Sleep(1400);
                    BeginRecieve();
                }));
            }
        }
        private void DoRecieveCallBack(IAsyncResult ar)
        {
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
                byte[] bts = udpClient.EndReceive(ar, ref point);
                if (MessageRecieved == null)
                {
                    return;
                }
                string str = Encoding.UTF8.GetString(bts);
                int ind = str.IndexOf('.');
                MessageType type = MessageType.NONE;
                if (ind > 0)
                {
                    string msgType = str.Substring(0, ind);

                    if (Enum.TryParse<MessageType>(msgType, out type))
                    {
                        str = str.Substring(ind + 1);
                    }
                    else
                    {
                        type = MessageType.NONE;
                    }
                }
                if (MessageRecieved != null)
                {
                    MessageRecieved.BeginInvoke(type, str, null, null);
                }
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

        public T ParseMessage<T>(string msg)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(msg);
        }
    }
}
