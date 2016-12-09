using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DevUtility.Com.Data.Security
{
    public class Verification
    {
        #region Email

        public static bool IsEmail(string value)
        {
            Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }

        #endregion

        #region Url

        public static bool IsUrl(string value)
        {
            Regex regex = new Regex(@"((http|ftp|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?", RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }

        #endregion

        #region DomainUrl

        public static bool IsDomainUrl(string value)
        {
            Regex regex = new Regex(@"(\w+\.)+\w+\/(\w+\/|\w+)+(\#\w+|(\?\w+\=\w+(\&\w+\=\w+)*))", RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }

        #endregion

        #region Cellphone

        public static bool Cellphone(string cellphone)
        {
            Regex regex = new Regex(@"^(13[0-9]|14[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(cellphone);
        }

        #endregion

        #region Is OpenID

        public static bool IsOpenID(string value)
        {
            Regex regex = new Regex(@"^[a-z0-9A-Z_-]{28}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }

        #endregion
    }
}