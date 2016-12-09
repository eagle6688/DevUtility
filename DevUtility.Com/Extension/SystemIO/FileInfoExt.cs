using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemIO
{
    public static class FileInfoExt
    {
        #region Compare LastWriteTime To

        public static int CompareLastWriteTimeTo(this FileInfo fileInfo1, FileInfo fileInfo2)
        {
            DateTime f1Time = fileInfo1.LastWriteTime;
            DateTime f2Time = fileInfo2.LastWriteTime;
            return f1Time.CompareTo(f2Time);
        }

        #endregion
    }
}