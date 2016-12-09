using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO
{
    public class PathHelper
    {
        #region Get full extension

        public static string GetFullExtension(string path)
        {
            StringBuilder extension = new StringBuilder("");
            string fileName = Path.GetFileName(path);
            string ext = Path.GetExtension(fileName);

            while (!string.IsNullOrEmpty(ext))
            {
                extension.Insert(0, ext);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                ext = Path.GetExtension(fileName);
            }

            return extension.ToString();
        }

        #endregion
    }
}