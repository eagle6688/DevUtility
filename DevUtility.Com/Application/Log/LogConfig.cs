using DevUtility.Com.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Application.Log
{
    public class LogConfig
    {
        #region Log's folder

        public const string LogFolder = "Logs";

        public const string ErrorLogFolder = "Error";

        public const string InfoLogFolder = "Info";

        #endregion

        #region Log file name

        public static string LogFileName
        {
            get
            {
                DateTime time = DateTime.Now;
                return string.Format("{0}.txt", time.Hour);
            }
        }

        #endregion

        #region Error log

        public static string ErrorLogDirectory
        {
            get
            {
                return Path.Combine(DirectoryHelper.BaseDirectory, LogFolder, ErrorLogFolder, DirectoryHelper.GetDateDirectory());
            }
        }

        #endregion

        #region Info log

        public static string InfoLogDirectory
        {
            get
            {
                return Path.Combine(DirectoryHelper.BaseDirectory, LogFolder, InfoLogFolder, DirectoryHelper.GetDateDirectory());
            }
        }

        #endregion
    }
}