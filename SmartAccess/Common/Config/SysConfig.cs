using Li.Access.Core;
using SmartAccess.Common.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Config
{
    /// <summary>
    /// 系统配置管理类
    /// </summary>
    public class SysConfig
    {
        private static DatabaseConfigClass datavbaseConfig = null;
        private static DevMF800AConfig devDevMF800AConfig = null;
        /// <summary>
        /// 获取Sql Server数据库连接
        /// </summary>
        /// <returns></returns>
        public static string GetSqlServerConnectString()
        {
            if (datavbaseConfig!=null)
            {
                return datavbaseConfig.ToString();
            }
            datavbaseConfig = GetSqlServerServerConfig();
            if (datavbaseConfig == null)
            {
                return null;
            }
            return datavbaseConfig.ToString();
        }

        public static DatabaseConfigClass GetSqlServerServerConfig()
        {
            if (datavbaseConfig != null)
            {
                return datavbaseConfig;
            }
            DatabaseConfigClass configCls = DatabaseConfigClass.GetConfig("SqlServerConnectString");
            return configCls;
        }
        public static bool SetSqlServerConfig(DatabaseConfigClass configcls)
        {
            datavbaseConfig = configcls;
            return configcls.SaveConfig("SqlServerConnectString");
        }

        public static DevMF800AConfig GetDevMF800AConfig()
        {
            if (devDevMF800AConfig == null)
            {
                devDevMF800AConfig = new DevMF800AConfig();
                string str = SunCreate.Common.ConfigHelper.GetConfigString("DEVICE_MF800A_CONFIG");
                devDevMF800AConfig.FromString(str);
            }
            return devDevMF800AConfig;
        }
        public static void SetDevMF800AConfig(DevMF800AConfig config)
        {
            devDevMF800AConfig = config;
            SunCreate.Common.ConfigHelper.SetConfigValue("DEVICE_MF800A_CONFIG",config.ToString());
        }
    }
    public class DevMF800AConfig
    {
        public int comPort=3;
        public ComBuad comBuad= ComBuad.CBR_14400;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(DevMF800AConfig));
        public void FromString(string strConfig)
        {
            if (string.IsNullOrWhiteSpace(strConfig))
            {
                log.Warn("MF800A 配置为空！");
            }
            else
            {
                string[] temps = strConfig.Split(',');
                foreach (var item in temps)
                {
                    string[] kv = item.Split('=');
                    if (kv[0].Trim()=="COM"&&kv.Length==2)
                    {
                        int.TryParse(kv[1].Trim(), out comPort);
                    }
                    else if (kv[0].Trim() == "BUAD" && kv.Length == 2)
                    {
                        Enum.TryParse<ComBuad>(kv[1].Trim(), out comBuad);
                    }
                }
            }
        }
        public override string ToString()
        {
            return string.Format("COM={0},BUAD={1}", comPort, (int)comBuad);
        }
    }
}
