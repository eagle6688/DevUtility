using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.Access
{
    public class DataAccess
    {
        #region Attribute

        public DatabaseModel DB { set; get; }

        #endregion

        #region Variable

        IDataAccess dataAccess;

        #endregion

        #region Constructor

        public DataAccess()
        {
            if (DB == null)
            {
                DB = new DatabaseModel();
            }
        }

        public DataAccess(string connName)
        {
            DB = new DatabaseModel();
            DB.ConnectionString = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            DB.GetDbType(ConfigurationManager.ConnectionStrings[connName].ProviderName);
            GetDataAccess(DB);
        }

        public DataAccess(DatabaseModel database)
        {
            DB = database;
            GetDataAccess(DB);
        }

        public DataAccess(string connectionString, DatabaseType type)
        {
            DB.Type = type;
            DB.ConnectionString = connectionString;
            GetDataAccess(DB);
        }

        public DataAccess(string server, string databaseName, string userName, string password, DatabaseType type)
        {
            DatabaseModel database = new DatabaseModel();
            database.Name = databaseName;
            database.Password = password;
            database.Server = server;
            database.UserName = userName;
            database.Type = type;
            database.GetConnectionString();
            GetDataAccess(DB);
        }

        #endregion

        #region Get database's access

        private void GetDataAccess(DatabaseModel database)
        {
            switch (database.Type)
            {
                case DatabaseType.SqlServer:
                    dataAccess = new DataAccessSql(database);
                    break;

                case DatabaseType.Access:
                    dataAccess = new DataAccessSql(database);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Is existed

        public bool IsExisted(string tableName, string whereStr)
        {
            return dataAccess.IsExisted(tableName, whereStr);
        }

        public bool IsExisted(string tableName, string field, object value)
        {
            return dataAccess.IsExisted(tableName, field, value);
        }

        #endregion

        #region Insert data into database

        public int Insert(string tableName, DataTable dt)
        {
            int result = 0;

            if (dt == null || dt.Rows.Count == 0)
            {
                return result;
            }

            foreach (DataRow dr in dt.Rows)
            {
                StringBuilder columns = new StringBuilder("");
                StringBuilder values = new StringBuilder("");

                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    columns.Append(dr.Table.Columns[i]);
                    columns.Append(",");
                    values.Append("'");
                    values.Append(dr[i]);
                    values.Append("',");
                }

                result += Insert(tableName, columns.ToString().TrimEnd(','), values.ToString().TrimEnd(','));
            }

            return result;
        }

        public int Insert(string tableName, string columns, string values)
        {
            return dataAccess.Insert(tableName, columns, values);
        }

        public int InsertSelfGrowing(string tableName, string columns, string values)
        {
            return dataAccess.InsertSelfGrowing(tableName, columns, values);
        }

        #endregion

        #region Modifying database data

        public int Update(string tableName, string setStr)
        {
            return dataAccess.Update(tableName, setStr);
        }

        public int Update(string tableName, string setStr, string whereStr)
        {
            return dataAccess.Update(tableName, setStr, whereStr);
        }

        #endregion

        #region Deleting database data

        public int Delete(string tableName, string whereStr)
        {
            return dataAccess.Delete(tableName, whereStr);
        }

        #endregion

        #region Get single data

        public object GetSingle(string field, string tableName, string whereStr)
        {
            return dataAccess.GetSingle(field, tableName, whereStr);
        }

        public object GetSingle(string field, string tableName, string whereStr, string orderStr)
        {
            return dataAccess.GetSingle(field, tableName, whereStr, orderStr);
        }

        #endregion

        #region Get row

        public DataTable GetRow(string columns, string tableName, string whereStr)
        {
            return dataAccess.GetRow(columns, tableName, whereStr);
        }

        #endregion

        #region Get data list

        public DataTable GetList(string columns, string tableName)
        {
            return dataAccess.GetList(columns, tableName);
        }

        public DataTable GetList(string columns, string tableName, string whereStr)
        {
            return dataAccess.GetList(columns, tableName, whereStr);
        }

        public DataTable GetList(string columns, string tableName, string whereStr, string orderStr)
        {
            return dataAccess.GetList(columns, tableName, whereStr, orderStr);
        }

        #endregion

        #region Get paging data list

        public DataTable GetPagingData(string columns, string tableName, int pageIndex, int pageSize, string orderStr)
        {
            return dataAccess.GetPagingData(columns, tableName, pageIndex, pageSize, orderStr);
        }

        public DataTable GetPagingData(string columns, string tableName, int pageIndex, int pageSize, string whereStr, string orderStr)
        {
            return dataAccess.GetPagingData(columns, tableName, pageIndex, pageSize, whereStr, orderStr);
        }

        #endregion

        #region Get records' count

        public int GetRecordsCount(string tableName)
        {
            return dataAccess.GetRecordsCount(tableName);
        }

        public int GetRecordsCount(string tableName, string whereStr)
        {
            return dataAccess.GetRecordsCount(tableName, whereStr);
        }

        public int GetRecordsCount(string tableName, string field, object value)
        {
            return dataAccess.GetRecordsCount(tableName, field, value);
        }

        #endregion
    }
}