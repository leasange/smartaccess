using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Li.Access.Core.FaceDevice
{
    public delegate void FaceRealRecordHandle(BSTFaceRecg recg,Maticsoft.Model.BST.staff_log log);
    /// <summary>
    /// 博思廷人脸识别
    /// </summary>
    public class BSTFaceRecg:IDisposable
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(BSTFaceRecg));
        private string _ip;
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private int _port;
        private int _heartPort;
        private int _dbPort;
        private string _dbName;
        private string _dbUser;
        private string _dbPwd;
        private DateTime _heartStateTime = DateTime.Now;
        private FaceRealRecordHandle _readRecordHandle;
        public DateTime HeartStateTime
        {
            get { return _heartStateTime; }
            set { _heartStateTime = value; }
        }
        private TcpClient _heartClient = null;
        private TcpClient _cmdClient = null;
        private NetworkStream _heartNS = null;
        private StreamWriter _heartSW = null;
        private byte[] _heartReadBuffer = null;
        private System.Timers.Timer _timerSendHeartbeat = null;
        private StreamWriter _cmdSW = null;
        private NetworkStream _cmdNS = null;
        private byte[] _cmdReadBuffer = null;
        private string _cmdReadString = null;
        //正在心跳
        public bool IsHeartbeating
        {
            get
            {
                return _heartClient != null && _heartClient.Connected;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ip">人脸设备IP</param>
        /// <param name="port">设备控制端口,默认6665</param>
        /// <param name="heartPort">设备心跳端口，默认6668</param>
        /// <param name="dbPort">数据库端口，默认3306</param>
        /// <param name="dbName">数据库用户名，</param>
        /// <param name="dbPwd">数据库密码</param>
        public void InitConfig(string ip, int port, int heartPort, int dbPort, string dbName,string dbUser, string dbPwd)
        {
            this._ip = ip;
            this._port = port;
            this._heartPort = heartPort;
            this._dbPort = dbPort;
            this._dbName = dbName;
            this._dbUser = dbUser;
            this._dbPwd = dbPwd;
        }

        #region 心跳控制

        //开始发送心跳
        public void BeginHeartbeat()
        {
            try
            {
                _heartClient = new TcpClient();
                _heartClient.BeginConnect(_ip, _heartPort, new AsyncCallback(HeartbeatConnectCallback), null);
            }
            catch (Exception ex)
            {
                log.Error("开始心跳失败：" + ex.Message);
                _heartClient = null;
            }
        }

        public void SetRealRecordCallback(FaceRealRecordHandle readRecordHandle)
        {
            this._readRecordHandle = readRecordHandle;
        }

        private void sendHeartbeat()
        {
            try
            {
                if (_heartClient != null && _heartClient.Connected)
                {
                    _heartSW.Write("<BST_02<<000000/BST_02>");
                }

                if (_timerSendHeartbeat == null)
                {
                    _timerSendHeartbeat = new System.Timers.Timer(8000);
                    _timerSendHeartbeat.Elapsed += _timerSendHeartbeat_Elapsed;
                    _timerSendHeartbeat.Start();
                }
            }
            catch (Exception ex)
            {
                log.Error("心跳发送失败",ex);
            }
        }
        private void _timerSendHeartbeat_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sendHeartbeat();
        }
        private string _heartResultString = "";
        private void HeartbeatReadCallback(IAsyncResult ar)
        {
            try
            {
                int count = _heartNS.EndRead(ar);
                if (count > 0)
                {
                    string str = Encoding.UTF8.GetString(_heartReadBuffer, 0, count);
                    if (str == "<BST_02<<000000/BST_02>")//心跳
                    {
                        _heartStateTime = DateTime.Now;
                    }
                    else
                    {
                        _heartResultString += str;
                    }
                }
                if (!_heartNS.DataAvailable)
                {//无数据可读
                    if (_heartResultString!="")
                    {
                        try
                        {
                            if (_heartResultString.Contains("<BST_02<<000000/BST_02>"))
                            {
                                _heartStateTime = DateTime.Now;
                                _heartResultString = _heartResultString.Replace("<BST_02<<000000/BST_02>", "");
                            }
                            if (!string.IsNullOrWhiteSpace(_heartResultString))
                            {
                                if (_heartResultString.StartsWith("<BST_01<<") && _heartResultString.Length > 106)
                                {
                                    int ind = _heartResultString.IndexOf("<ID/");
                                    int idLen = int.Parse(_heartResultString.Substring(ind + 4, 2));
                                    string logid = _heartResultString.Substring(106, idLen);
                                    Maticsoft.BLL.BST.staff_log logBll = new Maticsoft.BLL.BST.staff_log();
                                    SetDbConnectStr(logBll.dal.DbHelperMySQLP);
                                    var model = logBll.GetModel(logid);
                                    if (model != null)
                                    {
                                        if (_readRecordHandle != null)
                                        {
                                            _readRecordHandle.BeginInvoke(this, model, null, null);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("解析人脸实时状态数据异常：", ex);
                        }
                        finally
                        {
                            _heartResultString = "";
                        }
                       
                    }
                }
                _heartNS.BeginRead(_heartReadBuffer, 0, _heartReadBuffer.Length, HeartbeatReadCallback, null);
            }
            catch (Exception ex)
            {
                log.Error("读取异常：" + ex.Message);
            }
        }

        private void HeartbeatConnectCallback(IAsyncResult ar)
        {
            try
            {
                _heartClient.EndConnect(ar);
                _heartNS = _heartClient.GetStream();
                _heartSW = new StreamWriter(_heartNS);
                _heartSW.AutoFlush = true;

                sendHeartbeat();
                if (_heartReadBuffer==null)
                {
                    _heartReadBuffer = new byte[10240];
                }
                _heartNS.BeginRead(_heartReadBuffer, 0, _heartReadBuffer.Length, HeartbeatReadCallback, null);

            }
            catch (Exception ex)
            {
                _heartClient = null;
                log.Error("心跳连接异常：" + ex.Message);
            }
        }
        #endregion

        private ManualResetEvent _cmdReadReset = null;
        private int _lastCount = 0;
        private void CmdReadCallback(IAsyncResult ar)
        {
            try
            {
                 int count = _cmdNS.EndRead(ar);
                 _lastCount += count;
                 if (_cmdNS.DataAvailable)
                 {
                     _cmdNS.BeginRead(_cmdReadBuffer, _lastCount, _cmdReadBuffer.Length - _lastCount, CmdReadCallback, null);
                 }
                 else
                 {
                     if (_readNeedWait)
                     {
                         Thread.Sleep(500);
                     }
                     if (_cmdNS.DataAvailable)
                     {
                         _cmdNS.BeginRead(_cmdReadBuffer, _lastCount, _cmdReadBuffer.Length - _lastCount, CmdReadCallback, null);
                         return;
                     }
                     if (_lastCount > 0)
                     {
                         _cmdReadString = Encoding.UTF8.GetString(_cmdReadBuffer, 0, _lastCount);
                     }
                     else
                     {
                         _cmdReadString = null;
                     }
                     _lastCount = 0;
                     _cmdReadReset.Set();
                     _cmdNS.BeginRead(_cmdReadBuffer, 0, _cmdReadBuffer.Length, CmdReadCallback, null);
                 }
            }
            catch (Exception ex)
            {
                _heartClient = null;
                log.Error("读取数据异常：" + ex.Message);
            }
        }
        public bool OpenCtrl()
        {
            try
            {
                if (_cmdClient == null || !_cmdClient.Connected)
                {
                    _cmdClient = new TcpClient(_ip, _port);
                    _cmdClient.ReceiveBufferSize = 1024 * 1024 * 5;
                    
                    _cmdNS = _cmdClient.GetStream();
                    _cmdSW = new StreamWriter(_cmdNS);
                    _cmdSW.AutoFlush = true;
                    if (_cmdReadBuffer==null)
                    {
                        _cmdReadBuffer = new byte[1024*1024*4];
                        _cmdReadReset = new ManualResetEvent(false);
                    }
                    
                    _cmdNS.BeginRead(_cmdReadBuffer, 0, _cmdReadBuffer.Length, CmdReadCallback, null);
                }
            }
            catch (Exception ex)
            {
                log.Error("打开设备控制失败："+ex.Message);
                _cmdClient = null;
                return false;
            }
            return true;
        }
        public void CloseCtrl()
        {
            if (_cmdClient !=null)
            {
                _cmdClient.Close();
                _cmdClient = null;
            }
        }

        //执行请求
        public void BeginExcute(Action exAction, bool isAsync, bool isClose)
        {
            lock (this)
            {
                try
                {
                    if (_cmdClient == null || !_cmdClient.Connected)
                    {
                        if (!isAsync)//同步
                        {
                            if (OpenCtrl())
                            {
                                exAction();
                            }
                            else
                            {
                                throw new Exception("打开控制连接失败");
                            }
                        }
                        else//异步
                        {
                            Action action = new Action(() => {
                                try
                                {
                                    if (OpenCtrl())
                                    {
                                        exAction();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error("设备连接失败：" + ex.Message);
                                }

                            });
                        }
                    }
                    else
                    {
                        if (isAsync)
                        {
                            exAction.BeginInvoke(null, null);
                        }
                        else
                        {
                            exAction();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private bool _readNeedWait = false;
        private string doSendCmd(string cmd, string exstr = null, bool checkStart = true, int waittime = 3000, bool readNeedWait=false)
        {
            try
            {
                if (OpenCtrl())
                {
                    byte[] buffer = new byte[2048];
                    _cmdReadReset.Reset();
                    _readNeedWait = readNeedWait;
                    _cmdSW.Write(cmd + exstr);
                    if (_cmdReadReset.WaitOne(waittime))
                    {
                        if (string.IsNullOrWhiteSpace(_cmdReadString))
                        {
                            return null;
                        }
                        else
                        {
                            if (checkStart && _cmdReadString.StartsWith(cmd))
                            {
                                string temp=  _cmdReadString.Substring(cmd.Length).Trim(' ', '\r', '\n');
                                return temp;
                            }
                            else if (!checkStart)
                            {
                                string temp = _cmdReadString.Trim(' ', '\r', '\n');
                                return temp;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    else return null;
                }
                return null;
            }
            catch (Exception)
            {
                
            }
            finally
            {
                _cmdReadString = null;
            }
            return null;
        }

        public BSTVideoBase GetVideo()
        {
            string ret = doSendCmd("//@BST_05@//");
            if (ret!=null)
            {
                if (ret.Contains("RTSP1"))
                {
                    BSTVideoRTSP3 video = Newtonsoft.Json.JsonConvert.DeserializeObject<BSTVideoRTSP3>(ret);
                    return video;
                }
                else
                {
                    BSTVideoRTSP video = Newtonsoft.Json.JsonConvert.DeserializeObject<BSTVideoRTSP>(ret);
                    return video;
                }
            }
            return null;
        }

        public bool SetVideo(BSTVideoBase video)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(video);
            string ret = doSendCmd("//@BST_06@//", json);
            if (ret!=null&&ret == "OK_OK")//成功
            {
                return true;
            }
            return false;
        }

        public bool GetChannelState(out bool chOpen1, out bool chOpen2, out bool chOpen3)
        {
            chOpen1 = chOpen2 = chOpen3 = false;
            string ret = doSendCmd("//@BST_07@//");
            if (ret != null && ret.Length>0)
            {
                if (ret.Length>=1)
                {
                    chOpen1 = ret[0] == '1';
                }
                if (ret.Length>=2)
                {
                    chOpen2 = ret[1] == '1';
                }
                if (ret.Length >= 3)
                {
                    chOpen3 = ret[2] == '1';
                }
                return true;
            }
            return false;
        }
        public bool SetChannelState(bool chOpen1, bool chOpen2, bool chOpen3)
        {
            string cmd = "//@BST_08@//";
            cmd += chOpen1 ? "1" : "0";
            cmd += chOpen2 ? "1" : "0";
            cmd += chOpen3 ? "1" : "0";
            string ret = doSendCmd(cmd);
            if (ret!=null&&ret=="000")
            {
                return true;
            }
            return false;
        }
        private void SetDbConnectStr(LiMaticsoft.DBUtility.Extension.DbHelperMySQLP dbHelperMySQLP)
        {
            dbHelperMySQLP.connectionString = "Server=" + _ip + ";Port=" + _dbPort + ";Database=" + _dbName + ";Uid=" + _dbUser + ";Pwd=" + _dbPwd + ";oldsyntax=true";
        }
        public bool AddOrModifyFaces(out string errorMsg,params Maticsoft.Model.BST.staff_update[] updates)
        {
            errorMsg = null;
            Maticsoft.BLL.BST.staff_update bll = new Maticsoft.BLL.BST.staff_update();
            SetDbConnectStr(bll.dal.DbHelperMySQLP);
            List<string> ids = new List<string>();
            foreach (var item in updates)
            {
                try
                {
                    if (bll.Exists(item.id))
                    {
                        bll.Update(item);
                    }
                    else
                    {
                        bll.Add(item);
                    }

                    ids.Add(item.id);
                }
                catch (Exception ex)
                {
                    errorMsg += "发生错误：" + ex.Message + ";姓名：" + item.name+"\r\n";
                    if (ids.Count==0)
	                {
                        throw ex;
	                }
                }
            }
            if (ids.Count==0)
            {
                return false;
            }

            DeleteFaces(ids,false);
            int time = 1000 * updates.Length;
            bool need = updates.Length > 1;
            if (!need)
            {
                time = 3000;
            }
            string ret = doSendCmd("//@UP@//", checkStart: false, waittime: time, readNeedWait: need);
            if (ret==null)
            {
                errorMsg = "上传，更新人脸失败或者上传超时！";
                return false;
            }
            string[] retts = ret.Split(new string[] { "<<@" },StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, bool> retDic = new Dictionary<string, bool>();
            foreach (var item in retts)
            {
                if (item.StartsWith("OK_OK") && item.EndsWith("OK_OK@>>"))
                {
                    string id = item.Substring(5, item.Length - 13);
                    retDic.Add(id, true);
                }
                else if (item.StartsWith("ER_RO") && item.EndsWith("ER_RO@>>"))
                {
                    string id = item.Substring(5, item.Length - 13);
                    retDic.Add(id, false);
                }
            }
            for (int i = 0; i < updates.Length; i++)
            {
                if (retDic.ContainsKey(updates[i].id))
                {
                    updates[i].Update_Result = retDic[updates[i].id];
                }
                else
                {
                    updates[i].Update_Result = false;
                }
            }
            return true;
        }

        public bool ModifyTextInfo(out string errorMsg, params Maticsoft.Model.BST.staff_data[] datas)
        {
            errorMsg = null;
            Maticsoft.BLL.BST.staff_data bll = new Maticsoft.BLL.BST.staff_data();
            SetDbConnectStr(bll.dal.DbHelperMySQLP);
            foreach (var data in datas)
            {
                try
                {
                    bll.UpdateEx(data);
                    doSendCmd("//@BST_02@//" + data.id, checkStart: false);
                }
                catch (Exception ex)
                {
                    throw new Exception("发生错误：" + ex.Message + ";姓名：" + data.name+" EX:"+ex.Message,ex);
                }
            }
            return true;
        }

        public bool DeleteFaces(List<string> ids,bool bExcmd)
        {
            Maticsoft.BLL.BST.staff_data dataBll = new Maticsoft.BLL.BST.staff_data();
            SetDbConnectStr(dataBll.dal.DbHelperMySQLP);
            List<string> exits = new List<string>();
            foreach (var id in ids)
            {
                if (dataBll.Exists(id))
                {
                    exits.Add(id);
                }
            }
            if (exits.Count==0)
            {
                return true;
            }
            int start = 0;
            int count = 20;
            while (true)
            {
                if (start + count > exits.Count)
                {
                    count = exits.Count - start;
                }
                var rids = exits.GetRange(start, count);
                string temps = "";
                foreach (var rid in rids)
                {
                    temps += "'" + rid + "',";
                }
                temps = temps.TrimEnd(',');
                dataBll.DeleteList(temps);
                start += count;
                if (start >= exits.Count)
                {
                    break;
                }
            }
            if (bExcmd)
            {
                foreach (var item in exits)
                {
                    doSendCmd("//@BST_01@//", item, false,500);
                }
            }
            return true;
        }

        public bool ClearFaces()
        {
            Maticsoft.BLL.BST.staff_data dataBll = new Maticsoft.BLL.BST.staff_data();
            SetDbConnectStr(dataBll.dal.DbHelperMySQLP);
            var ids = dataBll.GetAllIds("");
            if (ids.Count>0)
            {
                dataBll.DeleteAll("");
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        foreach (var item in ids)
                        {
                            doSendCmd("//@BST_01@//", item, false);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }));

            }
            return true;
        }
        public List<Maticsoft.Model.BST.staff_log> ReadAllRecords()
        {
            Maticsoft.BLL.BST.staff_log logBll = new Maticsoft.BLL.BST.staff_log();
            SetDbConnectStr(logBll.dal.DbHelperMySQLP);
            var list = logBll.GetModelList("");
            if (list.Count>0)
            {
                logBll.DeleteAll();
            }
            return list;
        }

        public void Dispose()
        {
            try
            {
                CloseCtrl();
                if (_heartClient != null)
                {
                    _heartClient.Close();
                }
                if (_timerSendHeartbeat != null)
                {
                    _timerSendHeartbeat.Stop();
                    _timerSendHeartbeat.Dispose();
                }
            }
            catch (Exception ex)
            { 
            }
        }
    }
}
