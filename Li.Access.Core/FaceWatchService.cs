using Li.Access.Core.FaceDevice;
using Li.Access.Core.FaceDevice.FY;
using Li.Access.Core.WGAccesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.Access.Core
{
    /// <summary>
    /// 人脸实时监控服务
    /// </summary>
    public class FaceWatchService:IDisposable
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceWatchService));
        private int _scanInterval = 300;
        public FaceWatchService(int interval = 300)
        {
            _scanInterval = interval;
        }
        private List<FaceWatchThread> _bstFaceThreads = new List<FaceWatchThread>();
        public List<FaceWatchThread> BstFaceThreads
        {
            get { return _bstFaceThreads; }
        }
        public FaceWatchThread AddController(FaceDeviceClass dev, FaceDevStateCallBackHandler callback, string tag)
        {
            lock (_bstFaceThreads)
            {
                try
                {
                    if (dev == null)
                    {
                        return null;
                    }
                    if (callback == null)
                    {
                        return null;
                    }
                    var ctrlthread = _bstFaceThreads.Find(m => m.Device._ip == dev._ip);
                    if (ctrlthread == null)
                    {
                        ctrlthread = new FaceWatchThread(_scanInterval);
                        ctrlthread.Tags.Add(tag);
                        ctrlthread.Device = dev;
                        _bstFaceThreads.Add(ctrlthread);
                        ctrlthread.Device = dev;
                        ctrlthread.AddCallBack(tag, callback);
                        ctrlthread.Start();
                    }
                    else
                    {
                        if (!ctrlthread.Tags.Contains(tag))
                        {
                            ctrlthread.Device = dev;
                            ctrlthread.AddCallBack(tag, callback);
                            ctrlthread.Tags.Add(tag);
                        }
                    }
                    return ctrlthread;
                }
                catch (Exception ex)
                {
                    log.Error("发生错误：", ex);
                }
                return null;
            }
        }
        public void RemoveControllerById(decimal id,string tag=null)
        {
            lock (_bstFaceThreads)
            {
                try
                {
                    if (tag == null)
                    {
                        ClearControllers();
                        return;
                    }
                    var ctrlthread = _bstFaceThreads.Find(m => m.Device._id == id && m.Tags.Contains(tag));
                    if (ctrlthread != null)
                    {
                        if (ctrlthread.Tags.Count > 1)
                        {
                            ctrlthread.RemoveCallBack(tag);
                        }
                        else
                        {
                            _bstFaceThreads.Remove(ctrlthread);
                            ctrlthread.Stop();
                        }
                    }
                }
                catch (Exception)
                {
                }
               
            }
        }
        public void RemoveController(string ip, string tag = null)
        {
            lock (_bstFaceThreads)
            {
                if (tag == null)
                {
                    ClearControllers();
                    return;
                }
                var ctrlthread = _bstFaceThreads.Find(m => m.Device._ip == ip && m.Tags.Contains(tag));
                if (ctrlthread != null)
                {
                    if (ctrlthread.Tags.Count > 1)
                    {
                        ctrlthread.RemoveCallBack(tag);
                    }
                    else
                    {
                        _bstFaceThreads.Remove(ctrlthread);
                        ctrlthread.Stop();
                    }
                }
            }
        }

        public FaceWatchThread GetFaceRecg(decimal id)
        {
            lock (_bstFaceThreads)
            {
                try
                {
                    var ctrlthread = _bstFaceThreads.Find(m => m.Device._id == id);
                    if (ctrlthread != null)
                    {
                        return ctrlthread;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("发生错误：", ex);

                }
                return null;
            }
        }

        public List<string> GetControllerIPs()
        {
            lock (_bstFaceThreads)
            {
                List<string> sns = new List<string>();
                foreach (var item in _bstFaceThreads)
                {
                    sns.Add(item.Device._ip);
                }
                return sns;
            }
        }

        private void ClearControllers()
        {
            try
            {
                foreach (var item in _bstFaceThreads)
                {
                    item.Stop();
                }
                _bstFaceThreads.Clear();
            }
            catch (Exception)
            {
                 
            }

        }

        public void ClearControllers(string tag=null)
        {
            lock (_bstFaceThreads)
            {
                try
                {
                    if (tag == null)
                    {
                        ClearControllers();
                        return;
                    }

                    List<FaceWatchThread> ths = new List<FaceWatchThread>();
                    foreach (var item in _bstFaceThreads)
                    {
                        if (item.Tags.Contains(tag))
                        {
                            // item.Stop();
                            ths.Add(item);
                        }
                    }
                    foreach (var item in ths)
                    {
                        if (item.Tags.Count > 1)
                        {
                            item.RemoveCallBack(tag);
                        }
                        else
                        {
                            _bstFaceThreads.Remove(item);
                            item.Stop();
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("移除监控异常：", ex);
                }
                
            }
        }

        public void Dispose()
        {
            try
            {
                foreach (var item in _bstFaceThreads)
                {
                    item.Stop();
                }
                _bstFaceThreads.Clear();
            }
            catch (Exception)
            {
            }

        }
    }
    public delegate void FaceDevStateCallBackHandler(FaceDeviceClass dev,bool connected, FaceRecgRecord log);
    public class FaceWatchThread
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceWatchThread));

        private Dictionary<string, FaceDevStateCallBackHandler> CallBacks = new Dictionary<string, FaceDevStateCallBackHandler>();
        public List<string> Tags= new List<string>();
        private bool _isRun = false;
        private Thread _threadRead = null;
        private FaceDeviceClass _device = null;
        private IFaceRecg _faceRecg = null;
        private bool _connected = true;
        private int _scanInterval = 300;
        public FaceDeviceClass Device
        {
            get { return _device; }
            set
            { 
                _device = value;
            }
        }

        public IFaceRecg FaceRecg { get => _faceRecg; }

        public FaceWatchThread(int scanInterval = 300)
        {
            _scanInterval = scanInterval;
        }

        public void Start()
        {
            if (_threadRead==null)
            {
                _threadRead = new Thread(new ThreadStart(Read));
                _threadRead.IsBackground = true;
                _isRun = true;
                _threadRead.Start();
            }
        }
        public void Stop()
        {
            try
            {
                if (_threadRead != null)
                {
                    _isRun = false;
                    Thread.Sleep(200);
                    _threadRead.Abort();
                }
            }
            catch (Exception ex)
            {
                log.Error("停止线程异常：", ex) ;
            }
            CallBacks.Clear();
            _threadRead = null;
        }
        private void Read()
        {
            try
            {
                while (_isRun)
                {
                    try
                    {
                        if (_faceRecg == null || !_faceRecg.IsHeartbeating)
                        {
                            if (_faceRecg!=null)
                            {
                                _faceRecg.Dispose();
                                _faceRecg = null;
                            }
                            if (_device._faceDeviceModel == FaceDeviceModel.FY)
                            {
                                _faceRecg = new FySDKClientRecg(_device._ip,_device._sn);
                            }
                            else
                            {
                                var faceRecg = new BSTFaceRecg();
                                faceRecg.InitConfig(this.Device._ip, this.Device._port, this.Device._heartPort, this.Device._dbPort, this.Device._dbName, this.Device._dbUser, this.Device._dbPwd);
                                _faceRecg = faceRecg;
                            }
                            _faceRecg.BeginHeartbeat();
                            _faceRecg.SetRealRecordCallback(new FaceRealRecordHandle((r, log) =>
                                {
                                    DoCallBack(_connected, log);
                                }));
                            Thread.Sleep(1000);
                            bool old = _connected;
                            _connected = _faceRecg.IsHeartbeating;
                            if (old!=_connected)
                            {
                                DoCallBack(_connected, null);
                            }
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        log.Error("启动读取异常：", ex);
                        if (!_isRun)
                        {
                            if (_faceRecg != null)
                            {
                                _faceRecg.Dispose();
                                _faceRecg = null;
                            }
                            return;
                        }
                        DoCallBack(false, null);
                    }
                    Thread.Sleep(_scanInterval);
                }
            }
            catch (Exception)
            {
                if (_faceRecg!=null)
                {
                    _faceRecg.Dispose();
                    _faceRecg = null;
                }
                return;
            }
        }

        private void DoCallBack(bool connected, FaceRecgRecord log)
        {
            try
            {
                foreach (var item in CallBacks)
                {
                    item.Value.BeginInvoke(_device, connected, log,null,null);
                }
            }
            catch (Exception)
            {
            }
        }

        public void AddCallBack(string tag, FaceDevStateCallBackHandler callback)
        {
            if (callback==null)
	        {
		         return;
	        }
            if (tag==null)
            {
                tag = "";
            }
            if (!CallBacks.ContainsKey(tag))
            {
                CallBacks.Add(tag, callback);
                if (CallBacks.Count>1)
                {
                    callback.BeginInvoke(_device, _connected,null, null, null);
                }
            }
        }

        public void RemoveCallBack(string tag)
        {
            if (Tags.Contains(tag))
            {
                Tags.Remove(tag);
            }
            if (tag == null)
            {
                tag = "";
            }
            if (CallBacks.ContainsKey(tag))
            {
                CallBacks.Remove(tag);
            }
        }

    }
}
