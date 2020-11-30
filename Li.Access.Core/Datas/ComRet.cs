using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Li.Access.Core.Datas
{
    [DataContract]
    public class ComRet
    {
        [DataMember]
        public int code;
        [DataMember]
        public string message;

        public bool IsSuccess
        {
            get
            {
                return code == 0;
            }
        }

        public static ComRet Ok()
        {
            ComRet comRet = new ComRet()
            {
                code = 0,
                message = "成功"
            };
            return comRet;
        }

        public static ComRet Error()
        {
            ComRet comRet = new ComRet()
            {
                code = 1,
                message = "错误"
            };
            return comRet;
        }
        public static ComRet Ret(int code)
        {
            ComRet comRet = new ComRet()
            {
                code = code,
                message = "错误"
            };
            return comRet;
        }
        public static ComRet Ret(int code,string message)
        {
            ComRet comRet = new ComRet()
            {
                code = code,
                message = message
            };
            return comRet;
        }
    }

    [DataContract]
    public class RespRet<TResult>: ComRet
    {
        [DataMember]
        public TResult result;

        public static RespRet<TResult> Ok(TResult result)
        {
            RespRet<TResult> respRet = new RespRet<TResult>()
            {
                code = 0,
                message = "成功",
                result = result
            };
            return respRet;
        }
        public static RespRet<TResult> Ret(int code, string message, TResult result)
        {
            RespRet<TResult> respRet = new RespRet<TResult>()
            {
                code = code,
                message = message,
                result = result
            };
            return respRet;
        }
    }
}
