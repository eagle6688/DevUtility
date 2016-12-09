using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Files
{
    /// <summary>
    /// Reading txt file use FileHelper.GetContent instead.
    /// </summary>
    public class TxtHelper
    {
        #region Save

        public static bool Save(string path, StringBuilder content)
        {
            if (content == null || content.Length == 0)
            {
                return true;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(path);
                DirectoryHelper.Create(fileInfo.DirectoryName);
                Stream stream = fileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(content);
                    streamWriter.WriteLine();
                    streamWriter.Flush();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Append

        public static bool Append(string path, StringBuilder content)
        {
            if (content == null || content.Length == 0)
            {
                return true;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(path);
                DirectoryHelper.Create(fileInfo.DirectoryName);
                Stream stream = fileInfo.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);

                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(content);
                    streamWriter.WriteLine();
                    streamWriter.Flush();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}