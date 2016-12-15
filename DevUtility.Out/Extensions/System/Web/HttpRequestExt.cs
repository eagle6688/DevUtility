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
    public static class HttpRequestExt
    {
        #region Save as Slice

        public static bool SaveAsSlice(this HttpRequest httpRequest, ref OperationResult result)
        {
            if (!httpRequest.IsValidSliceRequest(ref result))
            {
                return false;
            }

            int index = int.Parse(httpRequest["sliceIndex"]);
            string fileName = httpRequest["fileName"];

            if (!httpRequest.Files[0].SaveAsSlice(fileName, index, ref result))
            {
                return false;
            }

            string sliceChecksum = httpRequest["sliceChecksum"];

            if (!string.IsNullOrWhiteSpace(sliceChecksum))
            {
                if (!httpRequest.Files[0].VerifySlice(fileName, index, sliceChecksum))
                {
                    result.SetErrorMessage(string.Format("MD5 value {0} for {1} is invalid."));
                    return false;
                }
            }

            if (!HttpPostedFileExt.ChangeSliceName(fileName, index, ref result))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Combine Slices

        public static bool CombineSlices(this HttpRequest httpRequest, string path, ref OperationResult result)
        {
            int count = int.Parse(httpRequest["sliceCount"]);
            var slices = HttpPostedFileExt.GetAllSlicesPath(httpRequest["fileName"], count);

            if (!HasSavedAllSlices(slices))
            {
                result.SetMessage("Some slices have not uploaded completely!");
                return false;
            }

            FilesCombiner.Instance.Combine(slices, path, true, ref result);
            return result.IsSucceeded;
        }

        #endregion

        #region Is Valid Slice Request

        private static bool IsValidSliceRequest(this HttpRequest httpRequest, ref OperationResult result)
        {
            if (httpRequest.Files == null || httpRequest.Files.Count == 0)
            {
                result.SetErrorMessage("HttpRequest has no file!");
                return false;
            }

            string sliceIndex = httpRequest["sliceIndex"];
            string sliceCount = httpRequest["sliceCount"];
            string fileName = httpRequest["fileName"];

            if (string.IsNullOrWhiteSpace(sliceIndex) || string.IsNullOrWhiteSpace(sliceCount) || string.IsNullOrWhiteSpace(fileName))
            {
                result.SetErrorMessage("HttpRequest has parameter problems!");
                return false;
            }

            int temp = 0;

            if (!int.TryParse(httpRequest["sliceIndex"], out temp))
            {
                result.SetErrorMessage("Format of sliceIndex is invalid!");
                return false;
            }

            if (!int.TryParse(httpRequest["sliceCount"], out temp))
            {
                result.SetErrorMessage("Format of sliceCount is invalid!");
                return false;
            }

            return true;
        }

        #endregion

        #region Has Saved All Slices

        private static bool HasSavedAllSlices(List<string> slices)
        {
            foreach (var slice in slices)
            {
                FileInfo fileInfo = new FileInfo(slice);

                if (!fileInfo.Exists)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}