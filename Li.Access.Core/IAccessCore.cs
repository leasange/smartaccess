//-------
//门禁控制内核
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core
{
    public interface IAccessCore
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

    }
    public enum ControllerDoorType
    {
        OneDoorTwoDirections,//单门双向
        TwoDoorsTwoDirections,//双门双向
        FourDoorsOneDirection,//四门单向
    }
    /// <summary>
    /// 记录类型
    /// </summary>
    public enum RecordType
    {
        NoRecord=0,//  0=无记录
        CardRecord,//1=刷卡记录
        ProRecord,// 2=门磁,按钮, 设备启动, 远程开门记录
        AlarmRecord//3=报警记录
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
    /// 控制器类
    /// </summary>
    public class Controller
    {
        public string sn;//控制器序列号
        public ControllerDoorType doorType;//控制器门类型
        public string ip;//IP地址
        public string mask;//子网掩码
        public string gateway;//网关
        public string mac;//MAC地址
        public string driverVersion;//驱动版本
        public DateTime driverReleaseTime;//驱动发行日期(年、月、日)
    }
    /// <summary>
    ///控制器状态
    /// </summary>
    public class ControllerState
    {
        //以下是State和Record共有
        public string sn;//控制器序列号
        public uint lastRecordIndex = 0;//最后一条记录的索引号(=0表示没有记录)
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
