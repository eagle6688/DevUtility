using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public enum FtpItemTypes
    {
        Unknow = 0,
        File,
        Directory
    }

    public class FtpItemTypesHelper
    {
        #region Get Unix Item Type

        public static FtpItemTypes GetUnixItemType(string value)
        {
            if (value == "d")
            {
                return FtpItemTypes.Directory;
            }

            return FtpItemTypes.File;
        }

        #endregion
    }
}