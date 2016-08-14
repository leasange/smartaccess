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
        private static CardIssueConfig cardIssueConfig = null;
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

        public static CardIssueConfig GetCardIssueConfig()
        {
            if (cardIssueConfig == null)
            {
                cardIssueConfig = new CardIssueConfig();
                string str = SunCreate.Common.ConfigHelper.GetConfigString("CARD_ISSUE_CONFIG");
                cardIssueConfig.FromString(str);
            }
            return cardIssueConfig;
        }
        public static void SetCardIssueConfig(CardIssueConfig config)
        {
            cardIssueConfig = config;
            SunCreate.Common.ConfigHelper.SetConfigValue("CARD_ISSUE_CONFIG", config.ToString());
        }
    }

    public class CardIssueConfig
    {
        public int comPort=3;
        public ComBuad comBuad= ComBuad.CBR_14400;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(CardIssueConfig));
        public CardIssueModel cardIssueModel = CardIssueModel.MF800A;
        public void FromString(string strConfig)
        {
            if (string.IsNullOrWhiteSpace(strConfig))
            {
                log.Warn("发卡器 配置为空！");
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
                    else if (kv[0].Trim() == "MODEL" && kv.Length == 2)
                    {
                        Enum.TryParse<CardIssueModel>(kv[1].Trim(), out cardIssueModel);
                    }
                }
            }
        }
        public override string ToString()
        {
            return string.Format("COM={0},BUAD={1},MODEL={2}", comPort, (int)comBuad, cardIssueModel);
        }
    }
}
