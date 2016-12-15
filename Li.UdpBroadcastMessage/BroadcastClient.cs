using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Li.UdpBroadcastMessage
{
    public delegate void MessageRecieveCallBack(MessageType msgType,string msg);
    public class BroadcastClient
    {
        private UdpClient udpClient = null;
        private int broadcastPort = 56010;
        public int BroadcastPort
        {
            get { return broadcastPort; }
            set { broadcastPort = value; }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(BroadcastClient));
        private AsyncCallback RecieveCallBack = null;
        public event MessageRecieveCallBack MessageRecieved; 
        public BroadcastClient()
        {
            RecieveCallBack = new AsyncCallback(DoRecieveCallBack);
        }
        public BroadcastClient(int broadcastPort):this()
        {
            this.broadcastPort = broadcastPort;
        }
        public void Start()
        {
            if (udpClient == null)
            {
                udpClient = new UdpClient(broadcastPort);
            }
            BeginRecieve();
        }
        public void Stop()
        {
            try
            {
                udpClient.Client.Close();
                udpClient.Close();
                udpClient = null;
            }
            catch (Exception)
            {
                 
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
            }
            
        }
        private void DoRecieveCallBack(IAsyncResult ar)
        {
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
                byte[] bts = udpClient.EndReceive(ar, ref point);
                if (MessageRecieved==null)
                {
                    return;
                }
                string str = Encoding.UTF8.GetString(bts);
                int ind = str.IndexOf('.');
                MessageType type = MessageType.NONE;
                if (ind>0)
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
                if (MessageRecieved!=null)
                {
                    MessageRecieved.BeginInvoke(type, str,null,null);
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
