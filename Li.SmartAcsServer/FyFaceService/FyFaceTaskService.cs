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
                Maticsoft.Model.SMT_STAFF_FACEDEV model = null;
                decimal faceDevId = -1;
                Maticsoft.Model.SMT_STAFF_INFO staff = null;
                if (models.Count == 0)
                {
                    log.Warn("无此人员记录设备：STAFF_DEV_ID=" + id);
                    Maticsoft.BLL.SMT_FACERECG_DEVICE bllDev = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                    var devs = bllDev.GetModelList("FACEDEV_SN='" + e.uploadRecordMsg.deviceNo + "'");
                    if (devs.Count > 0)
                    {
                        faceDevId = devs[0].ID;
                    }
                    //e.uploadSuccess = false;
                    //return;
                }
                else
                {
                    model = models[0];
                }
                if (model != null)
                {
                    Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    staff = staffBll.GetModel(model.STAFF_ID);
                    if (staff == null)
                    {
                        log.Warn("无此记录人员：STAFF_ID=" + models[0].STAFF_ID);
                        // e.uploadSuccess = false;
                        //return;
                    }
                }

                Maticsoft.Model.SMT_FACE_RECORD record = new Maticsoft.Model.SMT_FACE_RECORD();
                if (model != null)
                {
                    record.FACEDEV_ID = model.FACEDEV_ID;
                    record.FREC_STAFF_ID = model.STAFF_ID;
                }
                else
                {
                    record.FACEDEV_ID = faceDevId;
                }

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
                /*
                 * public string version;// 接口版本 string 32 Y 如：V1.0
        public string snapType;// 识别类型 string 8 Y 0：自动识别1：人证对比（身份证）2：IC 卡对比3：陌生人4：IC 卡
        public string compareResult;// 比对结果 string 8 Y 0：比对成功1：比对失败2：不在通行时间内3：不在有效期内4：未授权
                 */
                double mark;
                if (double.TryParse(e.uploadRecordMsg.comparePoint, out mark))
                {
                    record.FREC_FACE_LEVEL = (decimal)(mark / 100.0);
                }
                else
                {
                    record.FREC_FACE_LEVEL = e.uploadRecordMsg.compareResult == "0" ? 1 : 0;
                }
                switch (e.uploadRecordMsg.compareResult)// 0：比对成功1：比对失败2：不在通行时间内3：不在有效期内4：未授权
                {
                    case "0":
                        record.FREC_PARAM3 = "比对成功";
                        break;
                    case "1":
                        record.FREC_PARAM3 = "比对失败";
                        break;
                    case "2":
                        record.FREC_PARAM3 = "不在通行时间内";
                        break;
                    case "3":
                        record.FREC_PARAM3 = "不在有效期内";
                        break;
                    case "4":
                        record.FREC_PARAM3 = "未授权";
                        break;
                }
                switch (e.uploadRecordMsg.snapType)//0：自动识别1：人证对比（身份证）2：IC 卡对比3：陌生人4：IC 卡
                {
                    case "0":
                        record.FREC_PARAM4 = "自动识别";
                        break;
                    case "1":
                        record.FREC_PARAM4 = "人证对比（身份证）";
                        break;
                    case "2":
                        record.FREC_PARAM4 = "IC 卡对比";
                        break;
                    case "3":
                        record.FREC_PARAM4 = "陌生人";
                        break;
                    case "4":
                        record.FREC_PARAM4 = "IC 卡";
                        break;
                }
               
                record.FREC_STAFF_NAME = e.uploadRecordMsg.name;
                if (string.IsNullOrWhiteSpace(record.FREC_STAFF_NAME))
                {
                    record.FREC_STAFF_NAME = "未知";
                }
                if (staff != null)
                {
                    record.FREC_STAFF_NO = staff.STAFF_NO;
                    record.FREC_STAFF_TYPE = staff.STAFF_TYPE;
                }

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
