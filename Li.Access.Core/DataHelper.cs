using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Access.Core
{
    /// <summary>
    /// 数据帮助类
    /// </summary>
    public  class DataHelper
    {
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
    }
}
