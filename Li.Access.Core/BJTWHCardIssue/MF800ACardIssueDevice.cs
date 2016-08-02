using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Access.Core.BJTWHCardIssue
{
    /// <summary>
    /// MF800A发卡器
    /// </summary>
    public class MF800ACardIssueDevice : ICardIssueDevice
    {
        [DllImport("kernel32.dll")]
        static extern void Sleep(int dwMilliseconds);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int lib_ver(ref uint pVer);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_init_com(int port, int baud);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_ClosePort();

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_antenna_sta(short icdev, byte mode);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_init_type(short icdev, byte type);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_request(short icdev, byte mode, ref ushort pTagType);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_anticoll(short icdev, byte bcnt, IntPtr pSnr, ref byte pRLength);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_select(short icdev, IntPtr pSnr, byte srcLen, ref sbyte Size);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_halt(short icdev);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_authentication2(short icdev, byte mode, byte secnr, IntPtr key);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_initval(short icdev, byte adr, Int32 value);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_increment(short icdev, byte adr, Int32 value);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_decrement(short icdev, byte adr, Int32 value);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_readval(short icdev, byte adr, ref Int32 pValue);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_read(short icdev, byte adr, IntPtr pData, ref byte pLen);

        [DllImport("BJTWH_SDK\\MasterRD.dll")]
        static extern int rf_M1_write(short icdev, byte adr, IntPtr pData);

        private bool _isOpen = false;
        public void OpenCom(int port, ComBuad baud)
        {
            if (!_isOpen)
            {
                int status = rf_init_com(port, (int)baud);
                if (0 == status)
                {
                    _isOpen = true;
                }
                else
                {
                    throw new Exception("打开串口失败，port=" + port);
                }
            }
        }

        public byte[] ReadCard()
        {
            if (!_isOpen)
            {
                throw new Exception("还未打开串口");
            }

            short icdev = 0x0000;
            int status;
            byte type = (byte)'A';//mifare one 卡询卡方式为A
            byte mode = 0x52;
            ushort TagType = 0;
            byte bcnt = 0x04;//mifare 卡都用4
            IntPtr pSnr;
            byte len = 255;
            sbyte size = 0;
            byte[] rets = null;

            pSnr = Marshal.AllocHGlobal(1024);

            for (int i = 0; i < 2; i++)
            {
                status = rf_antenna_sta(icdev, 0);//关闭天线
                if (status != 0)
                    continue;

                Sleep(20);
                status = rf_init_type(icdev, type);
                if (status != 0)
                    continue;

                Sleep(20);
                status = rf_antenna_sta(icdev, 1);//启动天线
                if (status != 0)
                    continue;

                Sleep(50);
                status = rf_request(icdev, mode, ref TagType);//搜寻所有的卡
                if (status != 0)
                    continue;

                status = rf_anticoll(icdev, bcnt, pSnr, ref len);//返回卡的序列号
                if (status != 0)
                    continue;

                status = rf_select(icdev, pSnr, len, ref size);//锁定一张ISO14443-3 TYPE_A 卡
                if (status != 0)
                    continue;

                byte[] szBytes = new byte[len];

                for (int j = 0; j < len; j++)
                {
                    szBytes[j] = Marshal.ReadByte(pSnr, j);
                }
                // 
                //                 String m_cardNo = String.Empty;
                // 
                //                 for (int q = 0; q < len; q++)
                //                 {
                //                     m_cardNo += byteHEX(szBytes[q]);
                //                 }

                rets = new byte[len];
                Array.Copy(szBytes, rets, len);
                break;
                //微耕门禁转换
                //string no = szBytes[2].ToString() + (szBytes[1] * 256 + szBytes[0]).ToString();
            }
            Marshal.FreeHGlobal(pSnr);
            return rets;
        }

        public string ReadCardX()
        {
            byte[] bts = ReadCard();
            if (bts==null)
            {
                return null;
            }
            return DataHelper.GetHexString(bts, 0, bts.Length);
        }
        public void Close()
        {
            if (_isOpen)
            {
                rf_ClosePort();
                _isOpen = false;
            }
        }

        public void Dispose()
        {
            Close();
        }


        public bool IsOpen()
        {
            return _isOpen;
        }

    }
}
