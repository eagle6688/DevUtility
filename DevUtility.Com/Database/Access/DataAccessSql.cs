using DevUtility.Com.Database.DBHelper;
using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.Access
{
    public class DataAccessSql : IDataAccess
    {
        #region Variable

        IDbHelper dbHelper = null;

        DatabaseModel database = new DatabaseModel();

        #endregion

        #region Constructed function

        public DataAccessSql(DatabaseModel _database)
        {
            database = _database;

            switch (database.Type)
            {
                case DatabaseType.Access:
                    dbHelper = new DBHelperOleDb(database.ConnectionString);
                    break;

                case DatabaseType.SqlServer:
                    dbHelper = new DBHelperSQL(database.ConnectionString);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Get database connection state

        public bool ConnState()
        {
            return dbHelper.CanConnected();
        }

        #endregion

        #region Is existed

        public bool IsExisted(string tableName, string whereStr)
        {
            int count = GetRecordsCount(tableName, whereStr);
            return count > 0 ? true : false;
        }

        public bool IsExisted(string tableName, string field, object value)
        {
            int count = GetRecordsCount(tableName, field, value);
            return count > 0 ? true : false;
        }

        #endregion

        #region Insert data into database

        public int Insert(string tableName, string columns, string values)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into " + tableName + "(" + columns + ") ");
            sqlStr.Append("values(" + values + ")");
            int rows = dbHelper.ExecuteSql(sqlStr.ToString());
            return rows;
        }

        public int InsertSelfGrowing(string tableName, string columns, string values)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into " + tableName + "(" + columns + ") ");
            sqlStr.Append("values(" + values + ");");
            sqlStr.Append("select @@IDENTITY");
            object result = dbHelper.ExecuteScalar(sqlStr.ToString());

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Modifying database data

        public int Update(string tableName, string setStr)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update " + tableName + " ");
            sqlStr.Append("set " + setStr + " ");
            int rows = dbHelper.ExecuteSql(sqlStr.ToString());
            return rows;
        }

        public int Update(string tableName, string setStr, string whereStr)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("update " + tableName + " ");
            sqlStr.Append("set " + setStr + " ");
            sqlStr.Append("where " + whereStr);
            int rows = dbHelper.ExecuteSql(sqlStr.ToString());
            return rows;
        }

        #endregion

        #region Deleting database data

        public int Delete(string tableName, string whereStr)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("delete from " + tableName + " ");
            sqlStr.Append("where " + whereStr);
            int rows = dbHelper.ExecuteSql(sqlStr.ToString());
            return rows;
        }

        #endregion

        #region Get single data

        public object GetSingle(string field, string tableName, string whereStr)
        {
            object result = null;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + field + " ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + whereStr + " ");
            DataSet ds = dbHelper.Query(sqlStr.ToString());

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    result = dt.Rows[0][0];
                }
            }

            return result;
        }

        public object GetSingle(string field, string tableName, string whereStr, string orderStr)
        {
            object result = null;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + field + " ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + whereStr + " ");
            sqlStr.Append("order by " + orderStr);
            DataSet ds = dbHelper.Query(sqlStr.ToString());

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    result = dt.Rows[0][0];
                }
            }

            return result;
        }

        #endregion

        #region Get row data

        public DataTable GetRow(string columns, string tableName, string whereStr)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + columns + " ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + whereStr + " ");
            DataSet ds = dbHelper.Query(sqlStr.ToString());
            return ds.Tables[0];
        }

        #endregion

        #region Get data list

        public DataTable GetList(string columns, string tableName)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + columns + " ");
            sqlStr.Append("from " + tableName + " ");
            DataSet ds = dbHelper.Query(sqlStr.ToString());
            return ds.Tables[0];
        }

        public DataTable GetList(string columns, string tableName, string whereStr)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + columns + " ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + whereStr + " ");
            DataSet ds = dbHelper.Query(sqlStr.ToString());
            return ds.Tables[0];
        }

        public DataTable GetList(string columns, string tableName, string whereStr, string orderStr)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + columns + " ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + whereStr + " ");
            sqlStr.Append("order by " + orderStr + " ");
            DataSet ds = dbHelper.Query(sqlStr.ToString());
            return ds.Tables[0];
        }

        #endregion

        #region Get paging data list

        public DataTable GetPagingData(string columns, string tableName, int pageIndex, int pageSize, string orderStr)
        {
            StringBuilder sqlStr = new StringBuilder();

            if (pageIndex == 1)
            {
                sqlStr.Append("select top(" + pageSize + ") " + columns + " ");
                sqlStr.Append("from " + tableName + " ");
                sqlStr.Append("order by " + orderStr);
            }
            else
            {
                sqlStr.Append("select " + columns + " ");
                sqlStr.Append("from(select ROW_NUMBER() OVER (order by " + orderStr + ") as RowNum, " + columns);
                sqlStr.Append("     from " + tableName);
                sqlStr.Append("     ) as T ");
                sqlStr.Append("where RowNum between " + ((pageIndex - 1) * pageSize + 1) + " and " + pageIndex * pageSize + " ");
                sqlStr.Append("order by " + orderStr);
            }

            DataSet ds = dbHelper.Query(sqlStr.ToString());
            return ds.Tables[0];
        }

        public DataTable GetPagingData(string columns, string tableName, int pageIndex, int pageSize, string whereStr, string orderStr)
        {
            StringBuilder sqlStr = new StringBuilder();

            if (pageIndex == 1)
            {
                sqlStr.Append("select top(" + pageSize + ") " + columns + " ");
                sqlStr.Append("from " + tableName + " ");
                sqlStr.Append("where " + whereStr + " ");
                sqlStr.Append("order by " + orderStr);
            }
            else
            {
                sqlStr.Append("select " + columns + " ");
                sqlStr.Append("from(select ROW_NUMBER() OVER (order by " + orderStr + ") as RowNum, " + columns);
                sqlStr.Append("     from " + tableName);
                sqlStr.Append("     where " + whereStr);
                sqlStr.Append("     ) as T ");
                sqlStr.Append("where RowNum between " + ((pageIndex - 1) * pageSize + 1) + " and " + pageIndex * pageSize + " ");
                sqlStr.Append("order by " + orderStr);
            }

            DataSet ds = dbHelper.Query(sqlStr.ToString());
            return ds.Tables[0];
        }

        #endregion

        #region Get records' count

        public int GetRecordsCount(string tableName)
        {
            int count = 0;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select count(0) ");
            sqlStr.Append("from " + tableName + " ");
            DataTable dt = dbHelper.Query(sqlStr.ToString()).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0][0].ToString());
            }

            return count;
        }

        public int GetRecordsCount(string tableName, string whereStr)
        {
            int count = 0;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select count(0) ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + whereStr);
            DataTable dt = dbHelper.Query(sqlStr.ToString()).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0][0].ToString());
            }

            return count;
        }

        public int GetRecordsCount(string tableName, string field, object value)
        {
            int count = 0;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select count(0) ");
            sqlStr.Append("from " + tableName + " ");
            sqlStr.Append("where " + field + " = '" + value + "'");
            DataTable dt = dbHelper.Query(sqlStr.ToString()).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0][0].ToString());
            }

            return count;
        }

        #endregion

        #region Get database information

        public DataTable GetTableFields(string tableName)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select name from syscolumns where id=object_id('");
            sqlStr.Append(tableName);
            sqlStr.Append("')");
            DataSet ds = dbHelper.Query(sqlStr.ToString());
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public string GetTableFieldsStr(string tableName)
        {
            StringBuilder result = new StringBuilder();
            DataTable dt = GetTableFields(tableName);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Append(dr[0].ToString());
                    result.Append(",");
                }
            }

            return result.ToString().TrimEnd(',');
        }

        #endregion

        #region Set table identity

        public int SetIdentity(string table, bool isOn)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("set IDENTITY_Insert ");
            sqlStr.Append(table);

            if (isOn)
            {
                sqlStr.Append(" on");
            }
            else
            {
                sqlStr.Append(" off");
            }

            return dbHelper.ExecuteSql(sqlStr.ToString());
        }

        #endregion

        #region Get repeated records

        public DataTable GetRepeatedRecords(string fields, string field, string table)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select " + fields + " ");
            sqlStr.Append("from " + table + " ");
            sqlStr.Append("where " + field + " in (select " + field + " ");
            sqlStr.Append("from " + table + " ");
            sqlStr.Append("group by " + field + " ");
            sqlStr.Append("having count(" + field + ") > 1)");
            return dbHelper.Query(sqlStr.ToString()).Tables[0];
        }

        #endregion
    }
}