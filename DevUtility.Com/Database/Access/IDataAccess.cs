using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.Access
{
    public interface IDataAccess
    {
        #region Is existed

        bool IsExisted(string tableName, string whereStr);

        bool IsExisted(string tableName, string field, object value);

        #endregion

        #region Insert data into database

        int Insert(string tableName, string columns, string values);

        int InsertSelfGrowing(string tableName, string columns, string values);

        #endregion

        #region Modifying database data

        int Update(string tableName, string setStr);

        int Update(string tableName, string setStr, string whereStr);

        #endregion

        #region Deleting database data

        int Delete(string tableName, string whereStr);

        #endregion

        #region Get single data

        object GetSingle(string field, string tableName, string whereStr);

        object GetSingle(string field, string tableName, string whereStr, string orderStr);

        #endregion

        #region Get row data

        DataTable GetRow(string columns, string tableName, string whereStr);

        #endregion

        #region Get data list

        DataTable GetList(string columns, string tableName);

        DataTable GetList(string columns, string tableName, string whereStr);

        DataTable GetList(string columns, string tableName, string whereStr, string orderStr);

        #endregion

        #region Get paging data list

        DataTable GetPagingData(string columns, string tableName, int pageIndex, int pageSize, string orderStr);

        DataTable GetPagingData(string columns, string tableName, int pageIndex, int pageSize, string whereStr, string orderStr);

        #endregion

        #region Get records' count

        int GetRecordsCount(string tableName);

        int GetRecordsCount(string tableName, string whereStr);

        int GetRecordsCount(string tableName, string field, object value);

        #endregion
    }
}