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

        public static string GetHexString(byte[] buffer,int offset,int length,bool right=true)
        {
            string str = "";
            if (right)
            {
                for (int i = offset; i < offset + length; i++)
                {
                    str += string.Format("{0:X2}", buffer[i]);
                }
            }
            else
            {
                for (int i = offset + length-1; i >= offset; i--)
                {
                    str += string.Format("{0:X2}", buffer[i]);
                }
            }

            return str;
        }

        public static byte[] ToBytesFromUint(uint idata)
        {
            byte[] bts=new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bts[i] = (byte)(0x000000FF & (idata >> (i*8)));
            }
            return bts;
        }
        public static uint ToUintFromBytes(byte[] bts)
        {
            uint data = 0x00000000;
            int min = Math.Min(4, bts.Length);
            for (int i = 0; i < min; i++)
            {
                data = data | (((uint)bts[i]) << i * 8);
            }
            return data;
        }
        public static uint ToUintFromHexString(string hexString)
        {
            byte[] bts = ToBytesFromHexString(hexString);
            return ToUintFromBytes(bts);
        }

        public static byte[] ToBytesFromHexString(string hexString)
        {
            if (hexString.Length==1)
            {
                hexString = "0" + hexString;
            }
            byte[] bts = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length-1; i+=2)
            {
                string str = hexString.Substring(i, 2);
                bts[i/2] = Convert.ToByte(str, 16);
            }
            return bts;
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
        /// <summary>
        /// 转为微耕门禁读出的卡号
        /// </summary>
        /// <param name="cardNo">原始卡号</param>
        /// <returns>微耕门禁卡号</returns>
        public static string ToWGAccessCardNo(string cardNo)
        {
            byte[] bts=ToBytesFromHexString(cardNo);
            string temp = cardNo;
            if (bts.Length>=3)
	        {
                string t1 = bts[2].ToString();
                string t2 = string.Format("{0:00000}", bts[1] * 256 + bts[0]);
                temp = t1 + t2;
                int num = int.Parse(temp);
                byte[] btss = new byte[4];
                btss[0] = (byte)((num >> 24) & 0xFF);
                btss[1] = (byte)((num >> 16) & 0xFF);
                btss[2] = (byte)((num >> 8) & 0xFF);
                btss[3] = (byte)(num & 0xFF);
                temp = GetHexString(btss, 0, 4);
	        }
            return temp;
        }

        public static byte[] GetIPBytes(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return null;
            }
            string[] ips = ip.Split('.');
            if (ips.Length!=4)
            {
                return null;
            }
            byte[] bytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                byte bt;
                if(!byte.TryParse(ips[i], out bt))
                {
                    return null;
                }
                bytes[i] = bt;
            }
            return bytes;
        }
    }
}
