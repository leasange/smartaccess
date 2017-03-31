using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Camera.EngineCore
{
    public class OnvifCore : IIPCamera
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(OnvifCore));
        private IPCamera _ipcamera;
        public OnvifCore(IPCamera ipcamera)
        {
            _ipcamera = ipcamera;
        }
        public System.Drawing.Image CaptureImage()
        {
            System.Drawing.Image image = null;
            if (_ipcamera == null)
            {
                return image;
            }
            onvif_sdk.LOGIN_INFO loginInfo = new onvif_sdk.LOGIN_INFO();
            loginInfo.ip = _ipcamera.IP;
            loginInfo.port = _ipcamera.CapturePort;
            loginInfo.user = _ipcamera.User;
            loginInfo.password = _ipcamera.Password;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(onvif_sdk.HTTP_URL)));
            try
            {
                int outCount = 0;
                int ret = onvif_sdk.onvif_get_snapshot_media_urls(loginInfo, ptr, 1, ref outCount);
                if (ret == onvif_sdk.ONVIF_RET_OK && outCount>0)
                {
                    onvif_sdk.HTTP_URL url = (onvif_sdk.HTTP_URL)Marshal.PtrToStructure(ptr, typeof(onvif_sdk.HTTP_URL));
                    log.Info(_ipcamera.IP + " Onvif截图地址为：" + url.url);
                    image = WebImageReader.ReadImage(url.url, loginInfo.user, loginInfo.password);
                }
                else if (ret == onvif_sdk.ONVIF_RET_OK)
                {
                    
                }
                else
                {
                    throw new Exception("截图失败，错误码："+ret+" 信息："+ onvif_sdk.onvif_get_error_msg(ret));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return image;
        }
    }
}
