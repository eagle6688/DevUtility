using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Web
{
    public class UrlHelper
    {
        #region Get last part

        public static string GetLastPart(string url)
        {
            List<string> array = url.Split('/').ToList();
            return array[array.Count - 1];
        }

        #endregion
    }
}