using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Model
{
    public class DatabaseModel
    {
        #region Attribute

        public DatabaseType Type { set; get; }

        public string Server { set; get; }

        public string Name { set; get; }

        public string UserName { set; get; }

        public string Password { set; get; }

        public string ConnectionString { set; get; }

        #endregion

        #region Constructor

        public DatabaseModel()
        {
            Type = DatabaseType.SqlServer;
        }

        public DatabaseModel(string server, string name, string userName, string password)
        {
            Type = DatabaseType.SqlServer;
            Server = server;
            Name = name;
            UserName = userName;
            Password = password;
            GetConnectionString();
        }

        public DatabaseModel(DatabaseType type, string server, string name, string userName, string password)
        {
            Type = type;
            Server = server;
            Name = name;
            UserName = userName;
            Password = password;
            GetConnectionString();
        }

        #endregion

        #region Get connection string

        public string GetConnectionString()
        {
            StringBuilder result = new StringBuilder();

            switch (Type)
            {
                case DatabaseType.SqlServer:
                    result.Append("server=");
                    result.Append(Server);
                    result.Append(";database=");
                    result.Append(Name);
                    result.Append(";user id=");
                    result.Append(UserName);
                    result.Append(";pwd=");
                    result.Append(Password);
                    break;

                case DatabaseType.Access:
                    result.Append("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=");
                    result.Append(Server);
                    result.Append("; User Id=");
                    result.Append(UserName);
                    result.Append("; Password=");
                    result.Append(Password);
                    break;

                default:
                    break;
            }

            ConnectionString = result.ToString();
            return ConnectionString;
        }

        #endregion

        #region Get database's type

        public void GetDbType(string providerName)
        {
            switch (providerName)
            {
                case "Microsoft.Jet.OLEDB.4.0":
                    Type = DatabaseType.Access;
                    break;

                case "System.Data.SqlClient":
                    Type = DatabaseType.SqlServer;
                    break;

                case "OraOLEDB.Oracle":
                    Type = DatabaseType.Oracle;
                    break;

                case "MySQLProv":
                    Type = DatabaseType.MySql;
                    break;

                default:
                    Type = DatabaseType.SqlServer;
                    break;
            }
        }

        #endregion
    }
}