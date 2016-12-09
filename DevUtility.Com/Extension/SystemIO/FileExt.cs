using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemIO
{
    public static class FileExt
    {
        #region MoveOverWrite

        public static void MoveOverWrite(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName, true);
            File.Delete(sourceFileName);
        }

        #endregion
    }
}