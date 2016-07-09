using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Access.Core
{
    /// <summary>
    /// 数据帮助类
    /// </summary>
    public  class DataHelper
    {
        private static object lockObj = new object();
        public static byte[] GetBytes(Type structor,object obj)
        {
            int size = Marshal.SizeOf(structor);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            byte[] buffer = new byte[size];
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, buffer, 0, size);
            Marshal.FreeHGlobal(ptr);
            return buffer;
        }
        public static void ZeroBuffer(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = 0;
            }
        }
        public static string GetIP(byte[] buffer, int offset)
        {
            string str = string.Format("{0}.{1}.{2}.{3}", buffer[offset], buffer[offset + 1], buffer[offset + 2], buffer[offset + 3]);
            return str;
        }

        public static byte[] GetBytes(string str,params char[] split)
        {
            string[] strs = str.Split(split);
            List<byte> bts = new List<byte>();
            foreach (var item in strs)
            {
                bts.Add(byte.Parse(item));
            }
            return bts.ToArray();
        }

        public static string GetHexString(byte[] buffer,int offset,int length)
        {
            string str = "";
            for (int i = offset; i < offset+length; i++)
            {
                str += string.Format("{0:X2}", buffer[i]);
            }
            return str;
        }
        public static byte GetFromBCD(byte bcd)
        {
            return (byte)(((bcd >> 4) * 10) + (bcd & 0x0F));
        }

        public static byte ToByteBCD(int byteVal)
        {
            int h = (int)(byteVal / 10);
            int l = byteVal - h * 10;
            byte bt = (byte)((h << 4) + l);
            return bt;
        }

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
    }
}
