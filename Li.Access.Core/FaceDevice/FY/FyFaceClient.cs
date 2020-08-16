using Li.Access.Core.FaceDevice.FY.Msg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Li.Access.Core.FaceDevice.FY
{
    /// <summary>
    /// 人脸客户端
    /// </summary>
    public class FyFaceClient
    {
        public event EventHandler<RegisterEventArgs> ClientRegisterEvent;
        public event EventHandler<UploadRecordMsgEventArgs> UploadRecordMsgEvent;

        private RegisterMsg registerMsg;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FyFaceClient));
        public string ip = null;
        private string token = "";
        private TcpClient tcpClient;
        private FyFaceServer fyFaceServer;
        private StreamReader streamReader = null;
        private StreamWriter streamWriter = null;
        private Thread _threadRead = null;
        
        public FyFaceClient(TcpClient tcpClient, FyFaceServer fyFaceServer)
        {
            this.tcpClient = tcpClient;
            this.ip = this.tcpClient.Client.RemoteEndPoint.ToString().Split(':')[0];
            this.fyFaceServer = fyFaceServer;
        }

        private void BeginRead()
        {
            if (_threadRead == null || !_threadRead.IsAlive)
            {
                _threadRead = new Thread(() =>
                  {
                      try
                      {
                          while (this.tcpClient.Connected)
                          {
                              string str = streamReader.ReadLine();
                              if (string.IsNullOrWhiteSpace(str))
                              {
                                  Thread.Sleep(200);
                                  continue;
                              }
                              try
                              {
                                  str = str.Trim('\0', ' ', '\r', '\n');
                                  BaseMsg baseMsg = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseMsg>(str);
                                  if (baseMsg == null)
                                  {
                                      Thread.Sleep(200);
                                      continue;
                                  }
                                  ProcessMsg(baseMsg, str);
                              }
                              catch (Exception ex)
                              {
                                  log.Error("读取处理消息异常：", ex);
                              }
                          }

                      }
                      catch (Exception ex)
                      {
                          try
                          {
                              log.Error("读取异常：" + ex.Message);
                              if (!this.tcpClient.Connected)
                              {
                                  this.fyFaceServer.CloseClient(this.ip);
                              }
                          }
                          catch (Exception)
                          { }
                      }
                  });
                _threadRead.Start();
            }
        }
        #region 处理消息
        private void ProcessMsg(BaseMsg baseMsg, string fullMsg)
        {
            log.Info("接收到消息：" + baseMsg.msgType + "," + baseMsg.deviceNo);
            switch (baseMsg.msgType)
            {
                case "register":
                    {
                        RegisterMsg msg = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterMsg>(fullMsg);
                        if (msg == null)
                        {
                            return;
                        }
                        ProcessRegisterMsg(msg);
                    }
                    break;
                case "keepAlive":
                    {
                        KeepAliveMsg msg = Newtonsoft.Json.JsonConvert.DeserializeObject<KeepAliveMsg>(fullMsg);
                        if (msg == null)
                        {
                            return;
                        }
                        ProcessKeepAliveMsg(msg);
                    }
                    break;
                case "uploadRecord":
                    {
                        UploadRecordMsg msg = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadRecordMsg>(fullMsg);
                        if (msg == null)
                        {
                            return;
                        }
                        ProcessUploadRecordMsg(msg);
                    }
                    break;
                case "registerPersonInfoResp":
                    {
                        RegisterPersonMsgResp msg = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterPersonMsgResp>(fullMsg);
                        if (msg == null)
                        {
                            return;
                        }
                        if (waitForRespType != null && waitSendData != null)
                        {
                            if (msg.GetType() == waitForRespType && waitSendData.msgID == msg.msgID)
                            {
                                waitRespData = msg;
                                waitForRespResetEvent.Set();
                            }
                        }
                    }
                    break;
                case "onlineGetRegisterByIdNumberResp":
                    {
                        OnlineGetRegisterByIdNumberMsgResp msg = Newtonsoft.Json.JsonConvert.DeserializeObject<OnlineGetRegisterByIdNumberMsgResp>(fullMsg);
                        if (msg == null)
                        {
                            return;
                        }
                        if (waitForRespType != null && waitSendData != null)
                        {
                            if (msg.GetType() == waitForRespType && waitSendData.msgID == msg.msgID)
                            {
                                waitRespData = msg;
                                waitForRespResetEvent.Set();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void ProcessUploadRecordMsg(UploadRecordMsg msg)
        {
            if (UploadRecordMsgEvent!=null)
            {
                UploadRecordMsgEventArgs args = new UploadRecordMsgEventArgs()
                {
                    uploadRecordMsg = msg,
                    uploadSuccess = false
                };
                UploadRecordMsgEvent(this, args);
                UploadRecordMsgResp uploadRecordMsgResp = new UploadRecordMsgResp();
                uploadRecordMsgResp.msgID = msg.msgID;
                uploadRecordMsgResp.msgType = "uploadRecordResp";
                uploadRecordMsgResp.controlState = "";
                uploadRecordMsgResp.msg = "";
                if (args.uploadSuccess)
                {
                    uploadRecordMsgResp.errorCode = "100";
                }
                else
                {
                    uploadRecordMsgResp.errorCode = "200";
                }

                SendData(uploadRecordMsgResp);
            }
        }

        private void ProcessRegisterMsg(RegisterMsg registerMsg)
        {
            registerMsg.ip = this.ip;
            OnRegisterMsg(new RegisterEventArgs()
            {
                registerMsg = registerMsg
            });
            this.registerMsg = registerMsg;
            RegisterMsgResp resp = new RegisterMsgResp();
            resp.msgType = "registerResp";
            resp.deviceNo = registerMsg.deviceNo;
            resp.registerTime = ConvertDateTimeToInt(DateTime.Now).ToString();
            this.token = resp.registerTime;
            resp.token = token;
            SendData(resp);
        }
        private void ProcessKeepAliveMsg(KeepAliveMsg keepAliveMsg)
        {
            BaseMsg resp = new BaseMsg();
            resp.msgType = "keepAliveResp";
            resp.deviceNo = keepAliveMsg.deviceNo;
            SendData(resp);
        }
        #endregion
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        private long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }

        protected void OnRegisterMsg(RegisterEventArgs e)
        {
            try
            {
                if (ClientRegisterEvent != null)
                {
                    ClientRegisterEvent.BeginInvoke(this, e, null, null);
                }
            }
            catch (Exception ex)
            {
                log.Error("触发RegisterEvent事件异常：" + ex.Message);
            }
        }

        public bool SendData(object data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                streamWriter.Write(json + "\r\n");
                streamWriter.Flush();
                return true;
            }
            catch (Exception ex) 
            {
                log.Error("发送失败：" + ex.Message);
                return false;
            }
        }

        public bool Start()
        {
            try
            {
                streamReader = new StreamReader(tcpClient.GetStream(),Encoding.UTF8);
                streamWriter = new StreamWriter(tcpClient.GetStream(),Encoding.UTF8);
                BeginRead();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("客户端读取失败：", ex);
                return false;
            }
        }

        public void Stop()
        {
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                {
                    tcpClient.Close();
                }
            }
            catch (Exception)
            {
                 
            }
            
        }

        private object waitForRespObject = new object();
        private ManualResetEvent waitForRespResetEvent = null;
        private Type waitForRespType;
        private BaseMsgWithId waitSendData;
        private BaseMsg waitRespData=null;
        public TResp SendData<TResp>(BaseMsgWithId data) where TResp : BaseMsg
        {
            lock (waitForRespObject)
            {
                waitRespData = null;
                waitSendData = data;
                data.deviceNo = registerMsg.deviceNo;
                waitForRespType = typeof(TResp);

                waitForRespResetEvent = new ManualResetEvent(false);
                bool send = SendData(data);
                waitForRespResetEvent.WaitOne(30000);
                return  waitRespData as TResp;
            }
        }

    }
}
