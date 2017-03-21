using Li.Access.Core.WGAccesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.Access.Core
{
    /// <summary>
    /// 实时监控服务
    /// </summary>
    public class AccessWatchService:IDisposable
    {
        private int _scanInterval = 300;
        public AccessWatchService(int interval = 300)
        {
            _scanInterval = interval;
        }
        private List<AccessWatchThread> _controllerThreads = new List<AccessWatchThread>();
        public List<AccessWatchThread> ControllerThreads
        {
            get { return _controllerThreads; }
        }
        public void AddController(Controller ctrlr,ControllerStateCallBackHandler callback,string tag)
        {
            lock (_controllerThreads)
            {
                try
                {
                    if (ctrlr == null)
                    {
                        return;
                    }
                    if (callback == null)
                    {
                        return;
                    }
                    var ctrlthread = _controllerThreads.Find(m => m.Controller.sn == ctrlr.sn);
                    if (ctrlthread == null)
                    {
                        ctrlthread = new AccessWatchThread(_scanInterval);
                        ctrlthread.Tags.Add(tag);
                        ctrlthread.Controller = ctrlr;
                        _controllerThreads.Add(ctrlthread);
                        ctrlthread.Controller = ctrlr;
                        ctrlthread.AddCallBack(tag, callback);
                        ctrlthread.Start();
                    }
                    else
                    {
                        ctrlthread.Controller = ctrlr;
                        ctrlthread.AddCallBack(tag, callback);
                        if (!ctrlthread.Tags.Contains(tag))
                        {
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
            lock (_controllerThreads)
            {
                try
                {
                    if (tag == null)
                    {
                        ClearControllers();
                        return;
                    }
                    var ctrlthread = _controllerThreads.Find(m => m.Controller.id == id && m.Tags.Contains(tag));
                    if (ctrlthread != null)
                    {
                        if (ctrlthread.Tags.Count > 1)
                        {
                            ctrlthread.RemoveCallBack(tag);
                        }
                        else
                        {
                            _controllerThreads.Remove(ctrlthread);
                            ctrlthread.Stop();
                        }
                    }
                }
                catch (Exception)
                {
                }
               
            }
        }
        public void RemoveController(string sn, string tag = null)
        {
            lock (_controllerThreads)
            {
                if (tag == null)
                {
                    ClearControllers();
                    return;
                }
                var ctrlthread = _controllerThreads.Find(m => m.Controller.sn == sn && m.Tags.Contains(tag));
                if (ctrlthread != null)
                {
                    if (ctrlthread.Tags.Count > 1)
                    {
                        ctrlthread.RemoveCallBack(tag);
                    }
                    else
                    {
                        _controllerThreads.Remove(ctrlthread);
                        ctrlthread.Stop();
                    }
                }
            }
        }

        public List<string> GetControllerSNs()
        {
            lock (_controllerThreads)
            {
                List<string> sns = new List<string>();
                foreach (var item in _controllerThreads)
                {
                    sns.Add(item.Controller.sn);
                }
                return sns;
            }
        }

        private void ClearControllers()
        {
            try
            {
                foreach (var item in _controllerThreads)
                {
                    item.Stop();
                }
                _controllerThreads.Clear();
            }
            catch (Exception)
            {
                 
            }

        }

        public void ClearControllers(string tag=null)
        {
            lock (_controllerThreads)
            {
                try
                {
                    if (tag == null)
                    {
                        ClearControllers();
                        return;
                    }

                    List<AccessWatchThread> ths = new List<AccessWatchThread>();
                    foreach (var item in _controllerThreads)
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
                            _controllerThreads.Remove(item);
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
                foreach (var item in _controllerThreads)
                {
                    item.Stop();
                }
                _controllerThreads.Clear();
            }
            catch (Exception)
            {
            }

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ctrlr"></param>
    /// <param name="connected"></param>
    /// <param name="state"></param>
    /// <param name="doorstate"></param>
    public delegate void ControllerStateCallBackHandler(Controller ctrlr,bool connected,ControllerState state,bool doorstate,bool relaystate);
    public class AccessWatchThread
    {
        private Dictionary<string, ControllerStateCallBackHandler> CallBacks = new Dictionary<string, ControllerStateCallBackHandler>();
        public List<string> Tags= new List<string>();
        private bool _isRun = false;
        private Thread _threadRead = null;
        private Controller _controler = null;
        private bool _connected = true;
        private int _scanInterval = 300;
        public Controller Controller
        {
            get { return _controler; }
            set
            { 
                _controler = value;
            }
        }

        public AccessWatchThread(int scanInterval = 300)
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
        private ControllerState lastState = null;
        private void Read()
        {
            try
            {
                while (_isRun)
                {
                    try
                    {
                        IAccessCore ac = new WGAccess();
                        ControllerState state = ac.GetControllerState(_controler);
                      //var s=  ac.GetControllerRecord(_controler, -1);
                        DoCallBack(state!=null, state);
                    }
                    catch (ThreadAbortException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        if (!_isRun)
                        {
                            return;
                        }
                        DoCallBack(false, null);
                    }
                    Thread.Sleep(_scanInterval);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DoCallBack(bool connected, ControllerState state)
        {
            try
            {
                if (lastState == null && connected && state != null)//首次连接
                {
                    _connected = connected;
                    lastState = state;
                    foreach (var item in CallBacks)
                    {
                        item.Value.BeginInvoke(_controler, connected, lastState, false,false, null, null);
                    }
                }
                else
                {
                    if (lastState == null)//未连接
                    {
                        lastState = state;
                        if (!connected && !_connected)
                        {
                            return;
                        }
                        _connected = connected;//连接上
                        foreach (var item in CallBacks)
                        {
                            item.Value.BeginInvoke(_controler, connected, lastState, false,false, null, null);
                        }
                    }
                    else
                    {
                        if (_connected&&!connected)//门禁断开
                        {
                            _connected = connected;
                           // lastState = state;
                            foreach (var item in CallBacks)
                            {
                                item.Value.BeginInvoke(_controler, connected, state,false,false, null, null);
                            }
                        }
                        else if (!_connected&&connected)//连接上
                        {
                            _connected = connected;
                            if (lastState.lastRecordIndex==state.lastRecordIndex)//同一条记录
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    if(lastState.relayState[i]!=state.relayState[i])
                                    {
                                        lastState = state;
                                        lastState.doorNum = (byte)(i + 1);
                                        foreach (var item in CallBacks)
                                        {
                                            item.Value.BeginInvoke(_controler, connected, lastState, false,true, null, null);
                                        }
                                        break;
                                    }
                                }
                                if (lastState.isOpenDoorOfLock1!=state.isOpenDoorOfLock1
                                    || lastState.isOpenDoorOfLock2 != state.isOpenDoorOfLock2
                                    || lastState.isOpenDoorOfLock3 != state.isOpenDoorOfLock3
                                    || lastState.isOpenDoorOfLock4 != state.isOpenDoorOfLock4)
                                {//门锁发生改变
                                    foreach (var item in CallBacks)
                                    {
                                        item.Value.BeginInvoke(_controler, connected, lastState, true, false, null, null);
                                    }
                                }
                                lastState = state;
                                foreach (var item in CallBacks)
                                {
                                    item.Value.BeginInvoke(_controler, connected, lastState, false, false, null, null);
                                }
                            }
                            else
                            {
                                lastState = state;
                                foreach (var item in CallBacks)
                                {
                                    item.Value.BeginInvoke(_controler, connected, lastState, true,false, null, null);
                                }
                            }
                        }
                        else if (lastState.lastRecordIndex != state.lastRecordIndex)
                        {
                            lastState = state;
                            foreach (var item in CallBacks)
                            {
                                item.Value.BeginInvoke(_controler, connected, lastState, true,false, null, null);
                            }
                        }
                        else
                        {
                            if (lastState.isOpenDoorOfLock1 != state.isOpenDoorOfLock1
                                    || lastState.isOpenDoorOfLock2 != state.isOpenDoorOfLock2
                                    || lastState.isOpenDoorOfLock3 != state.isOpenDoorOfLock3
                                    || lastState.isOpenDoorOfLock4 != state.isOpenDoorOfLock4)
                            {//门锁发生改变
                                foreach (var item in CallBacks)
                                {
                                    item.Value.BeginInvoke(_controler, connected, lastState, true, false, null, null);
                                }
                            }
                            for (int i = 0; i < 8; i++)
                            {
                                if (lastState.relayState[i] != state.relayState[i])
                                {
                                    lastState = state;
                                    lastState.doorNum = (byte)(i + 1);
                                    foreach (var item in CallBacks)
                                    {
                                        item.Value.BeginInvoke(_controler, connected, lastState, false,true, null, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void AddCallBack(string tag,ControllerStateCallBackHandler callback)
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
                    callback.BeginInvoke(_controler, _connected, lastState, true,false, null, null);
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
