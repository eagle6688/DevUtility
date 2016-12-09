using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemExt
{
    public static class IntExt
    {
        #region Convert timestamp to DateTime

        public static DateTime TimestampToDateTime(this int timestamp)
        {
            DateTime datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime();
            return datetime.AddSeconds(timestamp);
        }

        #endregion
    }
}