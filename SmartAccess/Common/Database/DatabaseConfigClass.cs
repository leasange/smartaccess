using SmartAccess.Common.EncDec;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SmartAccess.Common.Database
{
    /// <summary>
    /// 数据库配置类
    /// </summary>
    [Serializable]
    public class DatabaseConfigClass
    {
        public string serverName;//服务器名称
        public int verType;//验证类型
        public string user;//用户名
        public string pwd;//密码
        public string database = "AccessData";
        private static byte[] encIV = new byte[] 
        { 
            0x89,0xab,0x00,0x12,0xef,0x43,0x1f,0x10,0x20,0xac,0x19,0xa0,0x40,0x28,0x5f,0xda,0x33,0x68,0x3e,0xed
        };
        private static string encKey = "0*&~!@!#wewsa%~~```";
        public static DatabaseConfigClass GetConfig(string key)
        {
            string str = SunCreate.Common.ConfigHelper.GetConfigString(key);
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            byte[] bts = EncDecClass.AESDecryptInBase64(str, encIV, encKey);
            BinaryFormatter bf = new BinaryFormatter();//以二进制文件序列化和反序列化
            using(MemoryStream ms=new MemoryStream(bts))
	        {
               return bf.Deserialize(ms) as DatabaseConfigClass;
	        }
        }
        public bool SaveConfig(string key)
        {
            BinaryFormatter bf = new BinaryFormatter();//以二进制文件序列化和反序列化
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                byte[] buffer = ms.GetBuffer();
                string str = EncDecClass.AESEncryptRetBase64(buffer, encIV, encKey);
                return SunCreate.Common.ConfigHelper.SetConfigValue(key, str);
            }
        }
        public override string ToString()
        {
            //Server=myServerAddress;Database=myDataBase;User ID=myUsername;Password=myPassword;Trusted_Connection=False; 

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Server={0};Database={1};", serverName, database);
            if (verType==0)
            {
                sb.AppendFormat("Integrated Security=SSPI;");
            }
            else
            {
                sb.AppendFormat("User ID={0};Password={1};Trusted_Connection=False;", user, pwd);
            }
            return sb.ToString();
        }
    }
}
