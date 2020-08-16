using Li.Access.Core.FaceDevice.FY.Msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterMsg registerMsg;
    }
    public class UploadRecordMsgEventArgs : EventArgs
    {
        public UploadRecordMsg uploadRecordMsg;
        public bool uploadSuccess = false;
    }
}
