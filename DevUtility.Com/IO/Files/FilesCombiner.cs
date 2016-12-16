using DevUtility.Com.Base;
using DevUtility.Com.Model;
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

        public bool Combine(List<string> files, string path, ref OperationResult result)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                foreach (var file in files)
                {
                    if (!File.Exists(file))
                    {
                        result.SetErrorMessage(string.Format("{0} does not exist.", file));
                        return false;
                    }

                    using (FileStream sliceFileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        if (!sliceFileStream.CanRead)
                        {
                            result.SetErrorMessage(string.Format("{0} can not read.", file));
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
                }
            }

            return true;
        }

        #endregion

        #region Delete Slices

        public void DeleteSlices(List<string> files, ref OperationResult result)
        {
            foreach(string file in files)
            {
                if (!FileHelper.Delete(file))
                {
                    result.SetMessage(string.Format("Delete {0} failed!", file));
                }
            }
        }

        #endregion
    }
}