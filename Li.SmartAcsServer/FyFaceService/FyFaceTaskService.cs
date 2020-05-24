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
