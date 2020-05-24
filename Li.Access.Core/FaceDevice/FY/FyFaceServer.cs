using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Li.Access.Core.FaceDevice.FY
{
    /// <summary>
    /// 富盈人脸服务端
    /// </summary>
    public class FyFaceServer
    {
        public event EventHandler<RegisterEventArgs> ClientRegisterEvent;

        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FyFaceServer));
        private TcpListener tcpListener = null;
        private bool _isOpend = false;
        public bool IsOpend
        {
            get { return _isOpend; }
        }
        private bool _isClosed = false;
        private int _port = 6000;
        private List<FyFaceObject> filterFaceObjects = null;
        private Dictionary<string, FyFaceClient> faceClients = new Dictionary<string, FyFaceClient>();
        public FyFaceServer(int port)
        {
            if (port<=0||port>=65535)
            {
                _port = 6000;
            }
            else
            {
                _port = port;
            }
        }

        public FyFaceServer(int port, bool filter): this(port)
        {
            if (filter)
            {
                filterFaceObjects = new List<FyFaceObject>();
            }
        }

        /// <summary>
        /// Filter为空表示不过滤
        /// </summary>
        /// <param name="fyFaceObjects"></param>
        public void SetFilterClients(List<FyFaceObject> fyFaceObjects=null)
        {
            lock (this)
            {
                filterFaceObjects = fyFaceObjects;
                if (filterFaceObjects==null)
                {
                    foreach (var item in faceClients)
                    {
                        item.Value.Stop();
                    }
                    faceClients.Clear();
                }
                else
                {
                    List<FyFaceClient> clients = new List<FyFaceClient>();
                    foreach (var item in faceClients)
                    {
                        var obj = filterFaceObjects.Find(m => m.deviceIp == item.Key);
                        if (obj==null)
                        {
                            clients.Add(item.Value);
                        }
                    }
                    foreach (var item in clients)
                    {
                        item.Stop();
                        faceClients.Remove(item.ip);
                    }
                    clients.Clear();
                }

            }
        }

        private void GetClient()
        {
            if (tcpListener==null|| _isClosed)
            {
                return;
            }
            tcpListener.BeginAcceptTcpClient(new AsyncCallback((o) =>
            {
                try
                {
                    TcpClient tcpClient = tcpListener.EndAcceptTcpClient(o);
                    FyFaceClient fyFaceClient = new FyFaceClient(tcpClient, this);
                    CloseClient(fyFaceClient.ip);
                    log.Info("Fy接收到客户端连接：" + fyFaceClient.ip);
                    lock (this)
                    {
                        if (filterFaceObjects!=null)
                        {
                            if (!filterFaceObjects.Exists(m => m.deviceIp == fyFaceClient.ip))
                            {
                                log.Warn("Fy客户端不是授权设备,被强制关闭：" + fyFaceClient.ip);
                                fyFaceClient.Stop();
                                return;
                            }
                        }
                        faceClients.Add(fyFaceClient.ip, fyFaceClient);
                        fyFaceClient.Start();
                    }
                }
                catch (Exception ex)
                {
                    log.Error("读取客户端异常：" + ex.Message);
                    Thread.Sleep(200);
                }
                finally
                {
                    GetClient();
                }

            }), null);
        }

        public void CloseClient(string ip)
        {
            lock (this)
            {
                if (faceClients.ContainsKey(ip))
                {
                    faceClients[ip].Stop();
                    faceClients.Remove(ip);
                    log.Info("关闭(历史)客户端：" + ip);
                }
            }
        }

        public bool Open()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, _port);
                tcpListener.Start();
                GetClient();
                _isOpend = true;
                return true;
            }
            catch (Exception ex)
            {
                log.Error("打开监听异常：", ex);
                return false;
            }
        }

        public void Close()
        {
            try
            {
                _isClosed = true;
                _isOpend = false;
                if (tcpListener != null)
                {
                    tcpListener.Server.Close();
                    tcpListener.Stop();
                }
            }
            catch (Exception ex)
            {
                log.Error("关闭服务异常：", ex);
            }
            tcpListener = null;

        }
    }
}
