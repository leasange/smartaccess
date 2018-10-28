using Li.Access.Core;
using Li.Access.Core.FaceDevice;
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
    public class FaceRecordTaskService
    {
        private static FaceRecordTaskService _instance = null;
        public static FaceRecordTaskService Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new FaceRecordTaskService();
                }
                return _instance;
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceRecordTaskService));

        private System.Timers.Timer _timerLoadCtrlr = null;

        private ConcurrentQueue<FaceRecordTask> _tasks = new ConcurrentQueue<FaceRecordTask>();
        private List<Thread> _taskThreads = new List<Thread>();
        private Thread _createTask = null;
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _devices = null;
        private const int ThreadCount = 10;
        private bool _start = true;
        private System.Collections.IList _busyTasks = System.Collections.ArrayList.Synchronized(new List<decimal>());
        protected FaceRecordTaskService()
        {

        }

        /// <summary>
        /// 启动记录提起服务
        /// </summary>
        public void Start(int interval=3)
        {
            log.Info("开始启动记录读取服务...");

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
                log.Info("加载人脸设备...");
                Maticsoft.BLL.SMT_FACERECG_DEVICE bll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = bll.GetModelList("1=1");
                _devices=devs;
                /*if (devs.Count>0)
                {
                    log.Info("人脸设备个数:" + devs.Count);
                    List<BSTFaceRecg> ctls = new List<BSTFaceRecg>();
                    foreach (Maticsoft.Model.SMT_FACERECG_DEVICE dev in devs)
                    {
                        BSTFaceRecg bst = new BSTFaceRecg();
                        bst.InitConfig(dev.FACEDEV_IP, dev.FACEDEV_CTRL_PORT, dev.FACEDEV_HEART_PORT, dev.FACEDEV_DB_PORT, dev.FACEDEV_DB_NAME, dev.FACEDEV_DB_USER, dev.FACEDEV_DB_PWD);
                        ctls.Add(bst);
                    }
                    _devices = ctls;
                }*/
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
                List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = _devices;
                if (devs != null && devs.Count > 0)
                {
                    log.Info("开始创建读取记录任务...");
                    foreach (var item in devs)
                    {
                        if (_busyTasks.Contains(item.ID))
                        {
                            continue;
                        }
                        FaceRecordTask task = new FaceRecordTask(item);
                        _tasks.Enqueue(task);
                        log.Info("成功创建任务：" + item.FACEDEV_IP);
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
                    FaceRecordTask task;
                    while (!_tasks.TryDequeue(out task))
                    {
                        Thread.Sleep(500);
                        if (!_start)
                        {
                            return;
                        }
                    }
                    _busyTasks.Add(task.Device.ID);
                    try
                    {
                        task.StartReadRecord();
                    }
                    catch (Exception ex)
                    {
                        log.Error("记录读取任务线程异常1：", ex);
                    }
                    _busyTasks.Remove(task.Device.ID);
                }
                catch (Exception ex)
                {
                    log.Error("记录读取任务线程异常2：", ex);
                }
            }
        }
        //保存记录
        public void SaveRecord(decimal ctrlrId, List<Maticsoft.Model.BST.staff_log> records )
        {
            try
            {
                Dictionary<string, Maticsoft.Model.SMT_STAFF_FACEDEV> staffDevDic = new Dictionary<string, Maticsoft.Model.SMT_STAFF_FACEDEV>();
                Maticsoft.BLL.SMT_FACE_RECORD bllRecord = new Maticsoft.BLL.SMT_FACE_RECORD();
                foreach (var record in records)
                {
                    string strTime = record.id.Substring(0, "2018/09/23_22:48:39".Length);
                    string staffdevId = record.id.Substring("2018/09/23_22:48:39".Length + 1);
                    Maticsoft.Model.SMT_STAFF_FACEDEV sfmodel = null;
                    if (staffDevDic.ContainsKey(staffdevId))
                    {
                        sfmodel = staffDevDic[staffdevId];
                    }
                    else
                    {
                        Maticsoft.BLL.SMT_STAFF_FACEDEV ssfbll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                        List<Maticsoft.Model.SMT_STAFF_FACEDEV> modelSFDs = ssfbll.GetModelList("STAFF_DEV_ID='" + staffdevId + "'");
                        if (modelSFDs.Count == 0)
                        {
                            log.Warn("无此ID：" + staffdevId + " 授权注册！");
                            continue;
                        }
                        sfmodel = modelSFDs[0];
                        Maticsoft.BLL.SMT_STAFF_INFO sbll=new Maticsoft.BLL.SMT_STAFF_INFO();
                        sfmodel.STAFF_INFO=sbll.GetModel(sfmodel.STAFF_ID);
                        staffDevDic.Add(staffdevId, sfmodel);
                    }
                    Maticsoft.Model.SMT_FACE_RECORD modelRecord = new Maticsoft.Model.SMT_FACE_RECORD();
                    modelRecord.FACEDEV_ID = ctrlrId;
                    modelRecord.FREC_AUTHORITY = record.authority;
                    modelRecord.FREC_FACE_IMAGE = record.imagesql;
                    double dec=0.8;
                    double.TryParse(record.info, out dec);
                    modelRecord.FREC_FACE_LEVEL = (decimal)dec;
                    modelRecord.FREC_VIDEO_IMAGE = record.imagevideo;
                    DateTime now=DateTime.Now;
                    DateTime.TryParse(strTime.Replace("_"," "), out now);
                    modelRecord.FREC_TIME = now;
                    modelRecord.ID = -1;
                    modelRecord.FREC_PARAM3 = record.data_keepon3;
                    modelRecord.FREC_PARAM4 = record.data_keepon4;
                    modelRecord.FREC_SRC_ID = record.id;
                    modelRecord.FREC_STAFF_ID = sfmodel.STAFF_ID;
                    if (sfmodel.STAFF_INFO==null)
                    {
                        modelRecord.FREC_STAFF_NAME = record.name;
                        modelRecord.FREC_STAFF_NO = record.data_keepon1;
                        modelRecord.FREC_STAFF_TYPE = record.data_keepon4;
                    }
                    else
                    {
                        modelRecord.FREC_STAFF_NAME = sfmodel.STAFF_INFO.REAL_NAME;
                        modelRecord.FREC_STAFF_NO = sfmodel.STAFF_INFO.STAFF_NO;
                        modelRecord.FREC_STAFF_TYPE = sfmodel.STAFF_INFO.STAFF_TYPE;
                    }

                    bllRecord.Add(modelRecord);
                }
            }
            catch (Exception ex)
            {
                log.Error("记录保存失败：CTRLID=" + ctrlrId, ex);
                throw ex;
            }
        }
    }

    public class FaceRecordTask
    {
        private Maticsoft.Model.SMT_FACERECG_DEVICE _dev = null;
        public Maticsoft.Model.SMT_FACERECG_DEVICE Device
        {
            get { return _dev; }
            set { _dev = value; }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceRecordTask));
        public FaceRecordTask(Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            _dev = dev;
        }

        public void StartReadRecord()
        {
            log.Info("开始读取记录：" + _dev.FACEDEV_IP);
            using (BSTFaceRecg bst = new BSTFaceRecg())
            {
                try
                {
                    bst.InitConfig(_dev.FACEDEV_IP, _dev.FACEDEV_CTRL_PORT, _dev.FACEDEV_HEART_PORT, _dev.FACEDEV_DB_PORT, _dev.FACEDEV_DB_NAME, _dev.FACEDEV_DB_USER, _dev.FACEDEV_DB_PWD);
                    var records = bst.ReadRecords(100);
                    if (records.Count > 0)
                    {
                        bst.SetStateReaded(records);
                        FaceRecordTaskService.Instance.SaveRecord(_dev.ID, records);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
