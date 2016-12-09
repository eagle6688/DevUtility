using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DevUtility.Out.Web.Client
{
    public class CookieHelper
    {
        #region Save cookie

        /// <summary>
        /// Save cookie
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <param name="cookieValue">Cookie value</param>
        /// <param name="days">Cookie timeout(day), 0 to close the page fail</param>
        public static void SaveCookie(string cookieName, string cookieValue, int days)
        {
            if (HttpContext.Current.Response.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies.Remove(cookieName);
            }

            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = System.Web.HttpUtility.HtmlDecode(cookieValue);
            cookie.Expires = DateTime.Now.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Save cookie
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <param name="cookieDic">Cookie's subkey as a Dictionary object</param>
        /// <param name="days">Cookie timeout(day), 0 to close the page fail</param>
        public static void SaveCookies(string cookieName, Dictionary<string, string> cookieDic, int days)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Expires = DateTime.Now.AddDays(days);

            foreach (KeyValuePair<string, string> node in cookieDic)
            {
                cookie.Values[node.Key] = System.Web.HttpUtility.HtmlDecode(node.Value);
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        #endregion

        #region Get cookie

        /// <summary>
        /// Get cookie value
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <returns></returns>
        public static string GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie != null)
            {
                return System.Web.HttpUtility.HtmlEncode(cookie.Value);
            }

            return "";
        }

        /// <summary>
        /// Get cookie values
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetCookies(string cookieName)
        {
            Dictionary<string, string> cookieDic = null;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie != null)
            {
                cookieDic = new Dictionary<string, string>();

                if (cookie.HasKeys)
                {
                    System.Collections.Specialized.NameValueCollection cookieValues = cookie.Values;
                    string[] cookieNames = cookieValues.AllKeys;

                    for (int i = 0; i < cookieValues.Count; i++)
                    {
                        string key = System.Web.HttpUtility.HtmlEncode(cookieNames[i]);
                        string value = System.Web.HttpUtility.HtmlEncode(cookieValues[i]);
                        cookieDic.Add(key, value);
                    }
                }
                else
                {
                    cookieDic.Add(cookieName, cookie.Value);
                }
            }

            return cookieDic;
        }

        #endregion

        #region Delete cookie

        /// <summary>
        /// Delete cookie
        /// </summary>
        /// <param name="CookieName">Cookie name</param>
        public static void DeleteCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Delete sub cookie
        /// </summary>
        /// <param name="cookieName">Cookie name</param>
        /// <param name="subKey">Sub key name</param>
        public static void DeleteCookie(string cookieName, string subKey)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Remove(subKey);
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        #endregion
    }
}