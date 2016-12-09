using DevUtility.Com.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Common.Winform
{
    public class IOConfig
    {
        #region Base64

        private const string Base64FilePartPath = "App_Data\\Files\\Base64String.txt";

        public static string Base64FilePath
        {
            get
            {
                return Path.Combine(DirectoryHelper.BaseWinformDirectory, Base64FilePartPath);
            }
        }

        #endregion

        #region Images

        public const string ImagesPartCatalogue = "App_Data\\Images";

        public static string ImagesCatalogue
        {
            get
            {
                return Path.Combine(DirectoryHelper.BaseWinformDirectory, ImagesPartCatalogue);
            }
        }

        #endregion
    }
}