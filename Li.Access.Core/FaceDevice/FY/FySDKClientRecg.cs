using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY
{
    public class FySDKClientRecg : IFaceRecg, IDisposable
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32", EntryPoint = "CallWindowProc")]
        public static extern int CallWindowProc(int lpPrevWndFunc, IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        private static extern int EnumChildWindows(IntPtr hWndParent, FindCallBack lpfn, int lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public delegate bool FindCallBack(IntPtr hwnd, int lParam);
        public delegate long SubWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private SubWndProc leftWndProc = null;
        private FindCallBack findCallBack = null;
        private IntPtr child = IntPtr.Zero;
        private long oldproc;
        private IntPtr playWin=IntPtr.Zero;
        private System.Timers.Timer timerCheckWin;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FySDKClientRecg));
        private string _strDeviceIp=null;
        private FaceRealRecordHandle _readRecordHandle;
        private bool _bConnected=false;
        private string _sn;
        private static bool initState = false;
        private static bool callBackState = false;
        private static event FACE_SDK.DeviceStatusEventHandler deviceStatusEventHandler;
        private static event FACE_SDK.FaceRecognitionResultEventHandle faceRecognitionResultEventHandle;
        public FySDKClientRecg(string strDeviceIp, string sn)
        {
            if (!initState)
            {
                initState = FACE_SDK.FACE_DEVICE_NET_Initialize();
            }
            if (!initState)
            {
                throw new Exception("SDK未有成功初始化！");
            }

            _strDeviceIp = strDeviceIp;
            _bConnected = FACE_SDK.FACE_DEVICE_NET_API_Connect(strDeviceIp);
            if (!_bConnected)
            {
                throw new Exception("连接失败：" + strDeviceIp);
            }
            /*IntPtr ptrDeviceParam = Marshal.AllocHGlobal(4096);
            try
            {
                bool ret = FACE_SDK.FACE_DEVICE_NET_API_GetDeviceParam(strDeviceIp, ptrDeviceParam, 3000);
                if (!ret)
                {
                    throw new Exception("获取设备信息失败:" + strDeviceIp);
                }
                string strDeviceParam = Marshal.PtrToStringAnsi(ptrDeviceParam);
                Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.JsonConvert.DeserializeObject(strDeviceParam) as Newtonsoft.Json.Linq.JObject;
                if (obj!=null)
                {
                    sn = obj["deviceNumber"].ToString();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptrDeviceParam);
            }*/


            this._sn = sn;
            //状态回调
            deviceStatusEventHandler += new FACE_SDK.DeviceStatusEventHandler(FySDKClientRecg_deviceStatusEventHandler);
            faceRecognitionResultEventHandle += new FACE_SDK.FaceRecognitionResultEventHandle(FySDKClientRecg_faceRecognitionResultEventHandle);
            if (!callBackState)
            {
                FACE_SDK.FACE_DEVICE_NET_API_SetDeviceStatusCallBack(deviceStatusEventHandler, IntPtr.Zero);
                callBackState = FACE_SDK.FACE_DEVICE_NET_API_SetFaceRecognitionResultCallBack(faceRecognitionResultEventHandle, IntPtr.Zero);
            }
        }

        private void FySDKClientRecg_faceRecognitionResultEventHandle(IntPtr ptrDeviceDataBuffer, int dataLen, IntPtr pUser)
        {
            byte[] buffer = new byte[dataLen];
            for (int i = 0; i < dataLen; i++)
            {
                buffer[i] = Marshal.ReadByte(ptrDeviceDataBuffer,i);
            }
            string pDeviceDataBuffer = Encoding.UTF8.GetString(buffer);
            FyFaceSDKRecord fyFaceSDKRecord = Newtonsoft.Json.JsonConvert.DeserializeObject<FyFaceSDKRecord>(pDeviceDataBuffer);
            if (fyFaceSDKRecord != null && _readRecordHandle != null)
            {
                if (fyFaceSDKRecord.deviceNo != _sn)
                {
                    return;
                }
                FaceRecgRecord faceRecgRecord = new FaceRecgRecord();
                try
                {
                    faceRecgRecord.time = DateTime.Parse(fyFaceSDKRecord.passTime);
                }
                catch (Exception)
                {
                    faceRecgRecord.time = DateTime.Now;
                }
                faceRecgRecord.staffDevId = fyFaceSDKRecord.idNumber;
                faceRecgRecord.photoImage = null;
               // faceRecgRecord.photoImage = Convert.FromBase64String(fyFaceSDKRecord.compareJpegData);
                faceRecgRecord.videoImage = Convert.FromBase64String(fyFaceSDKRecord.recognitionPhoto);
                double res = 100;
                double.TryParse(fyFaceSDKRecord.comparePoint, out res);
                faceRecgRecord.compareVal = res / 100;
                faceRecgRecord.realName = fyFaceSDKRecord.name;
                faceRecgRecord.deptName = fyFaceSDKRecord.department;
                faceRecgRecord.cardNo = fyFaceSDKRecord.normalNumber;
                faceRecgRecord.staffType = "";
                faceRecgRecord.recordId = faceRecgRecord.time.ToString("yyyyMMddHHmmssfff");
                _readRecordHandle.BeginInvoke(this, faceRecgRecord, null, null);
            }
        }

        private void FySDKClientRecg_deviceStatusEventHandler(IntPtr pstrDeviceIp, int deviceStatus, IntPtr pUser)
        {
            string strDeviceIp = Marshal.PtrToStringAnsi(pstrDeviceIp);
            if (_strDeviceIp == strDeviceIp)
            {
                if (deviceStatus == 2)
                {
                    _bConnected = false;
                }
                else
                {
                    _bConnected = true;
                }
            }
        }

        public bool IsHeartbeating
        {
            get
            {
                return _bConnected;
            }
        }

        public bool AddOrModifyFaces(out string tempMsg, params StaffFace[] staffFace)
        {
            throw new NotImplementedException();
        }

        public void BeginHeartbeat()
        {
            //throw new NotImplementedException();
        }

        public bool ClearFaces()
        {
            throw new NotImplementedException();
        }

        public bool DeleteFaces(List<string> deleteprivates)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if(_bConnected)
            {
                FACE_SDK.FACE_DEVICE_NET_API_Disconnect(_strDeviceIp);
                _bConnected = false;
            }
            deviceStatusEventHandler -= FySDKClientRecg_deviceStatusEventHandler;
            faceRecognitionResultEventHandle -= FySDKClientRecg_faceRecognitionResultEventHandle;
        }

        public FaceDeviceModel GetDeviceModel()
        {
            throw new NotImplementedException();
        }

        public bool IsFaceExists(string id)
        {
            throw new NotImplementedException();
        }

        public bool ModifyTextInfo(out string errorMsg, params StaffFace[] staffFaces)
        {
            throw new NotImplementedException();
        }

        public void SetRealRecordCallback(FaceRealRecordHandle faceRealRecordHandle)
        {
            _readRecordHandle = faceRealRecordHandle;
        }

        public bool StartPlayVideo(IntPtr winHandle)
        {
            if (playWin != IntPtr.Zero)
            {//已经播放
                return false;
            }

            bool ret = FACE_SDK.FACE_DEVICE_NET_API_StartPlay(_strDeviceIp, winHandle);
            if (ret)
            {
                playWin = winHandle;
                findCallBack = new FindCallBack(winFindCallBack);
                timerCheckWin = new System.Timers.Timer(1000);
                timerCheckWin.Elapsed += TimerCheckWin_Elapsed;
                timerCheckWin.Start();
            }
            return ret;
        }
        private bool winFindCallBack(IntPtr hwnd, int lParam)
        {
            StringBuilder stringBuilder = new StringBuilder(256);
            GetClassName(hwnd, stringBuilder, 255);
            if(stringBuilder.ToString().StartsWith("VLC MSW"))
            {
                child = hwnd;
                return false;
            }
            return true;
        }
        private void TimerCheckWin_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                EnumChildWindows(playWin, findCallBack,0);
                //IntPtr child = FindWindowEx(playWin, IntPtr.Zero, "VLC MSW video 160F3050", null);
                if (child != IntPtr.Zero)
                {
                    timerCheckWin.Stop();
                    timerCheckWin.Elapsed -= TimerCheckWin_Elapsed;
                    leftWndProc = new SubWndProc(MainWndProc);
                    IntPtr ptr = Marshal.GetFunctionPointerForDelegate(leftWndProc);
                    //GWL_WNDPROC = -4
                    oldproc = SetWindowLong(child, (-4), ptr.ToInt32());
                }
            }
            catch (Exception ex)
            {
                log.Error("检测子窗口异常："+ex.Message, ex);
            }

        }
        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;

        private DateTime timeClick = DateTime.Now;
        private long MainWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            if (hWnd == IntPtr.Zero) return 0;
            Console.WriteLine("MSG:" + string.Format("0x{0:X000}", msg));
            if (msg == 0x0210)
            {
                DateTime now = DateTime.Now;
                double d = (now - timeClick).TotalMilliseconds;
                timeClick = now;
                if (d > 240)
                {
                    SendMessage(playWin, WM_LBUTTONDOWN, 0, 0);
                }
                else
                {
                    SendMessage(playWin, WM_LBUTTONDBLCLK, 0, 0);
                }
                SendMessage(playWin, WM_LBUTTONUP, 0, 0);
            }
            return CallWindowProc((int)oldproc, hWnd, msg, wParam.ToInt32(), lParam.ToInt32());
        }

        public void StopPlayVideo(IntPtr winHandle)
        {
            if (timerCheckWin != null)
            {
                timerCheckWin.Stop();
                timerCheckWin.Dispose();
                timerCheckWin = null;
            }
            FACE_SDK.FACE_DEVICE_NET_API_StopPlay(_strDeviceIp, winHandle);
            playWin = IntPtr.Zero;
        }
    }
    public class FyFaceSDKRecord
    {
        public string version = "V4.0";
        public string msgType = "uploadRecord";
        public string msgID = "164";
        public string snapType = "3";
        public string token = "1600006348782";
        public string deviceNo = "0020200424000";
        public string compareResult = "1";
        public string inOutMode = "0";
        public string comparePoint = "68";
        public string passTime = "2020-09-13 22:13:54.480";
        public string temperature = "0.0";
        public string temperatureResult = "0";
        public string faceMaskResult = "0";
        public string normalNumber = "";
        public string offLineRecordNum = "50";
        public string idNumber = "f2d55fda561d4859bab902f4e976d4fc";
        public string name = "陌生人";
        public string sex = "";
        public string birth = "";
        public string company = "";
        public string department = "";
        public string phone = "";
        public string validDateStart = "";
        public string validDateEnd = "";
        public string visitorVoiceText = "";
        public string priority = "";
        public string data = "";
        public string recognitionPhoto = "";
    }
}