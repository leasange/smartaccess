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
    }
}
