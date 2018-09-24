using Li.Access.Core.FaceDevice;
using Li.Access.Core.WGAccesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.Access.Core
{
    /// <summary>
    /// BST实时监控服务
    /// </summary>
    public class BstFaceWatchService:IDisposable
    {
        private int _scanInterval = 300;
        public BstFaceWatchService(int interval = 300)
        {
            _scanInterval = interval;
        }
        private List<BstFaceWatchThread> _bstFaceThreads = new List<BstFaceWatchThread>();
        public List<BstFaceWatchThread> BstFaceThreads
        {
            get { return _bstFaceThreads; }
        }
        public void AddController(BSTDevice dev, FaceDevStateCallBackHandler callback, string tag)
        {
            lock (_bstFaceThreads)
            {
                try
                {
                    if (dev == null)
                    {
                        return;
                    }
                    if (callback == null)
                    {
                        return;
                    }
                    var ctrlthread = _bstFaceThreads.Find(m => m.Device._ip == dev._ip);
                    if (ctrlthread == null)
                    {
                        ctrlthread = new BstFaceWatchThread(_scanInterval);
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

                }
                catch (Exception)
                {
                    
                }
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

                    List<BstFaceWatchThread> ths = new List<BstFaceWatchThread>();
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
                catch (Exception)
                {
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

    public delegate void FaceDevStateCallBackHandler(BSTDevice dev,bool connected,Maticsoft.Model.BST.staff_log log);
    public class BstFaceWatchThread
    {
        private Dictionary<string, FaceDevStateCallBackHandler> CallBacks = new Dictionary<string, FaceDevStateCallBackHandler>();
        public List<string> Tags= new List<string>();
        private bool _isRun = false;
        private Thread _threadRead = null;
        private BSTDevice _device = null;
        private BSTFaceRecg _faceRecg = null;
        private bool _connected = true;
        private int _scanInterval = 300;
        public BSTDevice Device
        {
            get { return _device; }
            set
            { 
                _device = value;
            }
        }

        public BstFaceWatchThread(int scanInterval = 300)
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
            catch (Exception)
            {
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
                            _faceRecg = new BSTFaceRecg();
                            _faceRecg.InitConfig(this.Device._ip, this.Device._port, this.Device._heartPort, this.Device._dbPort, this.Device._dbName, this.Device._dbUser, this.Device._dbPwd);
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
                    catch (Exception)
                    {
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

        private void DoCallBack(bool connected,Maticsoft.Model.BST.staff_log log)
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
