using DevUtility.Com.IO;
using DevUtility.Com.IO.Files;
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

        public static bool SaveAsSlice(this HttpRequest httpRequest)
        {
            if (!httpRequest.IsValidSliceRequest())
            {
                return false;
            }

            int index = int.Parse(httpRequest["sliceIndex"]);
            string fileName = httpRequest["fileName"];

            if (!httpRequest.Files[0].SaveAsSlice(fileName, index))
            {
                return false;
            }

            string sliceChecksum = httpRequest["sliceChecksum"];

            if (!string.IsNullOrWhiteSpace(sliceChecksum))
            {
                if (!httpRequest.Files[0].VerifySlice(fileName, index, sliceChecksum))
                {
                    return false;
                }
            }

            if (!HttpPostedFileExt.ChangeSliceName(fileName, index))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Combine Slices

        public static bool CombineSlices(this HttpRequest httpRequest, string path)
        {
            int count = int.Parse(httpRequest["sliceCount"]);
            var slices = HttpPostedFileExt.GetAllSlicesPath(httpRequest["fileName"], count);

            if (!HasSavedAllSlices(slices))
            {
                return false;
            }

            return FilesCombiner.Instance.Combine(slices, path, true);
        }

        #endregion

        #region Is Valid Slice Request

        private static bool IsValidSliceRequest(this HttpRequest httpRequest)
        {
            if (httpRequest.Files == null || httpRequest.Files.Count == 0)
            {
                return false;
            }

            string sliceIndex = httpRequest["sliceIndex"];
            string sliceCount = httpRequest["sliceCount"];
            string fileName = httpRequest["fileName"];

            if (string.IsNullOrWhiteSpace(sliceIndex) || string.IsNullOrWhiteSpace(sliceCount) || string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            int temp = 0;

            if (!int.TryParse(httpRequest["sliceIndex"], out temp))
            {
                return false;
            }

            if (!int.TryParse(httpRequest["sliceCount"], out temp))
            {
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