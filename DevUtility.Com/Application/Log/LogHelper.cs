using DevUtility.Com.Extension.SystemExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevUtility.Com.Application.Log
{
    public class LogHelper
    {
        #region Save

        public static bool Save(string directory, string content)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                return true;
            }

            try
            {
                LogHandler logHandler = new LogHandler(directory, new StringBuilder(content));
                ThreadStart threadStart = new ThreadStart(logHandler.Save);
                Thread thread = new Thread(threadStart);
                thread.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Error

        public static bool Error(Exception exception)
        {
            if (exception == null)
            {
                return true;
            }

            string content = exception.ToExceptionContent().ToString();
            Console.WriteLine(content);

            return Save(LogConfig.ErrorLogDirectory, content);
        }

        public static bool Error(string directory, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = LogConfig.ErrorLogDirectory;
            }

            if (exception == null)
            {
                return true;
            }

            return Save(directory, exception.ToExceptionContent().ToString());
        }

        public static bool Error(string content)
        {
            return Error(null, content);
        }

        public static bool Error(string directory, string message)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = LogConfig.ErrorLogDirectory;
            }

            return Save(directory, message);
        }

        #endregion

        #region Info

        public static bool Info(string content)
        {
            return Info(null, content);
        }

        public static bool Info(string directory, string content)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = LogConfig.InfoLogDirectory;
            }

            Console.WriteLine(content);
            return Save(directory, content);
        }

        #endregion
    }
}