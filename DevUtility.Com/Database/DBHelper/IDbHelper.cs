using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.DBHelper
{
    public interface IDbHelper
    {
        #region Can Connected

        bool CanConnected();

        #endregion

        #region Execute sql

        int ExecuteSql(string sqlString);

        #endregion

        #region Get single

        object ExecuteScalar(string sqlString);

        #endregion

        #region Query

        DataSet Query(string sqlString);

        #endregion
    }
}