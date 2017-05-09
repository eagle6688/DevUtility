using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public enum FtpFileTypes
    {
        Unknow = 0,
        File,
        Directory
    }

    public class FtpFileTypesHelper
    {
        #region Get Unix File Type

        public static FtpFileTypes GetUnixFileType(string index)
        {
            switch (index)
            {
                case "1":
                    return FtpFileTypes.File;

                case "2":
                    return FtpFileTypes.Directory;

                default:
                    return FtpFileTypes.Unknow;
            }
        }

        #endregion
    }
}