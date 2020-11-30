using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class UploadRecordMsgResp : BaseMsgWithErrorNoToken
    {
        public string controlState;// 道闸开启状态 string 32 Y "open"表示开启道闸"close"表示关闭道闸识别自动开闸，请设置为空:”” 
        public string msg;// 播报内容 string 128 Y 如：”条件符合，道闸开启”识别自动开闸，请设置为空:””
    }
}
