using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DevUtility.Out.Web.Client
{
    public class ClientHelper
    {
        #region Properties

        /// <summary>
        /// CurrentUrl
        /// </summary>
        public static string Url
        {
            get
            {
                return System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

        public static string IP
        {
            get
            {
                return GetIP();
            }
        }

        #endregion

        #region Get IP

        /// <summary>
        /// Through the proxy server to access to remote users real IP address
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string result = "";

            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null)
                    {
                        result = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].ToString();
                    }
                    else
                    {
                        if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                        {
                            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                        }
                    }
                }
                else
                {
                    result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
            }
            else if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }

            if (result.Equals("::1"))
            {
                result = "127.0.0.1";
            }

            return result;
        }

        #endregion
    }
}