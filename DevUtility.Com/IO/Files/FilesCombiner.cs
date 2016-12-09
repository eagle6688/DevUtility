using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Files
{
    public class FilesCombiner : SingletonInstance<FilesCombiner>
    {
        #region Combine

        public bool Combine(List<string> files, string path, bool deleteFiles = false)
        {
            lock (this)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    foreach (var file in files)
                    {
                        if (!File.Exists(file))
                        {
                            return false;
                        }

                        using (FileStream sliceFileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            if (!sliceFileStream.CanRead)
                            {
                                return false;
                            }

                            int readBytesCount = 0;
                            byte[] bytes = new byte[2048];

                            while ((readBytesCount = sliceFileStream.Read(bytes, 0, bytes.Length)) > 0)
                            {
                                fileStream.Write(bytes, 0, readBytesCount);
                            }

                            fileStream.Flush();
                        }

                        if (deleteFiles)
                        {
                            FileHelper.Delete(file);
                        }
                    }
                }

                DirectoryHelper.DeleteByPath(files[0]);
                return true;
            }
        }

        #endregion
    }
}