using Li.Access.Core.FaceDevice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Li.Access.Core.Datas
{
    [DataContract]
    public class ComReq<TData>
    {
        [DataMember]
        public decimal dev_id;
        [DataMember]
        public string dev_ip;
        [DataMember]
        public FaceDeviceModel dev_model;
        [DataMember]
        public TData data;
    }
}
