using DevUtility.Com.Application.Log;
using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevUtility.Com.Database.DBHelper
{
    public class BigDataHelper
    {
        #region Variable

        /// <summary>
        /// Connection string
        /// </summary>
        string ConnectionString = "";

        #endregion

        #region Constructed

        public BigDataHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #endregion

        #region Get mapping list

        public List<SqlBulkCopyColumnMapping> GetMappingList(DataTable dt)
        {
            List<SqlBulkCopyColumnMapping> mappingList = new List<SqlBulkCopyColumnMapping>();

            foreach (DataColumn column in dt.Columns)
            {
                SqlBulkCopyColumnMapping mapping = new SqlBulkCopyColumnMapping(column.ColumnName, column.ColumnName);
                mappingList.Add(mapping);
            }

            return mappingList;
        }

        public List<SqlBulkCopyColumnMapping> GetMappingList(List<string> sourceColumns, List<string> destinationColumns)
        {
            List<SqlBulkCopyColumnMapping> mappingList = new List<SqlBulkCopyColumnMapping>();

            if (sourceColumns.Count == destinationColumns.Count)
            {
                for (int i = 0; i < destinationColumns.Count; i++)
                {
                    SqlBulkCopyColumnMapping mapping = new SqlBulkCopyColumnMapping(sourceColumns[i], destinationColumns[i]);
                    mappingList.Add(mapping);
                }
            }

            return mappingList;
        }

        #endregion

        #region Excute

        private bool Excute(DataTable table, List<SqlBulkCopyColumnMapping> mappingList)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionString))
            {
                bulkCopy.DestinationTableName = table.TableName;
                bulkCopy.BatchSize = table.Rows.Count;

                foreach (SqlBulkCopyColumnMapping mapping in mappingList)
                {
                    bulkCopy.ColumnMappings.Add(mapping);
                }

                try
                {
                    bulkCopy.WriteToServer(table);
                }
                catch (Exception exception)
                {
                    LogHelper.Error(exception);
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Insert

        public bool Insert(DataTable dt)
        {
            List<SqlBulkCopyColumnMapping> mappingList = GetMappingList(dt);
            return Excute(dt, mappingList);
        }

        public bool Insert<TModel>(string tableName, List<TModel> list, List<string> excludeProperties) where TModel : class, new()
        {
            DataTable dt = ListHelper.ToDataTable<TModel>(list, excludeProperties);
            dt.TableName = tableName;
            return Insert(dt);
        }

        public bool Insert(DataTable dt, List<string> sourceColumns, List<string> destinationColumns)
        {
            List<SqlBulkCopyColumnMapping> mappingList = GetMappingList(sourceColumns, destinationColumns);
            return Excute(dt, mappingList);
        }

        #endregion
    }
}