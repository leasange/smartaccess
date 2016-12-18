using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using Li.UdpMessageQueue;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.SmartAcsServer.RecordsService
{
    /// <summary>
    /// 记录提取服务
    /// </summary>
    public class RecordTaskService
    {
        private static RecordTaskService _instance = null;
        public static RecordTaskService Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new RecordTaskService();
                }
                return _instance;
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(RecordTaskService));

        private System.Timers.Timer _timerLoadCtrlr = null;

        private ConcurrentQueue<RecordTask> _tasks = new ConcurrentQueue<RecordTask>();
        private List<Thread> _taskThreads = new List<Thread>();
        private Thread _createTask = null;
        private List<Controller> _controllers = null;
        private const int ThreadCount = 10;
        private bool _start = true;
        private System.Collections.IList _busyTasks = System.Collections.ArrayList.Synchronized(new List<string>());
        private BrokerServer _alarmServer = null;
        protected RecordTaskService()
        {

        }

        /// <summary>
        /// 启动记录提起服务
        /// </summary>
        public void Start(int interval=3)
        {
            log.Info("开始启动记录读取服务...");
            int alarmPort = SunCreate.Common.ConfigHelper.GetConfigInt("AlarmPort");
            if (alarmPort<=0||alarmPort>=65536)
	        {
                log.Warn("报警端口配置无效：" + alarmPort + ",使用默认端口：" + 56010);
                alarmPort=56010;
	        }
            try
            {
                _alarmServer = new BrokerServer(alarmPort);
                _alarmServer.Start();
            }
            catch (Exception ex)
            {
                log.Error("开启报警转发服务异常：", ex);
            }

            DoLoadCtrlr();
            for (int i = 0; i < ThreadCount; i++)
            {
                Thread t = new Thread(ThreadDoTask);
                _taskThreads.Add(t);
                t.IsBackground = true;
                t.Start();
            }
            if (interval<1||interval>60)
            {
                interval = 3;
            }
            _timerLoadCtrlr = new System.Timers.Timer(interval*1000);
            _timerLoadCtrlr.Elapsed += _timerLoadCtrlr_Elapsed;
            _timerLoadCtrlr.Start();
            _createTask = new Thread(ThreadCreateTask);
            _createTask.IsBackground = true;
            _createTask.Start();
        }
        private void TestDb()
        {
            try
            {
                DoLoadCtrlr();
            }
            catch (Exception)
            {
              //  throw;
            }
        }
        private void _timerLoadCtrlr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerLoadCtrlr.Stop();
            DoLoadCtrlr();
            _timerLoadCtrlr.Start();
        }
        
        public void Stop()
        {
            log.Info("停止记录读取服务...");
            _start = false;
            try
            {
                _createTask.Abort();

            }
            catch (Exception)
            {
                 
            }
            try
            {
                foreach (var item in _taskThreads)
                {
                    if (item.IsAlive)
                    {
                        item.Abort();
                    }
                }
            }
            catch (Exception)
            {
                 
            }

        }

        private void DoLoadCtrlr()
        {
            try
            {
                log.Info("加载控制器...");
                Maticsoft.BLL.SMT_CONTROLLER_INFO bll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = bll.GetModelList("1=1");
                if (ctrls.Count>0)
                {
                    log.Info("控制器个数:" + ctrls.Count);
                    List<Controller> ctls=new List<Controller>();
                    foreach (Maticsoft.Model.SMT_CONTROLLER_INFO item in ctrls)
                    {
                        Controller ctl = new Controller();
                        ctl.id=item.ID;
                        ctl.sn = item.SN_NO;
                        ctl.ip = item.IP;
                        ctl.port = item.PORT == null ? 60000 : (int)item.PORT;
                        if (ctl.port<=0||ctl.port>65535)
                        {
                            ctl.port = 60000;
                        }
                        ctl.mac = item.MAC;
                        ctl.mask = item.MASK;
                        ctl.model = item.CTRLR_MODEL;
                        ctl.gateway = item.GATEWAY;
                        ctls.Add(ctl);
                    }
                    _controllers = ctls;
                }
            }
            catch (Exception ex)
            {
                log.Error("加载控制器异常：", ex);
            }
        }
        /// <summary>
        /// 创建任务线程
        /// </summary>
        private void ThreadCreateTask()
        {
            while (_start)
            {
                Thread.Sleep(1000);
                if (!_start)
                {
                    return;
                }
                if (_tasks.Count>100)
                {
                    continue;
                }
                List<Controller> ctrls = _controllers;
                if (ctrls != null && ctrls.Count > 0)
                {
                    log.Info("开始创建读取记录任务...");
                    foreach (var item in ctrls)
                    {
                        if (_busyTasks.Contains(item.sn))
                        {
                            continue;
                        }
                        RecordTask task = new RecordTask(item);
                        _tasks.Enqueue(task);
                        log.Info("成功创建任务：" + item.sn);
                    }
                    log.Info("创建完成，当前任务总数：" + _tasks.Count);
                }
            }
        }

        /// <summary>
        /// 多线程去任务执行
        /// </summary>
        private void ThreadDoTask()
        {
            while (_start)
            {
                try
                {
                    RecordTask task;
                    while (!_tasks.TryDequeue(out task))
                    {
                        Thread.Sleep(500);
                        if (!_start)
                        {
                            return;
                        }
                    }
                    _busyTasks.Add(task.Controller.sn);
                    try
                    {
                        task.StartReadRecord();
                    }
                    catch (Exception ex)
                    {
                        log.Error("记录读取任务线程异常1：", ex);
                    }
                    _busyTasks.Remove(task.Controller.sn);
                }
                catch (Exception ex)
                {
                    log.Error("记录读取任务线程异常2：", ex);
                }
            }
        }
        //保存记录
        public void SaveRecord(decimal ctrlrId, ControllerState record)
        {
            try
            {
                Maticsoft.Model.SMT_CARD_RECORDS modelRecord = new Maticsoft.Model.SMT_CARD_RECORDS();
                modelRecord.CARD_NO = record.cardOrNoNumber;
                modelRecord.CTRLR_DOOR_INDEX = record.doorNum;

                modelRecord.CTRLR_ID = ctrlrId;
                modelRecord.CTRLR_SN = record.sn;

                Maticsoft.BLL.SMT_DOOR_INFO bll = new Maticsoft.BLL.SMT_DOOR_INFO();

                List<Maticsoft.Model.SMT_DOOR_INFO> doors = bll.GetModelList("CTRL_ID=" + ctrlrId + " and CTRL_DOOR_INDEX=" + record.doorNum);
                if (doors.Count > 0)
                {
                    modelRecord.DOOR_ID = doors[0].ID;
                }
                else
                {
                    modelRecord.DOOR_ID = -1;
                }
                modelRecord.IS_ALLOW = record.isAllowValid;
                modelRecord.IS_ENTER = record.isEnterDoor;
                modelRecord.RECORD_DATE = record.recordTime;
                modelRecord.RECORD_DESC = AccessHelper.GetRecordReasonString(record.reasonNo);
                modelRecord.RECORD_INDEX = record.lastRecordIndex;
                modelRecord.RECORD_REASON = record.reasonNo.ToString();
                modelRecord.RECORD_TYPE = record.recordType.ToString();

                Maticsoft.BLL.SMT_STAFF_CARD cardBll = new Maticsoft.BLL.SMT_STAFF_CARD();

                List<Maticsoft.Model.SMT_STAFF_CARD> staffCards = cardBll.GetModelListByWGCardNo(record.cardOrNoNumber);
                if (staffCards.Count > 0)
                {
                    modelRecord.STAFF_ID = staffCards[0].STAFF_ID;
                }
                else
                {
                    modelRecord.STAFF_ID = -1;
                }
                Maticsoft.BLL.SMT_CARD_RECORDS recordBll = new Maticsoft.BLL.SMT_CARD_RECORDS();
                modelRecord.ID = recordBll.Add(modelRecord);
                switch (record.reasonNo)
                {
                    case RecordReasonNo.Swipe:
                        break;
                    case RecordReasonNo.Reserved2:
                        break;
                    case RecordReasonNo.Reserved3:
                        break;
                    case RecordReasonNo.Reserved4:
                        break;
                    case RecordReasonNo.DeniedAccessPCControl:
                    case RecordReasonNo.DeniedAccessNoPRIVILEGE:
                    case RecordReasonNo.DeniedAccessWrongPASSWORD:
                    case RecordReasonNo.DeniedAccessAntiBack:
                    case RecordReasonNo.DeniedAccessMoreCards:
                    case RecordReasonNo.DeniedAccessFirstCardOpen:
                    case RecordReasonNo.DeniedAccessDoorSetNC:
                    case RecordReasonNo.DeniedAccessInterLock:
                    case RecordReasonNo.DeniedAccessLimitedTimes:
                    case RecordReasonNo.DeniedAccessInvalidTimezone:
                    case RecordReasonNo.DeniedAccess:
                    case RecordReasonNo.PushButtonInvalidForcedLock:
                    case RecordReasonNo.PushButtonInvalidNotOnLine:
                    case RecordReasonNo.PushButtonInvalidInterLock:
                    case RecordReasonNo.Threat:
                    case RecordReasonNo.OpenTooLong:
                    case RecordReasonNo.ForcedOpen:
                    case RecordReasonNo.Fire:
                    case RecordReasonNo.ForcedClose:
                    case RecordReasonNo.GuardAgainstTheft:
                    case RecordReasonNo.H7X24HourZone:
                    case RecordReasonNo.EmergencyCall:
                        {
                            Maticsoft.Model.SMT_ALARM_INFO alarmInfo = new Maticsoft.Model.SMT_ALARM_INFO();
                            try
                            {
                                alarmInfo.ALARM_NAME = AccessHelper.GetRecordReasonString(record.reasonNo);
                                alarmInfo.ALARM_CONTENT = alarmInfo.ALARM_NAME;
                                alarmInfo.ALARM_TIME = record.recordTime;
                                alarmInfo.ALARM_TYPE = (int)record.reasonNo;
                                alarmInfo.CARD_NO = record.cardOrNoNumber;
                                alarmInfo.CTRLR_DOOR_INDEX = record.doorNum;
                                alarmInfo.CTRLR_ID = ctrlrId;
                                alarmInfo.DOOR_ID = modelRecord.DOOR_ID;
                                alarmInfo.RECORD_ID = modelRecord.ID;
                                alarmInfo.STAFF_ID = modelRecord.STAFF_ID;
                                Maticsoft.BLL.SMT_ALARM_INFO alarmBll = new Maticsoft.BLL.SMT_ALARM_INFO();
                                alarmInfo.ID = alarmBll.Add(alarmInfo);
                                try
                                {
                                    _alarmServer.SendMessageAsync<decimal>(alarmInfo.ID, MessageType.ALARM);
                                }
                                catch (Exception ex)
                                {
                                    log.Error("转发报警消息失败：Alarm Id=" + alarmInfo.ID + ",EX=" + ex.Message);
                                }

                            }
                            catch (Exception ex)
                            {
                                log.Error("报警记录保存失败：CTRLID=" + ctrlrId + ", RECORD ID=" + modelRecord.ID + ",ALARM_NAME=" + alarmInfo.ALARM_NAME, ex);
                            }
                        }
                        break;
                    case RecordReasonNo.Reserved14:
                        break;
                    case RecordReasonNo.Reserved16:
                        break;
                    case RecordReasonNo.Reserved17:
                        break;
                    case RecordReasonNo.Reserved19:
                        break;
                    case RecordReasonNo.PushButton:
                        break;
                    case RecordReasonNo.Reserved21:
                        break;
                    case RecordReasonNo.Reserved22:
                        break;
                    case RecordReasonNo.DoorOpen:
                        break;
                    case RecordReasonNo.DoorClosed:
                        break;
                    case RecordReasonNo.SuperPasswordOpenDoor:
                        break;
                    case RecordReasonNo.Reserved26:
                        break;
                    case RecordReasonNo.Reserved27:
                        break;
                    case RecordReasonNo.ControllerPowerOn:
                        break;
                    case RecordReasonNo.ControllerReset:
                        break;
                    case RecordReasonNo.Reserved30:
                        break;
                    case RecordReasonNo.Reserved35:
                        break;
                    case RecordReasonNo.Reserved36:
                        break;
                    case RecordReasonNo.RemoteOpenDoor:
                        break;
                    case RecordReasonNo.RemoteOpenDoorByUSBReader:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error("记录保存失败：CTRLID=" + ctrlrId, ex);
                throw ex;
            }
        }

        //更新状态
        public void SaveState(decimal ctrlrId,ControllerState state)
        {
            try
            {
                Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                List<Maticsoft.Model.SMT_DOOR_INFO> doors = doorBll.GetModelList("CTRL_ID=" + ctrlrId);
                foreach (var item in doors)
                {
                    if (item.CTRL_DOOR_INDEX==null)
                    {
                        continue;
                    }
                    if (state==null)
                    {
                        item.OPEN_STATE = 2;
                    }
                    else
                    {
                        item.OPEN_STATE = state.relayState[((int)item.CTRL_DOOR_INDEX - 1)] ? 1 : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("保存状态失败：CTRLID=" + ctrlrId, ex);
            }
        }
    }

    public class RecordTask
    {
        private Controller _controller = null;
        public Li.Access.Core.Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(RecordTask));
        public RecordTask(Controller controller)
        {
            _controller = controller;
        }

        public void StartReadRecord()
        {
            log.Info("开始读取记录：" + _controller.sn);
            using (IAccessCore acc = new WGAccess())
            {
                try
                {
                    if (acc.BeginReadRecord(Controller))
                    {
                        try
                        {
                            while (true)
                            {
                                ControllerState record = acc.ReadNextRecord();
                                if (record == null || record.recordType == RecordType.NoRecord)
                                {
                                    log.Info("记录读取完毕：" + _controller.sn);
                                    break;
                                }
                                try
                                {
                                    RecordTaskService.Instance.SaveRecord(_controller.id, record);
                                }
                                catch (Exception ex)
                                {
                                    if (record.lastRecordIndex<=0)
                                    {
                                        record.lastRecordIndex = 0xffffffff;
                                    }
                                    else
                                    {
                                        record.lastRecordIndex--;
                                    }
                                    acc.SetControllerReadedIndex(Controller, record.lastRecordIndex);
                                    return;
                                }
                            }
                        }
                        finally
                        {
                            acc.EndReadRecord();
                        }
                    }

                    ControllerState state = acc.GetControllerState(Controller);
                    if (state != null)
                    {
                        RecordTaskService.Instance.SaveState(_controller.id, state);
                    }
                }
                catch (Exception ex)
                {
                    RecordTaskService.Instance.SaveState(_controller.id, null);
                    throw ex;
                }
            }
        }
    }
}
