using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using Li.UdpMessageQueue;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using  Li.Camera;
using System.IO;

namespace Li.SmartAcsServer.CaptureService
{
    /// <summary>
    /// 记录提取服务
    /// </summary>
    public class CaptureTaskService
    {
        private static CaptureTaskService _instance = null;
        public static CaptureTaskService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CaptureTaskService();
                }
                return _instance;
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(CaptureTaskService));
        private List<DoorCameraObject> doorCameraObjects =  new List<DoorCameraObject>();
        public static string ImageFolder = "D:\\Images";
        private System.Timers.Timer timerLoad = new System.Timers.Timer();
        private System.Timers.Timer timerCheckStorage = new System.Timers.Timer();
        private AccessWatchService watchService = null;
        protected CaptureTaskService()
        {
            try
            {
                ImageFolder = SunCreate.Common.ConfigHelper.GetConfigString("ImageFolder");
                if (string.IsNullOrWhiteSpace(ImageFolder))
                {
                    ImageFolder = "D:\\Images";
                }
                log.Info("图片目录：" + ImageFolder);
                if (!Directory.Exists(ImageFolder))
                {
                    Directory.CreateDirectory(ImageFolder);
                }
                timerCheckStorage.Interval = 600000;
                timerCheckStorage.Elapsed += timerCheckStorage_Elapsed;
                timerCheckStorage.Start();
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        DoCheckDisk();
                    }));
            }
            catch (Exception ex)
            {
                log.Error("创建目录异常：", ex);
            }

        }
        private List<string> GetFiles(string folder)
        {
            List<string> strs = new List<string>();
            strs.AddRange(Directory.GetFiles(folder));
            string[] dirs = Directory.GetDirectories(folder);
            foreach (var item in dirs)
            {
                strs.AddRange(GetFiles(item));
            }
            return strs;
        }

        private void DoCheckDisk()
        {
            timerCheckStorage.Stop();
            try
            {
                string str = Directory.GetDirectoryRoot(ImageFolder);
                DriveInfo di = new DriveInfo(str);
                long freeSpace = di.TotalFreeSpace / (1024 * 1024 * 1024);
                if (freeSpace < 1)
                {
                    long size = (long)((1.5 - freeSpace) * 1024 * 1024 * 1024);
                    while (size>0)
                    {
                        DataTable dt = Maticsoft.DBUtility.DbHelperSQL.Query("SELECT TOP 20 ID,CAP_RELATIVE_URL FROM SMT_RECORDCAP_IMAGE ORDER BY CAP_TIME").Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                try
                                {
                                    string url = Convert.ToString(item["CAP_RELATIVE_URL"]);
                                    url = Path.Combine(ImageFolder, url);
                                    FileInfo fi = new FileInfo(url);
                                    size -= fi.Length;
                                    fi.Delete();
                                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_RECORDCAP_IMAGE where ID=" + item["ID"]);
                                }
                                catch (Exception)
                                {

                                }
                            }
                            if (dt.Rows.Count < 20 || size < 1000)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            timerCheckStorage.Start();
        }

        private void timerCheckStorage_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DoCheckDisk();
        }

        /// <summary>
        /// 启动记录提起服务
        /// </summary>
        public void Start(int interval =300)
        {
            log.Info("开始启动抓拍服务...");
            if (interval<50)
            {
                interval = 50;
            }
            watchService = new AccessWatchService(interval);
            TestDb();

            timerLoad.Interval = 10000;
            timerLoad.Elapsed += timerLoad_Elapsed;
            timerLoad.Start();
        }

        private void timerLoad_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerLoad.Stop();
            DoLoadCtrlr();
            timerLoad.Start();
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

        public void Stop()
        {
            log.Info("停止抓拍服务...");
            if (timerLoad!=null)
            {
                timerLoad.Dispose();
            }
        }

        private void DoLoadCtrlr()
        {
            try
            {
                log.Info("加载抓拍配置...");
                string sql = "SELECT SDC.*,SDI.CTRL_ID,SDI.CTRL_DOOR_INDEX,SCI.*,SCIF.* FROM SMT_DOOR_CAMERA SDC INNER JOIN SMT_DOOR_INFO SDI ON SDC.DOOR_ID=SDI.ID INNER JOIN SMT_CAMERA_INFO SCI ON SDC.CAMERA_ID=SCI.ID INNER JOIN SMT_CONTROLLER_INFO SCIF ON SDI.CTRL_ID=SCIF.ID WHERE SDC.ENABLE_CAP=1";
                DataTable dt = Maticsoft.DBUtility.DbHelperSQL.Query(sql).Tables[0];
                doorCameraObjects.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        DoorCameraObject dco = new DoorCameraObject();
                        Controller ctrlr = new Controller();
                        ControllerDoorType type = ControllerDoorType.TwoDoorsTwoDirections;
                        Enum.TryParse<ControllerDoorType>(Convert.ToString(dr["CTRLR_TYPE"]), out type);
                        ctrlr.doorType = type;
                        ctrlr.driverReleaseTime = dr["DRIVER_DATE"] == null ? DateTime.MinValue : (DateTime)dr["DRIVER_DATE"];
                        ctrlr.driverVersion = Convert.ToString(dr["DRIVER_VERSION"]);
                        ctrlr.gateway = Convert.ToString(dr["GATEWAY"]);
                        ctrlr.id = dr["CTRL_ID"] == null ? -1 : (decimal)dr["CTRL_ID"];
                        ctrlr.ip = Convert.ToString(dr["IP"]);
                        ctrlr.mac = Convert.ToString(dr["MAC"]);
                        ctrlr.mask = Convert.ToString(dr["MASK"]);
                        ctrlr.model = Convert.ToString(dr["CTRLR_MODEL"]);
                        ctrlr.port = dr["PORT"] == null ? 60000 : (int)dr["PORT"];
                        ctrlr.sn = Convert.ToString(dr["SN_NO"]);
                        dco.controller = ctrlr;

                        IPCamera camera = new IPCamera();
                        camera.CapturePort = dr["CAMERA_CAP_PORT"] == null ? 80 : (int)dr["CAMERA_CAP_PORT"];
                        CapType ct = CapType.Onvif;
                        Enum.TryParse<CapType>(Convert.ToString(dr["CAMERA_CAP_TYPE"]), out ct);
                        camera.CapType = ct;
                        camera.IP = Convert.ToString(dr["CAMERA_IP"]);
                        CameraModel model = CameraModel.None;
                        Enum.TryParse<CameraModel>(Convert.ToString(dr["CAMERA_MODEL"]), out model);
                        camera.Model = model;
                        camera.Password = Convert.ToString(dr["CAMERA_PWD"]);
                        camera.Port = dr["CAMERA_PORT"] == null ? 80 : (int)dr["CAMERA_PORT"];
                        camera.User = Convert.ToString(dr["CAMERA_USER"]);
                        dco.camera = camera;
                        dco.ctrl_door_index = dr["CTRL_DOOR_INDEX"] == null ? 1 : (byte)dr["CTRL_DOOR_INDEX"];

                        doorCameraObjects.Add(dco);
                    }
                    catch (Exception ex)
                    {
                        log.Error("加载抓拍配置异常：DOOR_ID=" + dr["DOOR_ID"] + ",CAMERA_IP=" + dr["CAMERA_IP"], ex);
                    }
                }
                List<string> sns = new List<string>();
                var curSNs = watchService.GetControllerSNs();
                foreach (var item in doorCameraObjects)
                {
                    if (!curSNs.Contains(item.controller.sn))
                    {
                        sns.Add(item.controller.sn);
                    }
                }
                foreach (var item in curSNs)
                {
                    if (!sns.Contains(item))
                    {
                        watchService.RemoveController(item);
                    }
                }
                foreach (var item in doorCameraObjects)
                {
                    watchService.AddController(item.controller, ControllerStateCallBack, "test");
                }
            }
            catch (Exception ex)
            {
                log.Error("读取抓拍配置异常：", ex);
            }
        }

        private void ControllerStateCallBack(Controller ctrlr, bool connected, ControllerState state, bool doorstate, bool relaystate)
        {
            if (connected && doorstate && !relaystate)
            {
                lock (doorCameraObjects)
                {
                    var dcos = doorCameraObjects.FindAll(m => m.controller.sn == ctrlr.sn && m.ctrl_door_index == state.doorNum);
                    if (dcos.Count>0)
                    {
                        foreach (var item in dcos)
                        {
                            DoCaptureImage(item, state);
                        }
                    }
                }
            }
        }
        private void DoCaptureImage(DoorCameraObject dco,ControllerState state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        var image = dco.camera.GetEngine().CaptureImage();
                        if (image==null)
                        {
                            log.Error("抓拍失败：" + dco.camera.IP);
                            return;
                        }
                        DateTime dt = DateTime.Now;   
                        string camstr = "";
                        if (!string.IsNullOrWhiteSpace(dco.camera.IP))
                        {
                            camstr = dco.camera.IP.Replace('.', '_');
                        }
                        else
                        {
                            camstr = "camera_null_ip";
                        }
                        string filePath = dt.ToString(camstr+"\\yyyy\\MM\\dd");
                        string fullPath = Path.Combine(ImageFolder, filePath);
                        if (!Directory.Exists(fullPath))
                        {
                            Directory.CreateDirectory(fullPath);
                        }

                        string pathName = Path.Combine(filePath, dt.ToString("yyyyMMddHHmmss_fff") + ".jpg");
                        fullPath = Path.Combine(ImageFolder, pathName);
                        image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                        Maticsoft.BLL.SMT_RECORDCAP_IMAGE sriBll = new Maticsoft.BLL.SMT_RECORDCAP_IMAGE();
                        Maticsoft.Model.SMT_RECORDCAP_IMAGE sriModel = new Maticsoft.Model.SMT_RECORDCAP_IMAGE();

                        sriModel.CAP_RELATIVE_URL = pathName;
                        sriModel.CAP_TIME = dt;
                        sriModel.CTRL_SN = dco.controller.sn;
                        sriModel.RECORD_INDEX = state.lastRecordIndex;
                        sriModel.RECORD_TIME = state.recordTime;

                        sriBll.Add(sriModel);
                    }
                    catch (Exception ex)
                    {
                        log.Error("抓拍失败：" + dco.camera.IP, ex);
                    }
                }));
        }
    }

    public class DoorCameraObject
    {
        public Controller controller;
        public int ctrl_door_index;
        public IPCamera camera;
    }
}
