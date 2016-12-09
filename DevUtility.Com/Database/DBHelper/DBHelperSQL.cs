using DevUtility.Com.Application.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.DBHelper
{
    public class DBHelperSQL : IDbHelper
    {
        #region Variable

        /// <summary>
        /// Connection string
        /// </summary>
        string connectionString = "";

        #endregion

        #region Constructor

        public DBHelperSQL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Create

        public static DBHelperSQL Create(string connectionString)
        {
            return new DBHelperSQL(connectionString);
        }

        #endregion

        #region Can Connected

        public bool CanConnected()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (connection.State.ToString().Equals("Open"))
                    {
                        return true;
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.Error(exception);
                }
            }

            return false;
        }

        #endregion

        #region Execute sql

        public int ExecuteSql(string sqlString)
        {
            return ExecuteSql(sqlString, null);
        }

        public int ExecuteSql(string sqlString, params SqlParameter[] sqlParameters)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = CreateSqlCommand(connection, sqlString, sqlParameters))
            {
                try
                {
                    connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    result = -1;
                    LogHelper.Error(exception);
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        #endregion

        #region Execute scalar

        public object ExecuteScalar(string sqlString)
        {
            return ExecuteScalar(sqlString, null);
        }

        public object ExecuteScalar(string sqlString, params SqlParameter[] sqlParameters)
        {
            object value = null;
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = CreateSqlCommand(connection, sqlString, sqlParameters))
            {
                try
                {
                    connection.Open();
                    value = sqlCommand.ExecuteScalar();

                    if (Object.Equals(value, System.DBNull.Value))
                    {
                        value = null;
                    }
                }
                catch (SqlException exception)
                {
                    LogHelper.Error(exception);
                }
                finally
                {
                    connection.Close();
                }
            }

            return value;
        }

        #endregion

        #region Query

        public DataSet Query(string sqlString)
        {
            return Query(sqlString, "data", null);
        }

        public DataSet Query(string sqlString, params SqlParameter[] sqlParameters)
        {
            return Query(sqlString, "data", sqlParameters);
        }

        public DataSet Query(string sqlString, string tableName = "data", params SqlParameter[] sqlParameters)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = CreateSqlCommand(connection, sqlString, sqlParameters);

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
            {
                try
                {
                    connection.Open();
                    sqlDataAdapter.Fill(ds, tableName);
                }
                catch (SqlException exception)
                {
                    ds = null;
                    LogHelper.Error(exception);
                }
                finally
                {
                    connection.Close();
                }
            }

            return ds;
        }

        #endregion

        #region Run stored procedure

        public DataSet RunProcedure(string storedProcName, params SqlParameter[] sqlParameters)
        {
            return RunProcedure(storedProcName, "data", sqlParameters);
        }

        public DataSet RunProcedure(string storedProcName, string tableName = "data", params SqlParameter[] sqlParameters)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = CreateSqlCommand(connection, storedProcName, sqlParameters, null, true);

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
            {
                try
                {
                    connection.Open();
                    sqlDataAdapter.Fill(ds, tableName);
                }
                catch (Exception exception)
                {
                    ds = null;
                    LogHelper.Error(exception);
                }
                finally
                {
                    connection.Close();
                }
            }

            return ds;
        }

        #endregion

        #region SqlCommand

        private SqlParameter[] GetParameters(SqlParameter[] sqlParameters, bool isStoredProcedure = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (sqlParameters != null)
            {
                foreach (SqlParameter parameter in sqlParameters)
                {
                    //Check the output parameter that have not assigned value and assign DBNull.Value to it.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }

                    parameters.Add(parameter);
                }
            }

            if (isStoredProcedure)
            {
                parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            }

            return parameters.ToArray();
        }

        private SqlCommand CreateSqlCommand(SqlConnection connection, string commandText, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction = null, bool isStoredProcedure = false)
        {
            SqlCommand sqlCommand = new SqlCommand(commandText, connection);
            var parameters = GetParameters(sqlParameters, isStoredProcedure);

            if (parameters != null)
            {
                sqlCommand.Parameters.AddRange(parameters);
            }

            if (sqlTransaction != null)
            {
                sqlCommand.Transaction = sqlTransaction;
            }

            if (isStoredProcedure)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCommand.CommandType = CommandType.Text;
            }

            return sqlCommand;
        }

        #endregion
    }
}