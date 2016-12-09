using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class EncodingHelper
    {
        #region Variables

        static string[] allowedEncodeNames = new string[] { "ASCII", "UTF-16", "UTF-32", "UTF-8", "UTF-7" };

        #endregion

        #region Properties

        public static string[] AllowedEncodeNames
        {
            get
            {
                return allowedEncodeNames;
            }
        }

        #endregion

        #region Get Encoding

        public static Encoding GetEncoding(string encodeName)
        {
            if (string.IsNullOrEmpty(encodeName) || !AllowedEncodeNames.Contains(encodeName))
            {
                return Encoding.Default;
            }

            return Encoding.GetEncoding(encodeName);
        }

        #endregion

        #region bytes to string

        public static string BytesToString(byte[] bytes, string encodeName = "UTF-8")
        {
            return GetEncoding(encodeName).GetString(bytes);
        }

        #endregion
    }
}