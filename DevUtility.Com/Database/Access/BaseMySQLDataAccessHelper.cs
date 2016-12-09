using DevUtility.Com.Base;
using DevUtility.Com.Database.DBHelper;
using DevUtility.Com.Extension.SystemData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.Access
{
    public class BaseMySQLDataAccessHelper<T> : SingletonInstance<T> where T : class, new()
    {
        #region Get value

        public TValue GetValue<TValue>(string connectionString, string sqlString, params MySqlParameter[] parameters)
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

        public TEntity GetEntity<TEntity>(string connectionString, string sqlString, params MySqlParameter[] parameters) where TEntity : class, new()
        {
            TEntity entity = null;

            using (DataSet ds = DBHelperMySQL.Create(connectionString).Query(sqlString, parameters))
            {
                if (ds == null)
                {
                    return entity;
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    entity = ds.Tables[0].Rows[0].ConvertToModel<TEntity>();
                }
            }

            return entity;
        }

        public TEntity GetEntityByProcedure<TEntity>(string connectionString, string procedureName, params MySqlParameter[] parameters) where TEntity : class, new()
        {
            TEntity entity = null;

            using (DataSet ds = DBHelperMySQL.Create(connectionString).RunProcedure(procedureName, parameters))
            {
                if (ds == null)
                {
                    return entity;
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    entity = ds.Tables[0].Rows[0].ConvertToModel<TEntity>();
                }
            }

            return entity;
        }

        #endregion

        #region Get list

        public List<TValue> GetValues<TValue>(string connectionString, string sqlString, params MySqlParameter[] parameters)
        {
            List<TValue> list = new List<TValue>();

            using (DataSet ds = DBHelperMySQL.Create(connectionString).Query(sqlString, parameters))
            {
                if (ds == null)
                {
                    return list;
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].ConvertToValues<TValue>();
                }
            }

            return list;
        }

        public List<TEntity> GetList<TEntity>(string connectionString, string sqlString) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();

            using (DataSet ds = DBHelperMySQL.Create(connectionString).Query(sqlString))
            {
                if (ds == null)
                {
                    return list;
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].ConvertToList<TEntity>();
                }
            }

            return list;
        }

        public List<TEntity> GetList<TEntity>(string connectionString, string sqlString, params MySqlParameter[] parameters) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();

            using (DataSet ds = DBHelperMySQL.Create(connectionString).Query(sqlString, parameters))
            {
                if (ds == null)
                {
                    return list;
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].ConvertToList<TEntity>();
                }
            }

            return list;
        }

        public List<TEntity> GetListByProcedure<TEntity>(string connectionString, string procedureName, params MySqlParameter[] parameters) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();

            using (DataSet ds = DBHelperMySQL.Create(connectionString).RunProcedure(procedureName, parameters))
            {
                if (ds == null)
                {
                    return list;
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    list = ds.Tables[0].ConvertToList<TEntity>();
                }
            }

            return list;
        }

        #endregion

        #region Get paging list

        public List<TEntity> GetPagingList<TEntity>(string connectionString, string sqlString, int pageIndex, int pageSize) where TEntity : class, new()
        {
            if (string.IsNullOrWhiteSpace(sqlString))
            {
                return new List<TEntity>();
            }

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("skip", (pageIndex - 1) * pageSize),
                new MySqlParameter("length", pageSize)
            };

            string command = string.Concat(sqlString, " limit ?skip, ?length;");
            return GetList<TEntity>(connectionString, command, parameters);
        }

        public List<TEntity> GetPagingList<TEntity>(string connectionString, string sqlString, int pageIndex, int pageSize, params MySqlParameter[] parameters) where TEntity : class, new()
        {
            if (string.IsNullOrWhiteSpace(sqlString))
            {
                return new List<TEntity>();
            }

            if (parameters == null || parameters.Length == 0)
            {
                return GetPagingList<TEntity>(connectionString, sqlString, pageIndex, pageSize);
            }

            var parametersList = new List<MySqlParameter>(parameters);
            parametersList.Add(new MySqlParameter("skip", (pageIndex - 1) * pageSize));
            parametersList.Add(new MySqlParameter("length", pageSize));
            string command = string.Concat(sqlString, " limit ?skip, ?length;");
            return GetList<TEntity>(connectionString, command, parametersList.ToArray());
        }

        #endregion
    }
}