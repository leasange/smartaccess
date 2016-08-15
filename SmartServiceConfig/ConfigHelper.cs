using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;

namespace SmartServiceConfig
{
    public class ConfigHelper
    {
        private static Configuration _configuration;
        private static string _exePath;
        public static bool SetConfigExePath(string exePath)
        {
            if (string.IsNullOrWhiteSpace(exePath))
            {
                _exePath=null;
                _configuration = null;
                return true;
            }
            _exePath = exePath;
            _configuration = ConfigurationManager.OpenExeConfiguration(exePath);
            _exePath = exePath;
            return true;
        }
        public static bool GetConfigBool(string key)
        {
            bool flag = false;
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    flag = bool.Parse(configString);
                }
                catch (FormatException exception)
                {
                    throw exception;
                }
            }
            return flag;
        }
        
        public static decimal GetConfigDecimal(string key)
        {
            decimal num = 0M;
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = decimal.Parse(configString);
                }
                catch (FormatException exception)
                {
                    throw exception;
                }
            }
            return num;
        }
        
        public static double GetConfigDouble(string key)
        {
            double num = 0.0;
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = double.Parse(configString);
                }
                catch (FormatException exception)
                {
                    throw exception;
                }
            }
            return num;
        }
        
        public static int GetConfigInt(string key)
        {
            int num = 0;
            string configString = GetConfigString(key);
            if ((configString != null) && (string.Empty != configString))
            {
                try
                {
                    num = int.Parse(configString);
                }
                catch (FormatException exception)
                {
                    throw exception;
                }
            }
            return num;
        }
        
        public static string GetConfigString(string key)
        {
            if (_configuration!=null)
            {
                return _configuration.AppSettings.Settings[key].Value;
            }
            else   return ConfigurationManager.AppSettings[key];
        }
        
        public static bool SetConfigValue(string AppKey, string AppValue)
        {
            bool flag = false;
            try
            {
                XmlDocument document = new XmlDocument();
                string path = "";
                if (_exePath != null)
                {
                    path = _exePath + ".config";
                }
                else
                {
                    path = Application.ExecutablePath + ".config";
                }
                document.Load(path);
                XmlElement element = (XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode("//add[@key='" + AppKey + "']");
                if (element != null)
                {
                    element.SetAttribute("value", AppValue);
                }
                document.Save(path);
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}
