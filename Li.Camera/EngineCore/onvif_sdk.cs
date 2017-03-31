using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Li.Camera.EngineCore
{
    public class onvif_sdk
    {
        private const string dll_path = "camera_sdk\\onvif_sdk\\onvif_common.dll";

        public const int ONVIF_RET_OK = 0;
        public const int ONVIF_RET_ERROR = 1;
        public const int ONVIF_RET_GETCAP_ERROR = 2;
        public const int ONVIF_RET_GETPRO_ERROR = 3;
        public const int ONVIF_RTSP_URL_LEN = 500;
        public const int ONVIF_HTTP_URL_LEN = 500;
        public const int ONVIF_IP_LEN = 50;
        public const int ONVIF_USER_LEN = 50;
        public const int ONVIF_PWD_LEN = 50;
        [StructLayout(LayoutKind.Sequential)]
        public struct LOGIN_INFO
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ONVIF_IP_LEN)]
            public string ip;
            public int port;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ONVIF_USER_LEN)]
            public string user;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ONVIF_PWD_LEN)]
            public string password;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RTSP_URL
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ONVIF_RTSP_URL_LEN)]
            public string url;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HTTP_URL
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ONVIF_HTTP_URL_LEN)]
            public string url;
        }
        [DllImport(dll_path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int onvif_get_snapshot_media_urls(LOGIN_INFO login, IntPtr buffer, int bufferCount, ref int outCount);

        [DllImport(dll_path, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static string onvif_get_error_msg(int errorCode);
    }
}
