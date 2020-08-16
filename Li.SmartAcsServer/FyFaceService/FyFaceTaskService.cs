using Li.Access.Core.FaceDevice.FY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.SmartAcsServer.FyFaceService
{
    public class FyFaceTaskService
    {
        private FyFaceServer _fyFaceServer=null;
        public FyFaceServer FaceServer
        {
            get
            {
                return _fyFaceServer;
            }
        }
        private System.Timers.Timer _timerOpen = null;
        private System.Timers.Timer _timerGetDevice = null;
        private int _port = 0;
        private bool _isOpening = false;
        private static FyFaceTaskService _instance = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FyFaceTaskService));

        public static FyFaceTaskService Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new FyFaceTaskService();
                }
                return _instance;
            }
        }
        public FyFaceTaskService()
        {
            _timerOpen = new System.Timers.Timer();
            _timerOpen.Interval = 2000;
            _timerOpen.Elapsed += _timerOpen_Elapsed;
            _timerGetDevice = new System.Timers.Timer();
            _timerGetDevice.Interval = 5000;
            _timerGetDevice.Elapsed += _timerGetDevice_Elapsed;
        }

        private void _timerGetDevice_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerGetDevice.Stop();
            try
            {
                GetFaceDevice();
            }
            catch (Exception)
            {
                 
            }
            finally
            {
                if (_timerGetDevice!=null)
                {
                    _timerGetDevice.Start();
                }
            }
        }

        private void _timerOpen_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                lock (_timerOpen)
                {
                    if (!_timerOpen.Enabled)
                    {
                        return;
                    }
                    _isOpening = true;
                    if (_fyFaceServer == null)
                    {
                        log.Info("启动Fy人脸服务，端口：" + _port);
                        _fyFaceServer = new FyFaceServer(_port,true);
                        _fyFaceServer.UploadRecordMsgEvent += _fyFaceServer_UploadRecordMsgEvent;
                        _fyFaceServer.ClientRegisterEvent += _fyFaceServer_ClientRegisterEvent;
                        _fyFaceServer.Open();
                    }
                    else
                    {
                        if (!_fyFaceServer.IsOpend)
                        {
                            log.Info("启动Fy人脸服务，端口：" + _port);
                            _fyFaceServer.Open();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Fy人脸服务开启异常：" + ex.Message);
            }
            finally
            {
                _isOpening = false;
            }
        }

        private void _fyFaceServer_ClientRegisterEvent(object sender, RegisterEventArgs e)
        {
            try
            {
                Maticsoft.BLL.SMT_FACERECG_DEVICE faceDevBll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                var models = faceDevBll.GetModelList("FACEDEV_IP='" + e.registerMsg.ip + "'");
                if (models.Count == 0)
                {
                    log.Warn("无此人脸设备注册！！IP=" + e.registerMsg.ip);
                    return;
                }
                models[0].FACEDEV_SN = e.registerMsg.deviceNo;
                faceDevBll.Update(models[0]);
                log.Info("人脸设备注册回调保存成功！IP=" + e.registerMsg.ip);
            }
            catch (Exception ex)
            {
                log.Error("人脸设备注册更新异常：" + ex.Message);
            }

        }

        private void _fyFaceServer_UploadRecordMsgEvent(object sender, UploadRecordMsgEventArgs e)
        {
            try
            {
                string id = e.uploadRecordMsg.idNumber;
                Maticsoft.BLL.SMT_STAFF_FACEDEV staffFaceDevBll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                var models = staffFaceDevBll.GetModelList("STAFF_DEV_ID='" + id + "'");
                if (models.Count == 0)
                {
                    log.Warn("无此记录设备：STAFF_DEV_ID=" + id);
                    e.uploadSuccess = false;
                    return;
                }
                Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                var staff = staffBll.GetModel(models[0].STAFF_ID);
                if (staff==null)
                {
                    log.Warn("无此记录人员：STAFF_ID=" + models[0].STAFF_ID);
                    e.uploadSuccess = false;
                    return;
                }
                Maticsoft.Model.SMT_FACE_RECORD record = new Maticsoft.Model.SMT_FACE_RECORD();
                record.FACEDEV_ID = models[0].FACEDEV_ID;
                record.FREC_STAFF_ID = models[0].STAFF_ID;
                record.FREC_SRC_ID = e.uploadRecordMsg.idNumber;
                record.FREC_AUTHORITY = null;
                try
                {
                    if (!string.IsNullOrWhiteSpace(e.uploadRecordMsg.comparePhoto))
                    {
                        record.FREC_FACE_IMAGE = Convert.FromBase64String(e.uploadRecordMsg.comparePhoto);
                    }

                    if (!string.IsNullOrWhiteSpace(e.uploadRecordMsg.recognitionPhoto))
                    {
                        record.FREC_VIDEO_IMAGE = Convert.FromBase64String(e.uploadRecordMsg.recognitionPhoto);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("读取图片异常：" + ex.Message);
                }
                record.FREC_FACE_LEVEL = e.uploadRecordMsg.compareResult == "0" ? 1 : 0;
                record.FREC_STAFF_NAME = e.uploadRecordMsg.name;
                record.FREC_STAFF_NO = staff.STAFF_NO;
                record.FREC_STAFF_TYPE = staff.STAFF_TYPE;
                DateTime dt = DateTime.Now;
                DateTime.TryParse(e.uploadRecordMsg.passTime, out dt);
                record.FREC_TIME = dt;//2019-11-08 13:05:51.421
                record.ID = -1;
                Maticsoft.BLL.SMT_FACE_RECORD recordBll = new Maticsoft.BLL.SMT_FACE_RECORD();
                recordBll.Add(record);
                e.uploadSuccess = true;
            }
            catch (Exception ex)
            {
                log.Error("保存记录异常：" + ex.Message);
                e.uploadSuccess = false;
            }
        }

        public void Start(int port=0)
        {
            _port = port;
            log.Info("Fy人脸端口为：" + _port);
            _timerOpen.Start();
            _timerGetDevice.Start();
        }

        public void Stop()
        {
            lock (_timerOpen)
            {
                _timerOpen.Stop();
                _timerGetDevice.Stop();
                _timerGetDevice = null;
            }

            if (_fyFaceServer!=null)
            {
                _fyFaceServer.Close();
                _fyFaceServer = null;
            }
        }

        private void GetFaceDevice()
        {
            try
            {
                Maticsoft.BLL.SMT_FACERECG_DEVICE bll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                var models = bll.GetModelList("FACEDEV_MODE='FY'");
                List<FyFaceObject> fyFaceObjects = new List<FyFaceObject>();
                foreach (var item in models)
                {
                    FyFaceObject fyFaceObject = new FyFaceObject();
                    fyFaceObject.deviceIp = item.FACEDEV_IP;
                    fyFaceObject.deviceNo = item.FACEDEV_SN;
                    fyFaceObjects.Add(fyFaceObject);
                }
                if (_fyFaceServer != null)
                {
                    _fyFaceServer.SetFilterClients(fyFaceObjects);
                }
            }
            catch (Exception)
            {
                 
            }
        }
    }
}
