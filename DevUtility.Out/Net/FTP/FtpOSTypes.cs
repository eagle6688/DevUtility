using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DevUtility.Out.Net.FTP
{
    public enum FtpOSTypes
    {
        Unknown = 0,
        Unix,
        Windows
    }

    public class FtpOSTypesHelper
    {
        #region Get Ftp OS Type

        public static FtpOSTypes GetFtpOSType(string detail)
        {
            if (IsUnixDetail(detail))
            {
                return FtpOSTypes.Unix;
            }

            if (IsWindowsDetail(detail))
            {
                return FtpOSTypes.Windows;
            }

            return FtpOSTypes.Unknown;
        }

        #endregion

        #region Is Unix Detail

        public static bool IsUnixDetail(string value)
        {
            if (value.Length < 10)
            {
                return false;
            }

            string str = value.Substring(0, 10);
            return Regex.IsMatch(str, "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)");
        }

        #endregion

        #region Is Windows Detail

        public static bool IsWindowsDetail(string value)
        {
            if (value.Length < 8)
            {
                return false;
            }

            string str = value.Substring(0, 8);
            return Regex.IsMatch(str, "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]");
        }

        #endregion
    }
}