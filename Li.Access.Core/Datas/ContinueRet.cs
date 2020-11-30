using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Li.Access.Core.Datas
{
    [DataContract]
    public class ContinueRet
    {
        [DataMember]
        public bool isContinue = true;
        [DataMember]
        public bool isSuccess = true;
        [DataMember]
        public string errorMsg;
    }
}
