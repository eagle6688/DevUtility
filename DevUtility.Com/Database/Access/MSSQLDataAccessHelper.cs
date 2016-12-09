using DevUtility.Com.Database.DBHelper;
using DevUtility.Com.Extension.SystemData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.Access
{
    public class MSSQLDataAccessHelper
    {
        #region Variables

        private DBHelperSQL dbHelperSQL;

        #endregion

        #region Constructor

        public MSSQLDataAccessHelper(string connectionString)
        {
            dbHelperSQL = new DBHelperSQL(connectionString);
        }

        #endregion

        #region Get value

        public TValue GetValue<TValue>(string sqlString, params SqlParameter[] parameters)
        {
            var list = GetValues<TValue>(sqlString, parameters);

            if (list == null || list.Count == 0)
            {
                return default(TValue);
            }

            return list[0];
        }

        #endregion

        #region Get entity

        public TEntity GetEntity<TEntity>(string sqlString, params SqlParameter[] parameters) where TEntity : class, new()
        {
            DataSet ds = dbHelperSQL.Query(sqlString, parameters);
            return GetEntity<TEntity>(ds);
        }

        private TEntity GetEntity<TEntity>(DataSet ds) where TEntity : class, new()
        {
            TEntity entity = null;

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

        #region Get Entity by Procedure

        public TEntity GetEntityByProcedure<TEntity>(string procedureName, params SqlParameter[] parameters) where TEntity : class, new()
        {
            DataSet ds = dbHelperSQL.RunProcedure(procedureName, parameters);
            return GetEntityByProcedure<TEntity>(ds);
        }

        private TEntity GetEntityByProcedure<TEntity>(DataSet ds) where TEntity : class, new()
        {
            TEntity entity = null;

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

        #region Get Values

        public List<TValue> GetValues<TValue>(string sqlString, params SqlParameter[] parameters)
        {
            DataSet ds = dbHelperSQL.Query(sqlString, parameters);
            return GetValues<TValue>(ds);
        }

        private List<TValue> GetValues<TValue>(DataSet ds)
        {
            List<TValue> list = new List<TValue>();

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

        #endregion

        #region Get list

        public List<TEntity> GetList<TEntity>(string sqlString) where TEntity : class, new()
        {
            DataSet ds = dbHelperSQL.Query(sqlString);
            return GetList<TEntity>(ds);
        }

        public List<TEntity> GetList<TEntity>(string sqlString, params SqlParameter[] parameters) where TEntity : class, new()
        {
            DataSet ds = dbHelperSQL.Query(sqlString, parameters);
            return GetList<TEntity>(ds);
        }

        private List<TEntity> GetList<TEntity>(DataSet ds) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();

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

        #region Get List by Procedure

        public List<TEntity> GetListByProcedure<TEntity>(string procedureName, params SqlParameter[] parameters) where TEntity : class, new()
        {
            DataSet ds = dbHelperSQL.RunProcedure(procedureName, parameters);
            return GetList<TEntity>(ds);
        }

        #endregion

        #region Get paging list

        public List<TEntity> GetPagingList<TEntity>(string table, string condition, string orderBy, int pageIndex, int pageSize) where TEntity : class, new()
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
            return GetList<TEntity>(sqlString, parameters);
        }

        #endregion
    }
}