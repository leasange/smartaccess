﻿//-------
//门禁控制内核
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Li.Access.Core
{
    public interface IAccessCore:IDisposable
    {
        /// <summary>
        /// 搜索网内控制器
        /// </summary>
        /// <returns>控制器列表</returns>
        List<Controller> SearchController();
        /// <summary>
        /// 设置控制器IP
        /// </summary>
        /// <param name="ctroller"></param>
        void SetControllerIP(Controller controller);
        /// <summary>
        /// 获取控制器状态（实时监控用）
        /// </summary>
        /// <param name="controller">待获取的控制器参数</param>
        /// <returns>返回控制器状态</returns>
        ControllerState GetControllerState(Controller controller);
        /// <summary>
        /// 获取控制器时间
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>控制器时间</returns>
        DateTime GetControllerTime(Controller controller);
        /// <summary>
        /// 设置控制器时间
        /// </summary>
        /// <param name="controller">待设置的控制器</param>
        /// <param name="dateTime">设置的时间</param>
        /// <returns>成功与否</returns>
        bool SetControllerTime(Controller controller, DateTime dateTime);
        /// <summary>
        /// 获取控制器指定索引的记录
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="recordIndex">记录的索引</param>
        /// <returns>返回记录</returns>
        ControllerState GetControllerRecord(Controller controller, long recordIndex);

        /// <summary>
        /// 开始读取记录
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>是否成功</returns>
        bool BeginReadRecord(Controller controller);
        /// <summary>
        /// 读取下一条未读记录
        /// </summary>
        /// <returns>记录结果,recordType=RecordType.NoRecord 或者null 表示结束</returns>
        ControllerState ReadNextRecord();
        /// <summary>
        /// 结束读取记录
        /// </summary>
        void EndReadRecord();

        /// <summary>
        /// 设置已读过记录的索引号
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="recordIndex">索引号</param>
        /// <returns>成功与否</returns>
        bool SetControllerReadedIndex(Controller controller, long recordIndex);
        /// <summary>
        /// 获取已读过记录的索引号
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>索引号,没有为0</returns>
        long GetControllerReadedIndex(Controller controller);
        /// <summary>
        /// 远程开门
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="doorNum">门编号：1-4</param>
        /// <returns>成功与否</returns>
        bool OpenRemoteControllerDoor(Controller controller, int doorNum);

        /// <summary>
        /// 权限添加或修改
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="cardNum">卡号</param>
        /// <param name="startTime">起始时间：(年月日) 20100101 >2000年</param>
        /// <param name="endTime">截止日期(年月日) 20291231</param>
        /// <param name="doorNumAuthorities">每个门控制权限：<第一个门号，第二个该时间段的权限>，true 表示允许通过，false表示禁止通过</param>
        /// <param name="password">用户设置的密码【启用了密码键盘才有效】，密码最大长度为6位数字(也就是最大为999999)(如果有要求时设置. 否则设为0)缺省值: 345678</param>
        /// <returns>成功与否</returns>
        bool AddOrModifyAuthority(Controller controller, string  hexCardNum, DateTime startTime, DateTime endTime, Dictionary<int, int> doorNumAuthorities,int password=0);
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="hexCardNum">卡号</param>
        /// <returns>成功与否</returns>
        bool DeleteAuthority(Controller controller, string hexCardNum);
        /// <summary>
        /// 设置门的控制方式
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="doorNum">门号</param>
        /// <param name="ctrlStyle">控制方式</param>
        /// <param name="delaySecond">延时时间</param>
        /// <returns>成功与否</returns>
        bool SetDoorControlStyle(Controller controller, int doorNum, DoorControlStyle ctrlStyle, int delaySecond = 3);

        /// <summary>
        /// 权限清空
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>成功与否</returns>
        bool ClearAuthority(Controller controller);
        /// <summary>
        /// 设置接收服务器的IP和端口
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <returns>成功与否</returns>
        bool SetReceiveServer(Controller controller, string ip, int port);
        /// <summary>
        /// 获取接收服务器的IP和端口
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="ip">返回IP</param>
        /// <param name="port">返回 端口</param>
        /// <returns>成功与否</returns>
        bool GetReceiveServer(Controller controller, ref string ip, ref int port);
        /// <summary>
        /// 设置时段号
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="tsNum">时段号参数</param>
        /// <returns>成功与否</returns>
        bool SetTimeScales(Controller controller,TimeScaleNum tsNum);

        /// <summary>
        /// 清除时段
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>成功与否</returns>
        bool ClearTimeScales(Controller controller);

        bool SetHoliday(Controller controller,HolidayPrm holiday);

        /// <summary>
        /// 清除定时任务
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>成功与否</returns>
        bool ClearTimeTask(Controller controller);
        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="task">任务</param>
        /// <returns>成功与否</returns>
        bool AddTimeTask(Controller controller, TimeTask task);
        /// <summary>
        /// 设置超级密码（密码缺失，可做清除使用）
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="doorIndex">门号</param>
        /// <param name="pwds">密码列表</param>
        /// <returns>成功与否</returns>
        bool SetSuperPwds(Controller controller, int doorIndex, List<string> pwds);
        /// <summary>
        /// 报警参数设置
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="setting">报警参数</param>
        /// <returns>成功与否</returns>
        bool SetAlarmParamsSetting(Controller controller, AlarmParamsSetting setting);
        /// <summary>
        /// 设置扩展卡联动
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="setting">联动端口设置</param>
        /// <returns>成功与否</returns>
        bool SetAlarmConnectPortSetting(Controller controller, AlarmConnectPortSetting setting);

        /// <summary>
        /// 设置是否记录门磁
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="record">true 记录，false 不记录</param>
        /// <returns>成功与否</returns>
        bool SetRecordButtonRecords(Controller controller, bool record);
    }
    /// <summary>
    /// 时间段参数
    /// </summary>
    public class TimeScaleNum
    {
        public int Num;//时段号
        public int NextNum = 1;//下一时段号
        public DateTime startDate;//开始日期
        public DateTime endDate;//结束日期
        public bool[] weekDaysEnable = new bool[7];
        public List<TimeScale> timeScales = new List<TimeScale>();
    }
    public class HolidayPrm
    {
//         = 0x01  添加假期 [不能开门]
//         = 0x02  添加必须上班时间[允许开门]
//         = 0xA5  清空假期
        public bool IsOnDuty=false;
        public bool IsClear = false;
        public DateTime startDate;
        public DateTime endDate;
    }
    /// <summary>
    /// 定时任务参数
    /// </summary>
    public class TimeTask
    {
        public string no;//任务编号
        public DateTime startDate;//开始时间
        public DateTime endDate;//结束时间
        public bool[] weekDaysEnable = new bool[7];//星期激活
        public TimeSpan actionTime;//触发时间
        public List<byte> doorIndexs = new List<byte>();//适用门号
        public byte ctrlStyle;//控制方式
        public byte cardCount=2;//选填，只有在控制方式为8时设置, 此门多卡要求的卡数量
    }
    public struct TimeScale
    {
        public TimeSpan start;
        public TimeSpan end;
    }
    public enum DoorControlStyle
    {
        Online,//在线
        AlwaysOpen,//常开
        AlwaysClose//常关
    }
    public enum ControllerDoorType
    {
        OneDoorTwoDirections,//单门双向
        TwoDoorsTwoDirections,//双门双向
        FourDoorsOneDirection,//四门单向
        Elevator,//电梯控制器
    }
    /// <summary>
    /// 记录类型
    /// </summary>
    public enum RecordType
    {
        NoRecord=0,//  0=无记录
        CardRecord,//1=刷卡记录
        ProRecord,// 2=门磁,按钮, 设备启动, 远程开门记录
        AlarmRecord,//3=报警记录
        CoveredRecord = 0xFF,//记录被覆盖
    }
    /// <summary>
    /// 刷卡记录原因代码
    /// </summary>
    public enum RecordReasonNo
    {
        Swipe = 1,//+E36D30D2:D2:E38	刷卡开门
        Reserved2,
        Reserved3,
        Reserved4,
        DeniedAccessPCControl,//	刷卡禁止通过: 电脑控制
        DeniedAccessNoPRIVILEGE,//	刷卡禁止通过: 没有权限
        DeniedAccessWrongPASSWORD,//	刷卡禁止通过: 密码不对
        DeniedAccessAntiBack,//	刷卡禁止通过: 反潜回
        DeniedAccessMoreCards,//	刷卡禁止通过: 多卡
        DeniedAccessFirstCardOpen,//	刷卡禁止通过: 首卡
        DeniedAccessDoorSetNC,//	刷卡禁止通过: 门为常闭
        DeniedAccessInterLock,//	刷卡禁止通过: 互锁
        DeniedAccessLimitedTimes,//	刷卡禁止通过: 受刷卡次数限制
        Reserved14,
        DeniedAccessInvalidTimezone,//	刷卡禁止通过: 卡过期或不在有效时段
        Reserved16,
        Reserved17,
        DeniedAccess,//刷卡禁止通过: 原因不明
        Reserved19,
        PushButton,//	按钮开门
        Reserved21,
        Reserved22,
        DoorOpen,//	门打开[门磁信号]
        DoorClosed,//	门关闭[门磁信号]
        SuperPasswordOpenDoor,//	超级密码开门
        Reserved26,
        Reserved27,
        ControllerPowerOn,//	控制器上电
        ControllerReset,//	控制器复位
        Reserved30,
        PushButtonInvalidForcedLock,//	按钮不开门: 强制关门
        PushButtonInvalidNotOnLine,//	按钮不开门: 门不在线
        PushButtonInvalidInterLock,//	按钮不开门: 互锁
        Threat,//	胁迫报警
        Reserved35,
        Reserved36,
        OpenTooLong,//	门长时间未关报警[合法开门后]
        ForcedOpen,//	强行闯入报警
        Fire,//	火警
        ForcedClose,//	强制关门
        GuardAgainstTheft,//	防盗报警
        H7X24HourZone,//	烟雾煤气温度报警
        EmergencyCall,//	紧急呼救报警
        RemoteOpenDoor,//	操作员远程开门
        RemoteOpenDoorByUSBReader,//	发卡器确定发出的远程开门
    }
    /// <summary>
    /// 报警联动选项
    /// </summary>
    public enum AlarmConnectItem
    {
        KeepState=0,//保持状态一致
        FixedTime,//门动作后, 只输出固定延时
    }
    /// <summary>
    /// 报警参数设置
    /// </summary>
    public class AlarmParamsSetting
    {
        public bool EnableForcePwdAlarm = false;//胁迫报警
        public bool EnableUnClosed = false;//门长时间未关
        public bool EnableForceAccess = false;//强行闯入
        public bool EnableForceCloseDoor = false;//强行关门
        public bool EnableInvalidCard = false;//无效刷卡
        public bool EnableFire = false;//火警
        public bool EnableSteal = false;//防盗报警
        public bool EnableForceWithCard = false;//胁迫报警必须刷合法卡
        public string IForcePwd = "0";//胁迫密码
    }
    /// <summary>
    /// 报警输出端口设置参数
    /// </summary>
    public class AlarmConnectPortSetting
    {
        public int IConnectPort = 0;//输出端口 (值范围: 1,2,3,4)
        public int ActionDoorIndex = 0;//触发源门序号 0  无效 1= 一号门 2= 二号门 3= 三号门 4= 四号门
        public int FixedDelayTime = 10;//固定延时时长 (秒)
        public bool ForcePwdEvent = false;//胁迫报警 (0=不触发; 1= 触发)
        public bool UnClosedTimeEvent = false;//门长时间未关报警(合法开门后) (0=不触发; 1= 触发)
        public bool ForceAccessEvent = false;//强行闯入(0=不触发; 1= 触发)
        public bool ForceLockDoorEvent = false;//强制锁门 (0=不触发; 1= 触发)
        public bool InvalidCardEvent = false;//无效刷卡 (0=不触发; 1= 触发) 
        public bool FireEvent = false;//火警 (0=不触发; 1= 触发) 
        public bool DoorRelayActionEvent = false;//门的继电器动作联动 (0=不触发; 1= 触发),[独立事件, 一旦选中, 其他触发事件不起作用.  这时指定门有合法刷卡开门, 相应输出端口也动作固定时长(触发源为1-4] 
        public AlarmConnectItem ConnectItem = AlarmConnectItem.KeepState;//联动选项   =0 保持状态一致 =1 门动作后, 只输出固定延时

    }

    public class AccessHelper
    {
        public static string GetRecordReasonString(RecordReasonNo reason)
        {
            string str = "未知";
            switch (reason)
            {
                case RecordReasonNo.Swipe:
                    str = "刷卡开门";
                    break;
                case RecordReasonNo.Reserved2:
                    break;
                case RecordReasonNo.Reserved3:
                    break;
                case RecordReasonNo.Reserved4:
                    break;
                case RecordReasonNo.DeniedAccessPCControl:
                    str = "刷卡禁止通过:电脑控制";
                    break;
                case RecordReasonNo.DeniedAccessNoPRIVILEGE:
                    str = "刷卡禁止通过:没有权限";
                    break;
                case RecordReasonNo.DeniedAccessWrongPASSWORD:
                    str = "刷卡禁止通过:密码不对";
                    break;
                case RecordReasonNo.DeniedAccessAntiBack:
                    str = "刷卡禁止通过:反潜回";
                    break;
                case RecordReasonNo.DeniedAccessMoreCards:
                    str = "刷卡禁止通过:多卡";
                    break;
                case RecordReasonNo.DeniedAccessFirstCardOpen:
                    str = "刷卡禁止通过:首卡";
                    break;
                case RecordReasonNo.DeniedAccessDoorSetNC:
                    str = "刷卡禁止通过:门为常闭";
                    break;
                case RecordReasonNo.DeniedAccessInterLock:
                    str = "刷卡禁止通过:互锁";
                    break;
                case RecordReasonNo.DeniedAccessLimitedTimes:
                    str = "刷卡禁止通过:受刷卡次数限制";
                    break;
                case RecordReasonNo.Reserved14:
                    break;
                case RecordReasonNo.DeniedAccessInvalidTimezone:
                    str = "刷卡禁止通过:卡过期或不在有效时段";
                    break;
                case RecordReasonNo.Reserved16:
                    break;
                case RecordReasonNo.Reserved17:
                    break;
                case RecordReasonNo.DeniedAccess:
                    str = "刷卡禁止通过:原因不明";
                    break;
                case RecordReasonNo.Reserved19:
                    break;
                case RecordReasonNo.PushButton:
                    str = "按钮开门";
                    break;
                case RecordReasonNo.Reserved21:
                    break;
                case RecordReasonNo.Reserved22:
                    break;
                case RecordReasonNo.DoorOpen:
                    str = "门打开:门磁信号";
                    break;
                case RecordReasonNo.DoorClosed:
                    str = "门关闭:门磁信号";
                    break;
                case RecordReasonNo.SuperPasswordOpenDoor:
                    str = "超级密码开门";
                    break;
                case RecordReasonNo.Reserved26:
                    break;
                case RecordReasonNo.Reserved27:
                    break;
                case RecordReasonNo.ControllerPowerOn:
                    str = "控制器上电";
                    break;
                case RecordReasonNo.ControllerReset:
                    str = "控制器复位";
                    break;
                case RecordReasonNo.Reserved30:
                    break;
                case RecordReasonNo.PushButtonInvalidForcedLock:
                    str = "按钮不开门:强制关门";
                    break;
                case RecordReasonNo.PushButtonInvalidNotOnLine:
                    str="按钮不开门:门不在线";
                    break;
                case RecordReasonNo.PushButtonInvalidInterLock:
                    str = "按钮不开门:互锁";
                    break;
                case RecordReasonNo.Threat:
                    str = "胁迫报警";
                    break;
                case RecordReasonNo.Reserved35:
                    break;
                case RecordReasonNo.Reserved36:
                    break;
                case RecordReasonNo.OpenTooLong:
                    str = "门长时间未关报警[合法开门后]";
                    break;
                case RecordReasonNo.ForcedOpen:
                    str = "强行闯入报警";
                    break;
                case RecordReasonNo.Fire:
                    str = "火警";
                    break;
                case RecordReasonNo.ForcedClose:
                    str = "强制关门";
                    break;
                case RecordReasonNo.GuardAgainstTheft:
                    str = "防盗报警";
                    break;
                case RecordReasonNo.H7X24HourZone:
                    str = "烟雾煤气温度报警";
                    break;
                case RecordReasonNo.EmergencyCall:
                    str="紧急呼救报警";
                    break;
                case RecordReasonNo.RemoteOpenDoor:
                    str="操作员远程开门";
                    break;
                case RecordReasonNo.RemoteOpenDoorByUSBReader:
                    str = "发卡器确定发出的远程开门";
                    break;
                default:
                    break;
            }
            return str;
        }

    }
    public class AlarmTypeName
    {
        public RecordReasonNo Reason = RecordReasonNo.DeniedAccess;
        public string Name = "";
        public AlarmTypeName(RecordReasonNo reason)
        {
            Reason = reason;
            Name = AccessHelper.GetRecordReasonString(reason);
        }
        public override string ToString()
        {
            return Name;
        }
        public static IEnumerable<AlarmTypeName> GetAlarmTypes()
        {
            List<RecordReasonNo> reasons = new List<RecordReasonNo>()
            {
                RecordReasonNo.DeniedAccessPCControl,
                    RecordReasonNo.DeniedAccessNoPRIVILEGE,
                    RecordReasonNo.DeniedAccessWrongPASSWORD,
                    RecordReasonNo.DeniedAccessAntiBack,
                    RecordReasonNo.DeniedAccessMoreCards,
                    RecordReasonNo.DeniedAccessFirstCardOpen,
                    RecordReasonNo.DeniedAccessDoorSetNC,
                    RecordReasonNo.DeniedAccessInterLock,
                    RecordReasonNo.DeniedAccessLimitedTimes,
                    RecordReasonNo.DeniedAccessInvalidTimezone,
                    RecordReasonNo.DeniedAccess,
                    RecordReasonNo.PushButtonInvalidForcedLock,
                    RecordReasonNo.PushButtonInvalidNotOnLine,
                    RecordReasonNo.PushButtonInvalidInterLock,
                    RecordReasonNo.Threat,
                    RecordReasonNo.OpenTooLong,
                    RecordReasonNo.ForcedOpen,
                    RecordReasonNo.Fire,
                    RecordReasonNo.ForcedClose,
                    RecordReasonNo.GuardAgainstTheft,
                    RecordReasonNo.H7X24HourZone,
                    RecordReasonNo.EmergencyCall
            };
            foreach (var item in reasons)
            {
                AlarmTypeName atn = new AlarmTypeName(item);
                yield return atn;
            }
        }
    }

    public delegate void AccessDataCallBackHandler(ControllerState record,int port);
    public class AccessDataCallBack
    {
        public event AccessDataCallBackHandler CallBack;
        private UdpClient _wgAccessClient=null;
        public bool BeginWGAccessReceiver(string ip=null,int port=0)
        {
            StopWGAccessReceiver();
            if (_wgAccessClient == null)
            {
                if (string.IsNullOrWhiteSpace(ip))
                {
                    _wgAccessClient = new UdpClient(port);
                }
                else
                {
                    IPAddress add = IPAddress.Parse(ip);
                    IPEndPoint p = new IPEndPoint(add, port);
                    _wgAccessClient = new UdpClient(p);
                }
                _wgAccessClient.BeginReceive(new AsyncCallback(WGAccessReceiverCallBack), _wgAccessClient);
                return true;
            }
            return false;
        }

        public bool IsWGAccessReceiverRun()
        {
            return _wgAccessClient != null;
        }

        public void StopWGAccessReceiver()
        {
            try
            {
                if (_wgAccessClient != null)
                {
                    _wgAccessClient.Close();
                    _wgAccessClient = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("关闭Socket异常：" + ex.Message);
            }
            _wgAccessClient = null;
        }

        private void WGAccessReceiverCallBack(IAsyncResult ar)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] bts = _wgAccessClient.EndReceive(ar, ref endPoint);
                if (CallBack != null)
                {
                    var record = WGAccesses.WGAccess.ToWGPacket(bts).ToControllerState(true);
                    CallBack(record, ((IPEndPoint)_wgAccessClient.Client.LocalEndPoint).Port);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("接收Socket异常：" + ex.Message);
            }
            finally
            {
                _wgAccessClient.BeginReceive(new AsyncCallback(WGAccessReceiverCallBack), _wgAccessClient);
            }
        }
    }

    /// <summary>
    /// 控制器类
    /// </summary>
    public class Controller
    {
        public const string WGACCESS="WGACCESS";
        public decimal id = 0;
        public string sn;//控制器序列号
        public ControllerDoorType doorType;//控制器门类型
        public string ip;//IP地址
        public int port;//控制器端口
        public string mask;//子网掩码
        public string gateway;//网关
        public string mac;//MAC地址
        public string driverVersion;//驱动版本
        public DateTime driverReleaseTime;//驱动发行日期(年、月、日)
        public string model = WGACCESS;
    }
    /// <summary>
    ///控制器状态
    /// </summary>
    public class ControllerState
    {
        //以下是State和Record共有
        public string sn;//控制器序列号
        public uint lastRecordIndex = 0;//(最后一条)记录的索引号(=0表示没有记录)
        public RecordType recordType = RecordType.NoRecord;
        public bool isAllowValid;//有效性(0 表示不通过:false, 1表示通过:true)
        public byte doorNum;//门号(1,2,3,4)
        public bool isEnterDoor;//进门/出门(1表示进门:true, 2表示出门:false)
        public string cardOrNoNumber;//卡号(类型是刷卡记录时)或编号(其他类型记录)
        public DateTime recordTime;//刷卡时间:年月日时分秒 (采用BCD码)见设置时间部分的说明
        public RecordReasonNo reasonNo;//记录原因代码(查询 刷卡记录说明中的Reason)
        //以下只是State
        public bool isOpenDoorOfLock1;//   1号门门磁(0表示关上:false, 1表示打开:true)
        public bool isOpenDoorOfLock2;//2号门门磁(0表示关上, 1表示打开)
        public bool isOpenDoorOfLock3;//3号门门磁(0表示关上, 1表示打开)
        public bool isOpenDoorOfLock4;//4号门门磁(0表示关上, 1表示打开)
        public bool isOpenDoorOfButton1;//1号门按钮(0表示松开, 1表示按下)
        public bool isOpenDoorOfButton2;//2号门按钮(0表示松开, 1表示按下)
        public bool isOpenDoorOfButton3;//3号门按钮(0表示松开, 1表示按下)
        public bool isOpenDoorOfButton4;//4号门按钮(0表示松开, 1表示按下)
        public byte troubleNum = 0;//故障号， 0 无故障，不等于0, 有故障(先重设时间, 如果还有问题, 则要返厂家维护)
        public DateTime controllerCurTime;//控制器当前时间
        public uint seqNum = 0;//流水号
        public bool[] relayState = new bool[8];//0-8,表示1-8号门继电器状态，true 门开锁， false 门上锁
        public bool isFireAlarm = false;//是否火警
        public bool isForceLock = false;//是否强制锁门
    }
}
