﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;

namespace DevUtility.Out.Application
{
    public class ConfigHelper
    {
        #region Get AppSetting

        public static string GetAppSetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            return ConfigurationManager.AppSettings[key];
        }

        #endregion

        #region Get ConnectionString

        public static string GetConnectionString(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
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
                return null;
            }

            return section[name];
        }

        #endregion

        #region Get Endpoint

        public static ChannelEndpointElement GetEndpoint(string name)
        {
            ClientSection clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;

            foreach (ChannelEndpointElement endpoint in clientSection.Endpoints)
            {
                if (endpoint.Name == name)
                {
                    return endpoint;
                }
            }

            return null;
        }

        #endregion
    }
}