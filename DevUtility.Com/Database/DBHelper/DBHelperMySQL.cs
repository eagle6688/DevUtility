using DevUtility.Com.Application.Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Database.DBHelper
{
    public class DBHelperMySQL : IDbHelper
    {
        #region Variable

        /// <summary>
        /// Connection string
        /// </summary>
        string connectionString = "";

        #endregion

        #region Constructor

        public DBHelperMySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Create

        public static DBHelperMySQL Create(string connectionString)
        {
            return new DBHelperMySQL(connectionString);
        }

        #endregion

        #region Can Connected

        public bool CanConnected()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        public int ExecuteSql(string sqlString, params MySqlParameter[] sqlParameters)
        {
            int result = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);

            using (MySqlCommand command = CreateSqlCommand(connection, sqlString, sqlParameters))
            {
                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (MySqlException exception)
                {
                    LogHelper.Error(exception);
                    result = -1;
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

        public object ExecuteScalar(string sqlString, params MySqlParameter[] sqlParameters)
        {
            object value = null;
            MySqlConnection connection = new MySqlConnection(connectionString);

            using (MySqlCommand sqlCommand = CreateSqlCommand(connection, sqlString, sqlParameters))
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
                catch (MySqlException exception)
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

        public DataSet Query(string sqlString, params MySqlParameter[] sqlParameters)
        {
            return Query(sqlString, "data", sqlParameters);
        }

        public DataSet Query(string sqlString, string tableName = "data", params MySqlParameter[] sqlParameters)
        {
            DataSet ds = new DataSet();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = CreateSqlCommand(connection, sqlString, sqlParameters);

            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(command))
            {
                try
                {
                    connection.Open();
                    sqlDataAdapter.Fill(ds, tableName);
                }
                catch (MySqlException exception)
                {
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

        public DataSet RunProcedure(string storedProcName, params MySqlParameter[] sqlParameters)
        {
            return RunProcedure(storedProcName, "data", sqlParameters);
        }

        public DataSet RunProcedure(string storedProcName, string tableName = "data", params MySqlParameter[] sqlParameters)
        {
            DataSet ds = new DataSet();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = CreateSqlCommand(connection, storedProcName, sqlParameters, null, true);

            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand))
            {
                try
                {
                    connection.Open();
                    sqlDataAdapter.Fill(ds, tableName);
                }
                catch (Exception exception)
                {
                    LogHelper.Error(exception);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }

            return ds;
        }

        #endregion

        #region MySqlCommand

        private MySqlParameter[] GetParameters(MySqlParameter[] sqlParameters, bool isStoredProcedure = false)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (sqlParameters != null)
            {
                foreach (MySqlParameter parameter in sqlParameters)
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
                parameters.Add(new MySqlParameter("?ReturnValue", MySqlDbType.Int32, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            }

            return parameters.ToArray();
        }

        private MySqlCommand CreateSqlCommand(MySqlConnection connection, string commandText, MySqlParameter[] sqlParameters, MySqlTransaction sqlTransaction = null, bool isStoredProcedure = false)
        {
            MySqlCommand sqlCommand = new MySqlCommand(commandText, connection);

            if (sqlParameters != null)
            {
                var parameters = GetParameters(sqlParameters, isStoredProcedure);
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