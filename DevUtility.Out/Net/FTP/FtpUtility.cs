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
            FtpDeleteHelper ftpDeleteHelper = new FtpDeleteHelper(uid, pwd);

            try
            {
                ftpDeleteHelper.Delete(ftpPath);
            }
            catch (Exception exception)
            {
                result.SetErrorMessage(exception);
            }

            return result;
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