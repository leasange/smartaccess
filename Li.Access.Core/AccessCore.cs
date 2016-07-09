using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Li.Access.Core
{
    public class AccessCore:IDisposable
    {
        public Socket socket;
        public Exception exception;
        public AccessCore()
        { }
        /// <summary>
        /// 启动客户端服务器
        /// </summary>
        /// <param name="localPort"></param>
        /// <param name="protocol"></param>
        public bool Bind(int localPort,ProtocolType protocol = ProtocolType.Udp)
        {
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
        public bool SendTo(byte[] datas,string ip,int port)
        {
            if (socket != null)
            {
               // SocketFlags flag = SocketFlags.None;
                if (ip=="255.255.255.255")
                {
                    socket.EnableBroadcast = true;
                }
                socket.ReceiveTimeout = 3000;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                int count = socket.SendTo(datas, endPoint);
                return count == datas.Length;
            }
            return false;
        }
        public Dictionary<IPEndPoint,byte[]> RecieveFrom(int bufferLength,int maxCount=-1)
        {
            Dictionary<IPEndPoint, byte[]> dic = new Dictionary<IPEndPoint, byte[]>();
            try
            {
                while (true)
                {
                    EndPoint endPoint = new IPEndPoint(IPAddress.None, 0);
                    byte[] buffer = new byte[bufferLength];
                    int count = socket.ReceiveFrom(buffer, ref endPoint);
                    IPEndPoint ipEndPoint = (IPEndPoint)endPoint;
                    dic.Add(ipEndPoint, buffer);
                    if (maxCount>0&&dic.Count>=maxCount)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dic;
        }
        public byte[] RecieveFrom(ref string ip,ref int port)
        {
            EndPoint endPoint=new IPEndPoint(IPAddress.None,0);
            byte[] buffer=new byte[1000];
            int count= socket.ReceiveFrom(buffer, ref endPoint);
            IPEndPoint ipEndPoint = (IPEndPoint)endPoint;
            ip = ipEndPoint.Address.ToString();
            port = ipEndPoint.Port;
            return buffer;
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
        }
    }
}
