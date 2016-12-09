using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemIO
{
    public static class MemoryStreamExt
    {
        #region Convert to StringBuilder

        public static StringBuilder ToStringBuilder(this MemoryStream memoryStream)
        {
            StringBuilder content = new StringBuilder("");

            if (memoryStream == null)
            {
                return content;
            }

            memoryStream.Position = 0;

            using (StreamReader streamReader = new StreamReader(memoryStream))
            {
                content.Append(streamReader.ReadToEnd());
            }

            return content;
        }

        #endregion

        #region Save

        public static void Save(this MemoryStream memoryStream, string path, bool isCovered = true)
        {
            if (memoryStream == null)
            {
                return;
            }

            if (File.Exists(path) && isCovered)
            {
                File.Delete(path);
            }

            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(memoryStream.ToArray());
                memoryStream.Close();
            }
        }

        #endregion
    }
}