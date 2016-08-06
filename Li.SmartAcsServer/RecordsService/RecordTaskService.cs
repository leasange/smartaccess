using Li.Access.Core;
using Li.Access.Core.WGAccesses;
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
        protected RecordTaskService()
        {

        }

        /// <summary>
        /// 启动记录提起服务
        /// </summary>
        public void Start()
        {
            log.Info("开始启动记录读取服务...");
            
            for (int i = 0; i < ThreadCount; i++)
            {
                Thread t = new Thread(ThreadDoTask);
                _taskThreads.Add(t);
                t.Start();
            }
            _timerLoadCtrlr = new System.Timers.Timer(5000);
            _timerLoadCtrlr.Elapsed += _timerLoadCtrlr_Elapsed;
            _timerLoadCtrlr.Start();
            _createTask = new Thread(ThreadCreateTask);
            _createTask.Start();
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

        public void SaveRecord(decimal ctrlrId,ControllerState record)
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
                recordBll.Add(modelRecord);
            }
            catch (Exception ex)
            {
                log.Error("记录保存失败：CTRLID=" + ctrlrId,ex);
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
                if (acc.BeginReadRecord(Controller))
                {
                    while (true)
                    {
                        ControllerState record = acc.ReadNextRecord();
                        if (record == null || record.recordType == RecordType.NoRecord)
                        {
                            acc.EndReadRecord();
                            log.Info("记录读取完毕：" + _controller.sn);
                            return;
                        }
                        RecordTaskService.Instance.SaveRecord(_controller.id,record);
                    }
                }
            }
        }
    }
}
