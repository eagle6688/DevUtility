using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Common.Winform
{
    public class AppConfigHelper
    {
        #region DBConn

        public static string TestDBConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            }
        }

        public static string MyTestDB
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["mytestdb"].ConnectionString;
            }
        }

        #endregion

        public static string Test
        {
            get
            {
                return ConfigurationManager.AppSettings["Test"];
            }
        }
    }
}