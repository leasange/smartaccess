using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Li.Camera
{
    public interface IIPCamera
    {
        Image CaptureImage();
    }
}
