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
                        ctrlthread = new AccessWatchThread();
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
    public delegate void ControllerStateCallBackHandler(Controller ctrlr,bool connected,ControllerState state,bool doorstate);
    public class AccessWatchThread
    {
        private Dictionary<string, ControllerStateCallBackHandler> CallBacks = new Dictionary<string, ControllerStateCallBackHandler>();
        public List<string> Tags= new List<string>();
        private bool _isRun = false;
        private Thread _threadRead = null;
        private Controller _controler = null;
        private bool _connected = true;
        public Controller Controller
        {
            get { return _controler; }
            set
            { 
                _controler = value;
            }
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
                    Thread.Sleep(300);
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
                        item.Value.BeginInvoke(_controler, connected, lastState, true, null, null);
                    }
                }
                else
                {
                    if (lastState == null)
                    {
                        lastState = state;
                        if (!connected && !_connected)
                        {
                            return;
                        }
                        _connected = connected;
                        foreach (var item in CallBacks)
                        {
                            item.Value.BeginInvoke(_controler, connected, lastState, false, null, null);
                        }
                    }
                    else
                    {
                        if (_connected&&!connected)
                        {
                            _connected = connected;
                           // lastState = state;
                            foreach (var item in CallBacks)
                            {
                                item.Value.BeginInvoke(_controler, connected, state,false, null, null);
                            }
                        }
                        else if (!_connected&&connected)
                        {
                            _connected = connected;
                            if (lastState.lastRecordIndex==state.lastRecordIndex)
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    if(lastState.relayState[i]!=state.relayState[i])
                                    {
                                        lastState = state;
                                        foreach (var item in CallBacks)
                                        {
                                            item.Value.BeginInvoke(_controler, connected, lastState, true, null, null);
                                        }
                                    }
                                }
                                lastState = state;
                                foreach (var item in CallBacks)
                                {
                                    item.Value.BeginInvoke(_controler, connected, null, false, null, null);
                                }
                            }
                            else
                            {
                                lastState = state;
                                foreach (var item in CallBacks)
                                {
                                    item.Value.BeginInvoke(_controler, connected, lastState, false, null, null);
                                }
                            }
                        }
                        else if (lastState.lastRecordIndex != state.lastRecordIndex)
                        {
                            lastState = state;
                            foreach (var item in CallBacks)
                            {
                                item.Value.BeginInvoke(_controler, connected, lastState, false, null, null);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (lastState.relayState[i] != state.relayState[i])
                                {
                                    lastState = state;
                                    foreach (var item in CallBacks)
                                    {
                                        item.Value.BeginInvoke(_controler, connected, lastState, true, null, null);
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
                    callback.BeginInvoke(_controler, _connected, lastState, true, null, null);
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
