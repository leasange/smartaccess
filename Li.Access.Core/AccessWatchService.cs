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
                if (ctrlr == null)
                {
                    return;
                }
                if (callback==null)
                {
                    return;
                }
                var ctrlthread = _controllerThreads.Find(m => m.Controller.sn == ctrlr.sn);
                if (ctrlthread == null)
                {
                    ctrlthread = new AccessWatchThread();
                    ctrlthread.Tag = tag;
                    ctrlthread.Controller = ctrlr;
                    _controllerThreads.Add(ctrlthread);
                    ctrlthread.Controller = ctrlr;

                    ctrlthread.SetCallBack(callback);

                    ctrlthread.Start();
                }
                else
                {
                    ctrlthread.Controller = ctrlr;
                    ctrlthread.SetCallBack(callback);
                    ctrlthread.Tag = tag;
                }
            }
        }

        public void RemoveController(string sn)
        {
            lock (_controllerThreads)
            {
                var ctrlthread = _controllerThreads.Find(m => m.Controller.sn == sn);
                if (ctrlthread != null)
                {
                    _controllerThreads.Remove(ctrlthread);
                    ctrlthread.Stop();
                }
            }
        }

        public void ClearControllers(string tag)
        {
            lock (_controllerThreads)
            {
                List<AccessWatchThread> ths = new List<AccessWatchThread>();
                foreach (var item in _controllerThreads)
                {
                    if (item.Tag==tag)
                    {
                        item.Stop();
                        ths.Add(item);
                    }
                }
                foreach (var item in ths)
                {
                    _controllerThreads.Remove(item);
                }
            }
        }

        public void Dispose()
        {
            foreach (var item in _controllerThreads)
            {
                item.Stop();
            }
            _controllerThreads.Clear();
        }
    }
    public delegate void ControllerStateCallBackHandler(Controller ctrlr,bool connected,ControllerState state,bool doorstate);
    public class AccessWatchThread
    {
        public event ControllerStateCallBackHandler CallBack = null;
        public string Tag=null;
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
                    lastState = state;
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
                        if (CallBack != null)
                        {
                            CallBack.BeginInvoke(_controler, connected, lastState,false, null, null);
                        }
                    }
                    else
                    {
                        if (_connected&&!connected)
                        {
                            _connected = connected;
                           // lastState = state;
                            if (CallBack != null)
                            {
                                CallBack.BeginInvoke(_controler, connected, state,false, null, null);
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
                                        if (CallBack != null)
                                        {
                                            CallBack.BeginInvoke(_controler, connected, lastState,true, null, null);
                                        }
                                    }
                                }
                                lastState = state;
                                if (CallBack != null)
                                {
                                    CallBack.BeginInvoke(_controler, connected, null,false, null, null);
                                }
                            }
                            else
                            {
                                lastState = state;
                                if (CallBack != null)
                                {
                                    CallBack.BeginInvoke(_controler, connected, lastState,false, null, null);
                                }
                            }
                        }
                        else if (lastState.lastRecordIndex != state.lastRecordIndex)
                        {
                            lastState = state;
                            if (CallBack != null)
                            {
                                CallBack.BeginInvoke(_controler, connected, lastState,false, null, null);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (lastState.relayState[i] != state.relayState[i])
                                {
                                    lastState = state;
                                    if (CallBack != null)
                                    {
                                        CallBack.BeginInvoke(_controler, connected, lastState,true, null, null);
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

        public void SetCallBack(ControllerStateCallBackHandler callback)
        {
            CallBack = callback;
        }

    }
}
