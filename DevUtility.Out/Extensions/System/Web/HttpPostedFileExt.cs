using DevUtility.Com.Application.Log;
using DevUtility.Com.IO;
using DevUtility.Com.IO.Files;
using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DevUtility.Out.Extensions.System.Web
{
    public static class HttpPostedFileExt
    {
        #region Variables

        public const string SliceNameFormatForVerify = "{0}-{1}-Verify";

        public const string SliceNameFormat = "{0}-{1}";

        #endregion

        #region Get Slice Name

        public static string GetSliceName(string fileName, int index)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            return string.Format(SliceNameFormat, fileNameWithoutExtension, index);
        }

        public static string GetSliceNameForVerify(string fileName, int index)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            return string.Format(SliceNameFormatForVerify, fileNameWithoutExtension, index);
        }

        #endregion

        #region Verify Slice

        public static bool VerifySlice(this HttpPostedFile file, string saveDir, string fileName, int index, string checksum)
        {
            string verifyPath = GetSlicePathForVerify(saveDir, fileName, index);
            string md5 = FileHelper.ChecksumMD5(verifyPath);
            return checksum.Equals(md5.ToLower());
        }

        #endregion

        #region Save as Slice

        public static bool SaveAsSlice(this HttpPostedFile file, string saveDir, string fileName, int index, ref OperationResult result)
        {
            string path = GetSlicePathForVerify(saveDir, fileName, index);

            if (!DirectoryHelper.CreatByPath(path))
            {
                result.SetErrorMessage(string.Format("Create directory of {0} failed.", path));
                return false;
            }

            if (File.Exists(path))
            {
                if (!FileHelper.Delete(path))
                {
                    result.SetErrorMessage(string.Format("{0} has existed and can not be deleted.", path));
                    return false;
                }
            }

            try
            {
                file.SaveAs(path);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                result.SetErrorMessage(string.Format("Save {0} failed.", path));
                return false;
            }
        }

        #endregion

        #region Get Slice Path

        public static List<string> GetAllSlicesPath(string saveDir, string fileName, int count)
        {
            List<string> slices = new List<string>();

            for (int index = 0; index < count; index++)
            {
                string sliceName = GetSliceName(fileName, index);
                slices.Add(Path.Combine(saveDir, sliceName));
            }

            return slices;
        }

        public static string GetSlicePath(string saveDir, string fileName, int index)
        {
            string sliceName = GetSliceName(fileName, index);
            return Path.Combine(saveDir, sliceName);
        }

        public static string GetSlicePathForVerify(string saveDir, string fileName, int index)
        {
            string sliceName = GetSliceNameForVerify(fileName, index);
            return Path.Combine(saveDir, sliceName);
        }

        #endregion

        #region Change Slice Name

        public static bool ChangeSliceName(string saveDir, string fileName, int index, ref OperationResult result)
        {
            string verifyPath = GetSlicePathForVerify(saveDir, fileName, index);
            string path = GetSlicePath(saveDir, fileName, index);

            if (!File.Exists(verifyPath))
            {
                result.SetErrorMessage(string.Format("{0} does not exist.", verifyPath));
                return false;
            }

            if (File.Exists(path))
            {
                if (!FileHelper.Delete(path))
                {
                    result.SetErrorMessage(string.Format("{0} has existed and can not be deleted.", path));
                    return false;
                }
            }

            try
            {
                FileInfo fileInfo = new FileInfo(verifyPath);
                fileInfo.MoveTo(path);
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                result.SetErrorMessage(string.Format("Move from {0} to {1} failed.", verifyPath, path));
                return false;
            }

            return true;
        }

        #endregion
    }
}