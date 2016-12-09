using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Common.TestMVC
{
    public class DBConn
    {
        #region Publisher

        public static string PublisherDBConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Lenovo.ESupport.Publisher"].ConnectionString;
            }
        }

        #endregion
    }
}