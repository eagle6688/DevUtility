using DevUtility.Com.Base;
using DevUtility.Com.Base.Reflection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Data
{
    public class EntityHelper
    {
        #region Get sql parameters

        public static SqlParameter[] GetSqlParameters<TModel>(TModel model, List<PropertyInfo> properties) where TModel : class, new()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            object value = null;

            if (model == null || properties == null)
            {
                return parameters.ToArray();
            }

            foreach (PropertyInfo propertyInfo in properties)
            {
                value = propertyInfo.GetValue(model, null);

                if (value != null)
                {
                    SqlParameter sqlParameter = new SqlParameter("@" + propertyInfo.Name, value);
                    parameters.Add(sqlParameter);
                }
            }

            return parameters.ToArray();
        }

        #endregion

        #region Get insert sql

        public static string GetInsertSql(string tableName, List<PropertyInfo> properties)
        {
            StringBuilder sqlString = new StringBuilder("");

            if (string.IsNullOrEmpty(tableName) || properties == null)
            {
                return sqlString.ToString();
            }

            if (properties.Count() > 0)
            {
                string parametersString = PropertyHelper.GetPropertiesSqlParameterString(properties);
                string parametersValue = PropertyHelper.GetPropertiesSqlParameterString(properties, "@");
                sqlString.AppendFormat("insert into {0}({1}) ", tableName, parametersString);
                sqlString.AppendFormat("values({0})", parametersValue);
            }

            return sqlString.ToString();
        }

        public static string GetInsertSqlWithIdentity(string tableName, List<PropertyInfo> properties)
        {
            StringBuilder sqlString = new StringBuilder("");
            sqlString.Append(GetInsertSql(tableName, properties));

            if (sqlString.Length > 0)
            {
                sqlString.Append(" select scope_identity();");
            }

            return sqlString.ToString();
        }

        #endregion

        #region Get update sql

        public static string GetUpdateSql(string tableName, string keyName, List<PropertyInfo> properties)
        {
            StringBuilder sqlString = new StringBuilder("");

            if (string.IsNullOrEmpty(tableName) || properties == null)
            {
                return sqlString.ToString();
            }

            if (properties.Count() > 0)
            {
                string parametersString = PropertyHelper.GetPropertiesSqlParameterString(properties);
                string setCommandString = GetUpdateSetSqlString(properties);
                sqlString.AppendFormat("update {0} set ", tableName);
                sqlString.AppendFormat(setCommandString);
                sqlString.AppendFormat(" where {0} = @{0}", keyName);
            }

            return sqlString.ToString();
        }

        public static string GetUpdateSql(string tableName, List<string> keyFields, List<PropertyInfo> properties)
        {
            StringBuilder sqlString = new StringBuilder("");

            if (string.IsNullOrEmpty(tableName) || properties == null)
            {
                return sqlString.ToString();
            }

            if (properties.Count() > 0)
            {
                string parametersString = PropertyHelper.GetPropertiesSqlParameterString(properties);
                string setCommandString = GetUpdateSetSqlString(properties);
                sqlString.AppendFormat("update {0} set ", tableName);
                sqlString.AppendFormat(setCommandString);

                for (int i = 0; i < keyFields.Count(); i++)
                {
                    if (i == 0)
                    {
                        sqlString.AppendFormat(" where {0} = @{0}", keyFields[i]);
                    }
                    else if (i == keyFields.Count() - 1)
                    {
                        sqlString.AppendFormat(" {0} = @{0}", keyFields[i]);
                    }
                    else
                    {
                        sqlString.AppendFormat(" and {0} = @{0}", keyFields[i]);
                    }
                }
            }

            return sqlString.ToString();
        }

        private static string GetUpdateSetSqlString(List<PropertyInfo> properties)
        {
            StringBuilder sqlString = new StringBuilder("");

            if (properties == null)
            {
                return sqlString.ToString();
            }

            foreach (PropertyInfo propertyInfo in properties)
            {
                sqlString.AppendFormat("{0} = @{0}, ", propertyInfo.Name);
            }

            if (properties.Count() > 0)
            {
                sqlString = sqlString.Remove(sqlString.Length - 2, 2);
            }

            return sqlString.ToString();
        }

        #endregion

        #region Set model

        public static void SetModel<TModel>(ref TModel model, PropertyInfo propertyInfo, object value)
        {
            try
            {
                switch (propertyInfo.PropertyType.ToString())
                {
                    case "System.String":
                        propertyInfo.SetValue(model, Convert.ToString(value), null);
                        break;

                    case "System.Int16":
                        propertyInfo.SetValue(model, Convert.ToInt16(value), null);
                        break;

                    case "System.Int32":
                        propertyInfo.SetValue(model, Convert.ToInt32(value), null);
                        break;

                    case "System.Int64":
                        propertyInfo.SetValue(model, Convert.ToInt64(value), null);
                        break;

                    case "System.DateTime":
                        propertyInfo.SetValue(model, Convert.ToDateTime(value), null);
                        break;

                    case "System.Boolean":
                        propertyInfo.SetValue(model, Convert.ToBoolean(value), null);
                        break;

                    case "System.Single":
                        propertyInfo.SetValue(model, Convert.ToSingle(value), null);
                        break;

                    case "System.Double":
                        propertyInfo.SetValue(model, Convert.ToDouble(value), null);
                        break;

                    case "System.Decimal":
                        propertyInfo.SetValue(model, Convert.ToDecimal(value), null);
                        break;

                    case "System.Guid":
                        propertyInfo.SetValue(model, Guid.Parse(value.ToString()), null);
                        break;

                    default:
                        propertyInfo.SetValue(model, value, null);
                        break;
                }
            }
            catch { }
        }

        #endregion

        #region Get property value

        public static object GetPropertyValue<TModel>(TModel model, PropertyInfo property)
        {
            object value = property.GetValue(model, null);

            if (value == null)
            {
                return null;
            }

            if (TypeHelper.IsType(property.PropertyType, "DateTime"))
            {
                DateTime time = DateTime.MinValue;
                DateTime.TryParse(value.ToString(), out time);

                if (time == DateTime.MinValue || time == DateTime.MaxValue)
                {
                    return null;
                }
            }

            return value;
        }

        #endregion

        #region To KeyValuePairs

        public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs<TModel>(TModel model) where TModel : class, new()
        {
            var properties = PropertyHelper.GetProperties<TModel>();
            return ToKeyValuePairs<TModel>(model, properties);
        }

        public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs<TModel>(TModel model, List<PropertyInfo> properties) where TModel : class, new()
        {
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

            if (model == null || properties == null)
            {
                return keyValuePairs;
            }

            foreach (PropertyInfo propertyInfo in properties)
            {
                object value = propertyInfo.GetValue(model, null);

                if (value != null)
                {
                    keyValuePairs.Add(new KeyValuePair<string, string>(propertyInfo.Name, value.ToString()));
                }
            }

            return keyValuePairs;
        }

        #endregion

        #region Get keys' values

        public static List<string> GetKeysValues<TModel>(TModel model, List<PropertyInfo> keysProperties) where TModel : class, new()
        {
            List<string> values = new List<string>();

            foreach (PropertyInfo propertyInfo in keysProperties)
            {
                object value = propertyInfo.GetValue(model, null);

                if (value == null)
                {
                    return values;
                }

                values.Add(value.ToString());
            }

            return values;
        }

        #endregion

        #region Get value

        public object GetValue<TModel>(TModel model, PropertyInfo property)
        {
            return property.GetValue(model, null);
        }

        #endregion

        #region To Array

        public static string[] ToArray<TModel>(TModel model, List<PropertyInfo> properties) where TModel : class, new()
        {
            if (model == null || properties == null || properties.Count == 0)
            {
                return null;
            }

            string[] array = new string[properties.Count];
            int index = 0;
            object value = null;

            foreach (var property in properties)
            {
                value = property.GetValue(model, null);

                if (value == null)
                {
                    array[index] = string.Empty;
                }
                else
                {
                    array[index] = value.ToString();
                }

                index++;
            }

            return array;
        }

        #endregion

        #region To Model

        public static TModel ToModel<TModel>(string[] array, List<PropertyInfo> properties) where TModel : class, new()
        {
            TModel model = new TModel();
            int index = 0;

            foreach (var property in properties)
            {
                SetModel<TModel>(ref model, property, array[index]);
                index++;
            }

            return model;
        }

        #endregion
    }
}