using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemIO
{
    public static class DirectoryInfoExt
    {
        #region Get parent directory

        public static string GetParentDirectory(this DirectoryInfo directoryInfo, int levels)
        {
            if (directoryInfo == null)
            {
                return "";
            }

            DirectoryInfo result = new DirectoryInfo(directoryInfo.FullName);

            while (Directory.Exists(result.FullName) && levels > 0)
            {
                result = result.Parent;
                levels--;
            }

            if (!Directory.Exists(result.FullName))
            {
                return "";
            }

            return result.FullName;
        }

        #endregion
    }
}