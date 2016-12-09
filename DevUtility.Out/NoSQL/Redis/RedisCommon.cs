using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public class RedisCommon
    {
        public const string WildCard = "*";

        public const string KeyValueSeparatorFormat = "&";

        #region Key Value string

        /// <summary>
        /// 0: Key name
        /// 1: Key value
        /// </summary>
        public const string KeyValueFormat = "{0}:{1}";

        public static string GetKeyValueStr(string name, string value)
        {
            return string.Format(KeyValueFormat, name, value);
        }

        #endregion

        #region Get Property's Value

        public static string GetPropertyValueStr<TModel>(TModel model, PropertyInfo property, string defaultValue = null) where TModel : class, new()
        {
            var value = property.GetValue(model, null);

            if (value == null)
            {
                return defaultValue;
            }

            switch (property.PropertyType.Name)
            {
                case "Int16":
                    if (Convert.ToInt16(value) > 0)
                    {
                        return value.ToString();
                    }

                    break;

                case "Int32":
                    if (Convert.ToInt32(value) > 0)
                    {
                        return value.ToString();
                    }

                    break;

                case "Int64":
                    if (Convert.ToInt64(value) > 0)
                    {
                        return value.ToString();
                    }

                    break;

                default:
                    string valueStr = value.ToString();

                    if (!string.IsNullOrEmpty(valueStr))
                    {
                        return valueStr;
                    }

                    break;
            }

            return defaultValue;
        }

        #endregion

        #region Get Properties Keys Values string

        public static string GetPrimaryKeysValuesStr<TModel>(TModel model, List<PropertyInfo> primaryKeysProperties, string defaultValue = null) where TModel : class, new()
        {
            if (primaryKeysProperties.Count == 1)
            {
                return GetPropertyValueStr<TModel>(model, primaryKeysProperties[0], defaultValue);
            }

            return GetPropertiesKeysValuesStr<TModel>(model, primaryKeysProperties, defaultValue);
        }

        public static string GetPropertiesKeysValuesStr<TModel>(TModel model, List<PropertyInfo> properties, string defaultValue = null) where TModel : class, new()
        {
            StringBuilder result = new StringBuilder("");

            foreach (var property in properties)
            {
                if (result.Length > 0)
                {
                    result.Append(KeyValueSeparatorFormat);
                }

                string value = GetPropertyValueStr<TModel>(model, property, defaultValue);
                result.Append(GetKeyValueStr(property.Name, value));
            }

            return result.ToString();
        }

        #endregion
    }
}