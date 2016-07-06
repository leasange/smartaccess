using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Access.Core.WGAccesses
{
    public class WGAccess :AccessCore, IAccessCore
    {
        public Dictionary<IPEndPoint, byte[]> WGRecieveFrom(int maxCount = -1)
        {
           return this.RecieveFrom(64, maxCount);
        }
        public List<WGPacket> WGRecievePacketAddClose(int maxCount = -1)
        {
            try
            {
                Dictionary<IPEndPoint, byte[]> dics = WGRecieveFrom(maxCount);
                List<WGPacket> list = new List<WGPacket>();
                if (dics.Count > 0)
                {
                    foreach (var item in dics)
                    {
                        WGPacket p = ToWGPacket(item.Value);
                        list.Add(p);
                    }
                }
                return list;
            }
            finally
            {
                this.Close();
            }

        }
        private bool DoSend(WGPacket packet,string controllerIp=null)
        {
            this.Bind(61003);
            if (string.IsNullOrWhiteSpace(controllerIp))
            {
                controllerIp = "255.255.255.255";
            }
            bool ret = this.SendTo(DataHelper.GetBytes(typeof(WGPacket), packet), controllerIp, 60000);
            return ret;
        }

        private WGPacket ToWGPacket(byte[] buffer)
        {
            IntPtr ptr = Marshal.AllocHGlobal(64);
            Marshal.Copy(buffer, 0, ptr, 64);
            WGPacket p = (WGPacket)Marshal.PtrToStructure(ptr, typeof(WGPacket));
            Marshal.FreeHGlobal(ptr);
            return p;
        }
        public List<Controller> SearchController()
        {
            List<Controller> list = new List<Controller>();
            try
            {
                WGPacket packet = new WGPacket(0x94);
                if (DoSend(packet))
                {
                    Dictionary<IPEndPoint, byte[]> dics = this.RecieveFrom(64);
                    if (dics.Count > 0)
                    {
                        foreach (var item in dics)
                        {
                            WGPacket p = ToWGPacket(item.Value);
                            Controller ctrl = p.ToController();
                            if (ctrl != null)
                            {
                                list.Add(ctrl);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this.Close();
            }
            return list;
        }
        public void SetControllerIP(Controller controller)
        {
            WGPacket packet = new WGPacket(0x96);
            packet.SetControllerIP(controller);
            DoSend(packet);
            Close();
        }
        public ControllerState GetControllerState(Controller controller)
        {
            WGPacket packet = new WGPacket(0x20);
            packet.SetDevSn(controller.sn);
            DoSend(packet, controller.ip);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count==1)
            {
              return  packets[0].ToControllerState();
            }
            return null;
        }
        public DateTime GetControllerTime(Controller controller)
        {
            WGPacket packet = new WGPacket(0x32);
            packet.SetDevSn(controller.sn);
            DoSend(packet, controller.ip);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].ToDateTime();
            }
            return DateTime.Now;
        }


        public bool SetControllerTime(Controller controller, DateTime dateTime)
        {
            WGPacket packet = new WGPacket(0x30);
            packet.SetDevSn(controller.sn);
            packet.SetDateTime(dateTime);
            DoSend(packet, controller.ip);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                DateTime dt= packets[0].ToDateTime();
                return dt == dateTime;
            }
            return false;
        }


        public ControllerState GetControllerRecord(Controller controller, long recordIndex)
        {
            WGPacket packet = new WGPacket(0xB0);
            packet.SetDevSn(controller.sn);
            packet.SetRecordIndex(recordIndex);
            DoSend(packet, controller.ip);
            List<WGPacket> packets = WGRecievePacketAddClose(1);
            if (packets.Count == 1)
            {
                return packets[0].ToControllerState(true);
            }
            return null;
        }
    }
    /// <summary>
    /// WG请求包
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WGPacket
    {
        public byte type;				  //类型
        public byte functionID;		      //功能号
        public ushort reserved;              //保留
        public uint iDevSn;               //设备序列号 4字节
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] data;              //32字节的数据
        public uint sequenceId;            //数据包流水号
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] extern_data;        //第二版本 扩展20字节
        public WGPacket(byte fucId = 0x94)
        {
            type = 0x17;
            functionID = fucId;
            reserved = 0;
            iDevSn = 0;
            data = new byte[32];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            sequenceId = 0;
            extern_data = new byte[20];
            for (int i = 0; i < extern_data.Length; i++)
            {
                extern_data[i] = 0;
            }
        }

        public Controller ToController()//转为控制器（搜索）结果
        {
            Controller ctrl = new Controller();
            ctrl.sn = iDevSn.ToString();
            if (ctrl.sn[0]=='1')
            {
                ctrl.doorType = ControllerDoorType.OneDoorTwoDirections;
            }
            else if (ctrl.sn[0]=='2')
            {
                ctrl.doorType = ControllerDoorType.TwoDoorsTwoDirections;
            }
            else if (ctrl.sn[0] == '4')
            {
                ctrl.doorType = ControllerDoorType.FourDoorsOneDirection;
            }
            ctrl.ip = DataHelper.GetIP(data, 0);
            ctrl.mask = DataHelper.GetIP(data, 4);
            ctrl.gateway = DataHelper.GetIP(data, 8);
            ctrl.mac = DataHelper.GetHexString(data, 12, 6);
            ctrl.driverVersion = DataHelper.GetFromBCD(data[18]) + "." + DataHelper.GetFromBCD(data[19]);
            int year = DataHelper.GetFromBCD(data[20]) * 100 + DataHelper.GetFromBCD(data[21]);
            ctrl.driverReleaseTime = new DateTime(year, DataHelper.GetFromBCD(data[22]), DataHelper.GetFromBCD(data[23]));
            return ctrl;
        }
        public void SetControllerIP(Controller controller)//设置控制器的IP
        {
            SetDevSn(controller.sn);
            byte[] ips = DataHelper.GetBytes(controller.ip, '.');
            ips.CopyTo(data, 0);
            byte[] mask = DataHelper.GetBytes(controller.mask, '.');
            for (int i = 0; i < mask.Length; i++)
            {
                data[4 + i] = mask[i];
            }
            byte[] gateway = DataHelper.GetBytes(controller.gateway, '.');
            for (int i = 0; i < gateway.Length; i++)
            {
                data[8 + i] = gateway[i];
            }
            data[12] = 0x55;
            data[13] = 0xAA;
            data[14] = 0xAA;
            data[15] = 0x55;
        }
        public void SetDevSn(string sn)
        {
            iDevSn = uint.Parse(sn);
        }

        public ControllerState ToControllerState(bool isRecord=false)
        {
            ControllerState state = new ControllerState();

            state.sn = iDevSn.ToString();//控制器序列号
            state.lastRecordIndex = data[3] * 256u * 256u * 256u + data[2] * 256u * 256u + data[1] * 256u + data[0];//最后一条记录的索引号(=0表示没有记录)
            state.recordType = (RecordType)(data[4]);
            state.isAllowValid = data[5] == 1;//有效性(0 表示不通过:false, 1表示通过:true)
            state.doorNum = data[6];//门号(1,2,3,4)
            state.isEnterDoor = data[7] == 1;//进门/出门(1表示进门:true, 2表示出门:false)
            state.cardOrNoNumber = (data[11] * 256u * 256u * 256u + data[10] * 256u * 256u + data[9] * 256u + data[8]).ToString();//卡号(类型是刷卡记录时)或编号(其他类型记录)
            state.recordTime = new DateTime(
                DataHelper.GetFromBCD(data[12]) * 100 + DataHelper.GetFromBCD(data[13]),
                DataHelper.GetFromBCD(data[14]),
                DataHelper.GetFromBCD(data[15]),
                DataHelper.GetFromBCD(data[16]),
                DataHelper.GetFromBCD(data[17]),
                DataHelper.GetFromBCD(data[18])
                );//刷卡时间:年月日时分秒 (采用BCD码)见设置时间部分的说明
            state.reasonNo = (RecordReasonNo)data[19];
            if (!isRecord)
            {
                state.isOpenDoorOfLock1 = data[20] == 1;//   1号门门磁(0表示关上:false, 1表示打开:true)
                state.isOpenDoorOfLock2 = data[21] == 1;//2号门门磁(0表示关上, 1表示打开)
                state.isOpenDoorOfLock3 = data[22] == 1;//3号门门磁(0表示关上, 1表示打开)
                state.isOpenDoorOfLock4 = data[23] == 1;//4号门门磁(0表示关上, 1表示打开)
                state.isOpenDoorOfButton1 = data[24] == 1;//1号门按钮(0表示松开, 1表示按下)
                state.isOpenDoorOfButton2 = data[25] == 1;//2号门按钮(0表示松开, 1表示按下)
                state.isOpenDoorOfButton3 = data[26] == 1;//3号门按钮(0表示松开, 1表示按下)
                state.isOpenDoorOfButton4 = data[27] == 1;//4号门按钮(0表示松开, 1表示按下)
                state.troubleNum = data[28];//故障号， 0 无故障，不等于0, 有故障(先重设时间, 如果还有问题, 则要返厂家维护)
                state.controllerCurTime = new DateTime(
                    ((int)(DateTime.Now.Year / 100)) * 100 + DataHelper.GetFromBCD(extern_data[7]),
                    DataHelper.GetFromBCD(extern_data[8]),
                    DataHelper.GetFromBCD(extern_data[9]),
                    DataHelper.GetFromBCD(data[29]),
                    DataHelper.GetFromBCD(data[30]),
                    DataHelper.GetFromBCD(data[31])
                    );//控制器当前时间
                state.seqNum = sequenceId;//流水号
                state.relayState = new bool[8];//0-8,表示1-8号门继电器状态，true 门开锁， false 门上锁
                for (int i = 0; i < 8; i++)
                {
                    state.relayState[i] = ((extern_data[5] >> i) & (byte)0x01) == 1;
                }

                state.isFireAlarm = ((extern_data[6] >> 1) & (byte)0x01) == 1;//是否火警
                state.isForceLock = (extern_data[6] & (byte)0x01) == 1;//是否强制锁门
            }
            return state;
        }
        /// <summary>
        /// 转为获取控制器时间
        /// </summary>
        /// <returns>控制器时间</returns>
        public DateTime ToDateTime()
        {
            return new DateTime(
                DataHelper.GetFromBCD(data[0]) * 100 + DataHelper.GetFromBCD(data[1]),
                DataHelper.GetFromBCD(data[2]),
                DataHelper.GetFromBCD(data[3]),
                DataHelper.GetFromBCD(data[4]),
                DataHelper.GetFromBCD(data[5]),
                DataHelper.GetFromBCD(data[6])
                );
        }

        public void SetDateTime(DateTime dateTime)
        {
            data[0] = DataHelper.ToByteBCD(dateTime.Year/100);
            data[1] = DataHelper.ToByteBCD(dateTime.Year - (dateTime.Year / 100)*100);
            data[2] = DataHelper.ToByteBCD(dateTime.Month);
            data[3] = DataHelper.ToByteBCD(dateTime.Day);
            data[4] = DataHelper.ToByteBCD(dateTime.Hour);
            data[5] = DataHelper.ToByteBCD(dateTime.Minute);
            data[6] = DataHelper.ToByteBCD(dateTime.Second);
        }
        //设置索引号
        public void SetRecordIndex(long recordIndex)
        {
            uint u = (uint)recordIndex;
            data[0] = (byte)(u & 0x000000ff);
            data[1] = (byte)((u>>8) & 0x000000ff);
            data[2] = (byte)((u >> 16) & 0x000000ff);
            data[3] = (byte)((u >> 24) & 0x000000ff);
        }
    }
}
