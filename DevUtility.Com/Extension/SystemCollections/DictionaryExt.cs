using DevUtility.Com.Base;
using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Extension.SystemCollections
{
    public static class DictionaryExt
    {
        #region To data string

        public static string ToDataString(this IDictionary<string, string> parameters)
        {
            int count = 0;
            StringBuilder result = new StringBuilder();

            foreach (string key in parameters.Keys)
            {
                if (count > 0)
                {
                    result.AppendFormat("&{0}={1}", key, parameters[key]);
                }
                else
                {
                    result.AppendFormat("{0}={1}", key, parameters[key]);
                }

                count++;
            }

            return result.ToString();
        }

        #endregion

        #region To model

        public static TModel ToModel<TModel>(this IDictionary<string, string> dictionary) where TModel : class, new()
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return null;
            }

            List<PropertyInfo> properties = PropertyHelper.GetProperties<TModel>();
            return dictionary.ToModel<TModel>(properties);
        }

        public static TModel ToModel<TModel>(this IDictionary<string, string> dictionary, List<PropertyInfo> properties) where TModel : class, new()
        {
            if (dictionary == null || dictionary.Count == 0
                || properties == null || properties.Count == 0)
            {
                return null;
            }

            bool isNull = true;
            TModel model = new TModel();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;

                if (dictionary.ContainsKey(propertyName) && property.CanWrite)
                {
                    string value = "";

                    if (dictionary.TryGetValue(propertyName, out value))
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            isNull = false;
                            EntityHelper.SetModel<TModel>(ref model, property, value);
                        }
                    }
                }
            }

            if (isNull)
            {
                return null;
            }

            return model;
        }

        #endregion
    }
}