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

        #region Verify Slice

        public static bool VerifySlice(this HttpPostedFile file, string fileName, int index, string checksum)
        {
            string verifyPath = GetSlicePathForVerify(fileName, index);
            string md5 = FileHelper.ChecksumMD5(verifyPath);
            return checksum.Equals(md5.ToLower());
        }

        #endregion

        #region Save as Slice

        public static bool SaveAsSlice(this HttpPostedFile file, string fileName, int index, ref OperationResult result)
        {
            string path = GetSlicePathForVerify(fileName, index);

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

        public static List<string> GetAllSlicesPath(string fileName, int count)
        {
            List<string> slices = new List<string>();
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string directory = Path.Combine(DirectoryHelper.TempDirectory, fileNameWithoutExtension);

            for (int index = 0; index < count; index++)
            {
                string sliceName = string.Format(SliceNameFormat, fileNameWithoutExtension, index);
                slices.Add(Path.Combine(directory, sliceName));
            }

            return slices;
        }

        public static string GetSlicePath(string fileName, int index)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string directory = Path.Combine(DirectoryHelper.TempDirectory, fileNameWithoutExtension);
            string sliceName = string.Format(SliceNameFormat, fileNameWithoutExtension, index);
            return Path.Combine(directory, sliceName);
        }

        public static string GetSlicePathForVerify(string fileName, int index)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string directory = Path.Combine(DirectoryHelper.TempDirectory, fileNameWithoutExtension);
            string sliceName = string.Format(SliceNameFormatForVerify, fileNameWithoutExtension, index);
            return Path.Combine(directory, sliceName);
        }

        #endregion

        #region Change Slice Name

        public static bool ChangeSliceName(string fileName, int index, ref OperationResult result)
        {
            string verifyPath = GetSlicePathForVerify(fileName, index);
            string path = GetSlicePath(fileName, index);

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