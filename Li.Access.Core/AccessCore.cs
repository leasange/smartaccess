﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Drawing;

namespace Li.Access.Core
{
    public class AccessCore:IDisposable
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccessCore));
        public Socket socket=null;
        public List<Socket> _multisockets = new List<Socket>();
        public Exception exception;
        public AccessCore()
        { }
        /// <summary>
        /// 启动客户端服务器
        /// </summary>
        /// <param name="localPort"></param>
        /// <param name="protocol"></param>
        public bool Bind(int localPort, ProtocolType protocol = ProtocolType.Udp)
        {
            if (socket!=null)
            {
                return true;
            }
            if (protocol == ProtocolType.Udp)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, protocol);
            }
            else
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, protocol);
            }
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, localPort);
            socket.Bind(endPoint);
            return true;
        }
        public bool MultiBinds(int localPort, ProtocolType protocol = ProtocolType.Udp)
        {
            _multisockets.Clear();
            var addrs = Dns.GetHostAddresses(Dns.GetHostName());
            var addrsg = addrs.ToList().GroupBy(m => m.ToString());
            Socket s;
            foreach (var item in addrsg)
            {
                var addr = item.ToList()[0];
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (protocol == ProtocolType.Udp)
                    {
                        s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, protocol);
                    }
                    else
                    {
                        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, protocol);
                    }
                    IPEndPoint endPoint = new IPEndPoint(addr, localPort);
                    s.Bind(endPoint);
                    _multisockets.Add(s);
                }
            }
            return _multisockets.Count > 0;
        }

        public bool SendTo(byte[] datas,string ip,int port)
        {
            IPEndPoint endPoint = null;
            if (ip == "255.255.255.255")//广播
            {
                endPoint = new IPEndPoint(IPAddress.Broadcast, port);
                foreach (var item in _multisockets)
                {
                    item.EnableBroadcast = true;
                    item.ReceiveTimeout = 3000;
                    item.SendTo(datas, endPoint);
                }
            }
            else
            {
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.ReceiveTimeout = 3000;
                socket.SendTo(datas, endPoint);
            }
            string str = DataHelper.GetHexString(datas, 0, datas.Length);
            Console.WriteLine("send :" + endPoint + "=>" + str);
            return true;
        }
        public List<byte[]> RecieveFrom(int bufferLength,int maxCount=-1)
        {
            if (_multisockets.Count>0)
            {
                List<byte[]> dic = new List<byte[]>();
                List<ManualResetEvent> evets = new List<ManualResetEvent>();
                foreach (var item in _multisockets)
                {
                    ManualResetEvent evet = new ManualResetEvent(false);
                    evets.Add(evet);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        try
                        {
                            var dics = DoRecieveFrom(item, bufferLength, maxCount);
                            
                            lock (dic)
                            {
                                dic.AddRange(dics);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("结束接收！"+ex.Message);
                        }
                        finally
                        {
                            evet.Set();
                        }
                    }));
                }
                foreach (var item in evets)
                {
                    item.WaitOne(15000);
                }
                if (dic.Count==0)
                {
                    throw new Exception("未读取到数据");
                }
                return dic;
            }
            else
            {
                return DoRecieveFrom(socket, bufferLength, maxCount);
            }
        }

        private List<byte[]> DoRecieveFrom(Socket s,int bufferLength,int maxCount=-1)
        {
            List<byte[]> dic = new List<byte[]>();
            try
            {
                while (true)
                {
                    EndPoint endPoint = new IPEndPoint(IPAddress.None, 0);
                    byte[] buffer = new byte[bufferLength];
                    int count = s.ReceiveFrom(buffer, ref endPoint);

                    //IPEndPoint ipEndPoint = (IPEndPoint)endPoint;
                    dic.Add(buffer);
                    if (maxCount > 0 && dic.Count >= maxCount)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("读取异常或者结束：", ex);
                if (dic.Count==0)
                {
                    throw ex;
                }
            }
            return dic;
        }

        public virtual void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (socket!=null)
            {
                socket.Dispose();
                socket = null;
            }
            if (_multisockets.Count>0)
            {
                foreach (var item in _multisockets)
                {
                    item.Dispose();
                }
                _multisockets.Clear();
            }
        }
    }
    public enum AccessState
    {
        None = -1,//未知空状态
        Init = 0, //初始未授权状态
        Private = 1,//已授权
        PrivateError = 2,//授权失败
        Canceled = 3,//已取消授权
        PrivateExpire = 4,//授权结束/已过期
        RequestCancel = 9,//申请取消授权
    }
    public class AccessStateItem
    {
        public AccessState state;
        public Color StateColor
        {
            get
            {
                switch (state)
                {
                    case AccessState.Init:
                        return Color.Black;
                        break;
                    case AccessState.Private:
                        return Color.Green;
                        break;
                    case AccessState.PrivateError:
                        return Color.Red;
                        break;
                    case AccessState.Canceled:
                        return Color.Gray;
                        break;
                    case AccessState.PrivateExpire:
                        return Color.SlateGray;
                        break;
                    case AccessState.RequestCancel:
                        return Color.YellowGreen;
                        break;
                    default:
                        break;
                }
                return Color.Black;
            }
        }
        public string Text
        {
            get
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            switch (state)
            {
                case AccessState.None:
                    return "----";
                case AccessState.Init:
                    return "待授权";
                    break;
                case AccessState.Private:
                    return "已授权";
                    break;
                case AccessState.PrivateError:
                    return "授权失败";
                    break;
                case AccessState.Canceled:
                    return "已取消授权";
                    break;
                case AccessState.PrivateExpire:
                    return "授权已过期";
                    break;
                case AccessState.RequestCancel:
                    return "请求取消授权";
                    break;
                default:
                    break;
            }
            return state.ToString();
        }

        public static List<AccessStateItem> GetStatesList()
        {
            List<AccessStateItem> list = new List<AccessStateItem>();
            var arr = Enum.GetValues(typeof(AccessState));
            foreach (var item in arr)
            {
                AccessStateItem asi = new AccessStateItem { state = (AccessState)item };
                if (asi.state== AccessState.None)
                {
                    list.Insert(0, asi);
                }
                else list.Add(asi);
            }
            return list;
        }
    }

    public class AutoAccessSys
    {
        public static Dictionary<string, string> SysNames = new Dictionary<string, string>();
        static AutoAccessSys()
        {
            SysNames.Add("PUBLISH_SYS", "信息发布系统");
            SysNames.Add("SMART_ACCESS", "智能门禁系统");
        }
    }
}
