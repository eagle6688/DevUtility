using DevUtility.Com.Application.Log;
using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Files
{
    public class FileHelper
    {
        #region Variable

        public static List<string> AllowedExtensions = new List<string>() { ".txt", ".htm", ".html", ".shtml", ".css", ".xml" };

        #endregion

        #region Get content

        public static StringBuilder GetContent(string path, string encodingName = "")
        {
            StringBuilder content = new StringBuilder("");

            if (!File.Exists(path))
            {
                return content;
            }

            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fileStream, EncodingHelper.GetEncoding(encodingName)))
            {
                content.Append(streamReader.ReadToEnd());
            }

            return content;
        }

        #endregion

        #region Get file name

        public static string GetFileName_DateTime(string extension)
        {
            Random random = new Random();
            return string.Format("{0}{1}{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), random.Next(100, 1000), extension);
        }

        public static string GetFileName_Guid(string extension)
        {
            return string.Format("{0}{1}", Guid.NewGuid().ToString(), extension);
        }

        #endregion

        #region Get bytes

        public static byte[] GetBytes(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                long length = fileStream.Length;
                byte[] fileBytes = new byte[length];
                fileStream.Read(fileBytes, 0, fileBytes.Length);
                return fileBytes;
            }
        }

        #endregion

        #region Delete file

        public static bool Delete(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception exception)
                {
                    LogHelper.Error(exception);
                    return false;
                }
            }

            return true;
        }

        public static void DeleteForCreate(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return;
            }

            DirectoryHelper.CreatByPath(path);
        }

        #endregion

        #region Md5 checksum

        public static string ChecksumMD5(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return DevUtility.Com.Data.Cryptography.MD5Helper.Encrypt(bytes);
        }

        #endregion

        #region Sha1 checksum

        public static string ChecksumSHA1(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            string result = DevUtility.Com.Data.Cryptography.SHA1Helper.Encrypt(bytes);
            bytes = null;
            GC.Collect();
            return result;
        }

        #endregion

        #region Sha256 checksum

        public static string ChecksumSHA256(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return DevUtility.Com.Data.Cryptography.SHA256Helper.Encrypt(bytes);
        }

        #endregion
    }
}