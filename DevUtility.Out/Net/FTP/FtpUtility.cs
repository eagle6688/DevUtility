using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FtpUtility
    {
        #region Upload

        public static OperationResult Upload(string uid, string pwd, string path, string ftpPath)
        {
            OperationResult result = new OperationResult();

            if (!File.Exists(path))
            {
                result.SetErrorMessage("File does not exist.");
                return result;
            }

            FtpHelper ftpHelper = new FtpHelper(uid, pwd);

            try
            {
                ftpHelper.Upload(path, ftpPath);
            }
            catch (Exception exception)
            {
                result.SetErrorMessage(exception);
            }

            return result;
        }

        #endregion

        #region Download

        public static OperationResult Download(string uid, string pwd, string ftpPath, string path)
        {
            return Download(uid, pwd, ftpPath, path, true);
        }

        public static OperationResult Download(string uid, string pwd, string ftpPath, string path, bool overwrite)
        {
            OperationResult result = new OperationResult();
            InitDirAndFile(ref result, path, overwrite);

            if (!result.IsSucceeded)
            {
                return result;
            }

            FtpHelper ftpHelper = new FtpHelper(uid, pwd);

            try
            {
                ftpHelper.Download(ftpPath, path);
            }
            catch (Exception exception)
            {
                result.SetErrorMessage(exception);
            }

            return result;
        }

        #endregion

        #region Delete

        public static OperationResult Delete(string uid, string pwd, string ftpPath)
        {
            OperationResult result = new OperationResult();
            FtpHelper ftpHelper = new FtpHelper(uid, pwd);
            string parent = GetParent(ftpPath);

            if (string.IsNullOrEmpty(parent))
            {
                result.SetErrorMessage("Ftp path format error.");
                return result;
            }

            List<FtpFileInfo> elements = new List<FtpFileInfo>();

            try
            {
                elements = ftpHelper.GetFileInfoList(parent);
            }
            catch (Exception exception)
            {
                result.SetErrorMessage(exception);
            }

            if (elements.Count == 0)
            {
                return result;
            }



            return result;
        }

        #endregion

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

        #region Init directory and file

        private static void InitDirAndFile(ref OperationResult result, string path, bool overwrite)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                try
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }
                catch (Exception exception)
                {
                    result.SetErrorMessage(exception);
                }

                return;
            }

            if (overwrite)
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception exception)
                {
                    result.SetErrorMessage(exception);
                }

                return;
            }

            result.SetErrorMessage("File already exists in local machine.");
        }

        #endregion
    }
}