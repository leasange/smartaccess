using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core.FaceDevice.FY.Msg
{
    public class OnlineGetRegisterByIdNumberMsg : BaseMsgWithId
    {
        public string idNumber;// 人员idNumber string 32 Y 如：20001，不为0该编号每个人员唯一
    }
}
