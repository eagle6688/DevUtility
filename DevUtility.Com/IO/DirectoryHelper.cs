using DevUtility.Com.Application.Log;
using DevUtility.Com.Extension.SystemIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO
{
    public class DirectoryHelper
    {
        #region Base Directory

        public static string BaseDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string BaseWinformDirectory
        {
            get
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);
                return directoryInfo.GetParentDirectory(2);
            }
        }

        #endregion

        #region Get date directory

        public static string DateDirectory
        {
            get
            {
                return GetDateDirectory();
            }
        }

        public static string GetDateDirectory()
        {
            DateTime time = DateTime.Now.Date;
            return string.Format("{0}\\{1}\\{2}", time.Year, time.Month, time.Day);
        }

        #endregion

        #region Create

        public static bool Create(string directory)
        {
            if (!Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch (Exception exception)
                {
                    LogHelper.Error(exception);
                    return false;
                }
            }

            return true;
        }

        public static bool CreatByPath(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return Create(fileInfo.DirectoryName);
        }

        #endregion

        #region Delete

        public static bool Delete(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static bool DeleteByPath(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return Delete(fileInfo.DirectoryName);
        }

        #endregion

        #region Temp directory

        public static string TempDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, "temp");
            }
        }

        #endregion
    }
}