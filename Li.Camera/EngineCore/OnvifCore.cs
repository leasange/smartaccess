using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Camera.EngineCore
{
    public class OnvifCore : IIPCamera
    {
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
            int outCount = 0;
            int ret = onvif_sdk.onvif_get_snapshot_media_urls(loginInfo, ptr, 1, ref outCount);
            if (ret==onvif_sdk.ONVIF_RET_OK)
            {
                onvif_sdk.HTTP_URL url = (onvif_sdk.HTTP_URL)Marshal.PtrToStructure(ptr, typeof(onvif_sdk.HTTP_URL));
            }
            else
            {

            }
            return image;
        }
    }
}
