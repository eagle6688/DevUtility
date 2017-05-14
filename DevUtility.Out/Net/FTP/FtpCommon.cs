using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FtpCommon
    {
        #region Get Parent

        public static string GetParent(string ftpPath)
        {
            string path = ftpPath.TrimEnd('/');
            List<string> list = path.Split('/').ToList();

            if (list.Count == 0)
            {
                return null;
            }

            list.RemoveAt(list.Count - 1);
            return string.Join("/", list);
        }

        #endregion

        #region Get Last

        public static string GetLast(string ftpPath)
        {
            string path = ftpPath.TrimEnd('/');
            string[] array = path.Split('/');
            return array[array.Length - 1];
        }

        #endregion

        #region Append path

        public static string AppendPath(string directory, string path)
        {
            return string.Concat(directory.TrimEnd('/'), '/', path);
        }

        #endregion
    }
}