using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Camera
{
    public class IPCamera
    {
        public string IP;
        public int Port;
        public int CapturePort;
        public string User;
        public string Password;
        public CameraModel Model;
        public CapType CapType;

        private IIPCamera _ipcamera;
        public IIPCamera GetEngine()
        {
            if (_ipcamera==null)
            {
                switch (this.CapType)
                {
                    case CapType.Onvif:
                        _ipcamera = new EngineCore.OnvifCore(this);
                        break;
                    default:
                        break;
                }
            }
            return _ipcamera;
        }
    }

    //摄像头型号
    public enum CameraModel
    {
        None,//未知
        Haikang,//海康
        Dahua,//大华
    }
    //抓拍方式
    public enum CapType
    {
        Onvif,//Onvif
    }
}
