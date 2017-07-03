using DevUtility.Com.Base.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Base
{
    public class PropertyHelper
    {
        #region Get property

        public static PropertyInfo GetProperty<TModel>(string propertyName) where TModel : class, new()
        {
            List<PropertyInfo> properties = GetProperties<TModel>();
            return properties.FirstOrDefault(q => propertyName.Equals(q.Name));
        }

        #endregion

        #region Get properties

        public static List<PropertyInfo> GetProperties<TModel>() where TModel : class, new()
        {
            Type type = typeof(TModel);

            if (type == null)
            {
                throw new Exception("Type not found!");
            }

            PropertyInfo[] array = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            if (array == null)
            {
                return new List<PropertyInfo>();
            }

            return array.ToList();
        }

        public static List<PropertyInfo> GetProperties<TModel>(string excludeProperty) where TModel : class, new()
        {
            return GetProperties<TModel>(new List<string>() { excludeProperty });
        }

        public static List<PropertyInfo> GetProperties<TModel>(List<string> excludeProperties) where TModel : class, new()
        {
            List<PropertyInfo> properties = GetProperties<TModel>();
            properties = FiltrateExcludeProperties(excludeProperties, properties);
            return properties;
        }

        public static List<PropertyInfo> GetProperties<TModel, TAttribute>(List<string> excludeProperties) where TModel : class, new()
        {
            List<PropertyInfo> properties = GetProperties<TModel>(excludeProperties);
            properties = FiltrateByAttribute<TAttribute>(properties);
            return properties;
        }

        #endregion

        #region Get properties for database

        public static List<PropertyInfo> GetPropertiesForDatabase<TModel>(TModel model, string excludeProperty) where TModel : class, new()
        {
            return GetPropertiesForDatabase<TModel>(model, new List<string>() { excludeProperty });
        }

        public static List<PropertyInfo> GetPropertiesForDatabase<TModel>(TModel model, List<string> excludeProperties) where TModel : class, new()
        {
            var properties = GetProperties<TModel>();
            properties = FiltrateExcludeProperties(excludeProperties, properties);
            properties = FiltrateInvalidDateTimeProperties<TModel>(model, properties);
            return properties;
        }

        #endregion

        #region Get properties by attribute

        public static List<PropertyInfo> GetPropertiesByAttribute<TModel, TAttribute>() where TModel : class, new()
        {
            List<PropertyInfo> properties = GetProperties<TModel>();
            return FiltrateByAttribute<TAttribute>(properties);
        }

        #endregion

        #region Filtrate exclude properties

        public static List<PropertyInfo> FiltrateExcludeProperties(List<string> excludeProperties, List<PropertyInfo> properties)
        {
            if (excludeProperties == null || properties == null)
            {
                return properties;
            }

            var query = from p in properties
                        where !excludeProperties.Contains(p.Name)
                        select p;

            return query.ToList();
        }

        #endregion

        #region Filtrate null value properties

        public static List<PropertyInfo> FiltrateNullValueProperties<TModel>(TModel model, List<PropertyInfo> properties)
        {
            if (model == null || properties == null)
            {
                return properties;
            }

            List<PropertyInfo> list = new List<PropertyInfo>();
            object value = null;

            foreach (PropertyInfo property in properties)
            {
                value = property.GetValue(model, null);

                if (value != null)
                {
                    list.Add(property);
                }
            }

            return list;
        }

        #endregion

        #region Filtrate invalid DateTime properties

        public static List<PropertyInfo> FiltrateInvalidDateTimeProperties<TModel>(TModel model, List<PropertyInfo> properties)
        {
            if (model == null || properties == null)
            {
                return properties;
            }

            List<PropertyInfo> list = new List<PropertyInfo>();
            object value = null;

            foreach (PropertyInfo property in properties)
            {
                if (!TypeHelper.IsType(property.PropertyType, "DateTime"))
                {
                    list.Add(property);
                    continue;
                }

                value = property.GetValue(model, null);

                if (value == null)
                {
                    continue;
                }

                DateTime time = DateTime.MinValue;
                DateTime.TryParse(value.ToString(), out time);

                if (time != DateTime.MaxValue && time != DateTime.MinValue)
                {
                    list.Add(property);
                }
            }

            return list;
        }

        #endregion

        #region Filtrate by attribute

        public static List<PropertyInfo> FiltrateByAttribute<TAttribute>(List<PropertyInfo> properties)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();
            Type attributeType = typeof(TAttribute);

            foreach (PropertyInfo property in properties)
            {
                var array = property.GetCustomAttributes(attributeType, true);

                if (array != null && array.Length > 0)
                {
                    list.Add(property);
                }
            }

            return list;
        }

        #endregion

        #region Filtrate by no attribute

        public static List<PropertyInfo> FiltrateByNoAttribute<TAttribute>(List<PropertyInfo> properties)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();
            Type attributeType = typeof(TAttribute);

            foreach (PropertyInfo property in properties)
            {
                var array = property.GetCustomAttributes(attributeType, true);

                if (array == null || array.Length == 0)
                {
                    list.Add(property);
                }
            }

            return list;
        }

        #endregion

        #region Get property names

        public static List<string> GetPropertyNames<TModel>(List<string> excludeProperties) where TModel : class, new()
        {
            List<PropertyInfo> properties = GetProperties<TModel>(excludeProperties);
            return properties.Select(q => q.Name).ToList();
        }

        #endregion

        #region Get properties SqlParameters string

        public static string GetPropertiesSqlParameterString(List<PropertyInfo> properties, string prefix = "")
        {
            StringBuilder result = new StringBuilder("");

            if (properties == null)
            {
                return result.ToString();
            }

            foreach (PropertyInfo property in properties)
            {
                result.AppendFormat("{0}{1}, ", prefix, property.Name);
            }

            if (properties.Count() > 0)
            {
                result = result.Remove(result.Length - 2, 2);
            }

            return result.ToString();
        }

        #endregion

        #region Get Attribute

        public static TAttribute GetAttribute<TAttribute>(PropertyInfo property) where TAttribute : class
        {
            var array = property.GetCustomAttributes(typeof(TAttribute), true);

            if (array == null || array.Length == 0)
            {
                return null;
            }

            return array[0] as TAttribute;
        }

        #endregion
    }
}