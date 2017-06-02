using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Application
{
    public class ConfigHelper
    {
        #region Get AppSetting

        public static string GetAppSetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return "";
            }

            return ConfigurationManager.AppSettings[key];
        }

        #endregion

        #region Get ConnectionString

        public static string GetConnectionString(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "";
            }

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        #endregion

        #region Get section

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionName">like "ApplicationCache/IISCache"</param>
        /// <returns></returns>
        public static NameValueCollection GetSection(string sectionName)
        {
            var section = ConfigurationManager.GetSection(sectionName);

            if (section == null)
            {
                return null;
            }

            return section as NameValueCollection;
        }

        public static string GetSectionValue(string sectionName, string name)
        {
            var section = GetSection(sectionName);

            if (section == null)
            {
                return "";
            }

            return section[name];
        }

        #endregion
    }
}