using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class BaseMsg
    {
        public string msgType = null;
        public string deviceNo = null;
    }
    public class BaseMsgWithToken : BaseMsg
    {
        public string token = null;
    }
}
