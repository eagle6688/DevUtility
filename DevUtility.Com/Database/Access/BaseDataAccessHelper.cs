using DevUtility.Com.Base;
using DevUtility.Com.Extension.SystemData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.DBHelper
{
    public class BaseDataAccessHelper<T> : SingletonInstance<T> where T : class, new()
    {
        #region Get value

        public TValue GetValue<TValue>(string connectionString, string sqlString, params SqlParameter[] parameters)
        {
            var list = GetValues<TValue>(connectionString, sqlString, parameters);

            if (list == null || list.Count == 0)
            {
                return default(TValue);
            }

            return list[0];
        }

        #endregion

        #region Get entity

        public TEntity GetEntity<TEntity>(string connectionString, string sqlString, params SqlParameter[] parameters) where TEntity : class, new()
        {
            TEntity entity = null;
            DataSet ds = DBHelperSQL.Create(connectionString).Query(sqlString, parameters);

            if (ds == null)
            {
                return entity;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                entity = ds.Tables[0].Rows[0].ConvertToModel<TEntity>();
            }

            ds.Dispose();
            return entity;
        }

        public TEntity GetEntityByProcedure<TEntity>(string connectionString, string procedureName, params SqlParameter[] parameters) where TEntity : class, new()
        {
            TEntity entity = null;
            DataSet ds = DBHelperSQL.Create(connectionString).RunProcedure(procedureName, parameters);

            if (ds == null)
            {
                return entity;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                entity = ds.Tables[0].Rows[0].ConvertToModel<TEntity>();
            }

            ds.Dispose();
            return entity;
        }

        #endregion

        #region Get list

        public List<TValue> GetValues<TValue>(string connectionString, string sqlString, params SqlParameter[] parameters)
        {
            List<TValue> list = new List<TValue>();
            DataSet ds = DBHelperSQL.Create(connectionString).Query(sqlString, parameters);

            if (ds == null)
            {
                return list;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ConvertToValues<TValue>();
            }

            ds.Dispose();
            return list;
        }

        public List<TEntity> GetList<TEntity>(string connectionString, string sqlString) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();
            DataSet ds = DBHelperSQL.Create(connectionString).Query(sqlString);

            if (ds == null)
            {
                return list;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ConvertToList<TEntity>();
            }

            ds.Dispose();
            return list;
        }

        public List<TEntity> GetList<TEntity>(string connectionString, string sqlString, params SqlParameter[] parameters) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();
            DataSet ds = DBHelperSQL.Create(connectionString).Query(sqlString, parameters);

            if (ds == null)
            {
                return list;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ConvertToList<TEntity>();
            }

            ds.Dispose();
            return list;
        }

        public List<TEntity> GetListByProcedure<TEntity>(string connectionString, string procedureName, params SqlParameter[] parameters) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();
            DataSet ds = DBHelperSQL.Create(connectionString).RunProcedure(procedureName, parameters);

            if (ds == null)
            {
                return list;
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ConvertToList<TEntity>();
            }

            ds.Dispose();
            return list;
        }

        #endregion

        #region Get paging list

        public List<TEntity> GetPagingList<TEntity>(string connectionString, string table, string condition, string orderBy, int pageIndex, int pageSize) where TEntity : class, new()
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(orderBy))
            {
                return new List<TEntity>();
            }

            string sqlFormat = @"select *
                                from (select *, ROW_NUMBER() over (order by {2}) AS RowNumber
                                      from {0}
                                      where 1 = 1 {1}) T
                                where RowNumber between @skip and @end
                                order by {2}";

            if (!string.IsNullOrEmpty(condition))
            {
                condition = "and " + condition;
            }

            int skip = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@skip", skip),
                new SqlParameter("@end", end)
            };

            string sqlString = string.Format(sqlFormat, table, condition, orderBy);
            return GetList<TEntity>(connectionString, sqlString, parameters);
        }

        #endregion
    }
}