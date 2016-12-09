using DevUtility.Com.Database.DBHelper;
using DevUtility.Test.Common.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Data
{
    public class BaseDal<T> : BaseDataAccessHelper<T> where T : class, new()
    {
        protected DBHelperSQL dBHelperSQL = new DBHelperSQL(AppConfigHelper.TestDBConn);
    }
}