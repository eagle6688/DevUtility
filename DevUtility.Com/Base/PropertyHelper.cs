using DevUtility.Com.Application.ComAttributes;
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

        public static PropertyInfo GetProperty<TModel>(TModel model, string propertyName)
        {
            List<PropertyInfo> properties = GetAllProperties<TModel>(model);

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyName == propertyInfo.Name)
                {
                    return propertyInfo;
                }
            }

            return null;
        }

        #endregion

        #region Get all properties

        public static List<PropertyInfo> GetAllProperties<TModel>() where TModel : class, new()
        {
            return GetAllProperties<TModel>(new TModel());
        }

        public static List<PropertyInfo> GetAllProperties<TModel>(TModel model)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();

            if (model != null)
            {
                properties = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            }

            return properties;
        }

        #endregion

        #region Get properties

        public static List<PropertyInfo> GetProperties<TModel>(List<string> excludeProperties) where TModel : class, new()
        {
            List<PropertyInfo> properties = GetAllProperties<TModel>(new TModel());
            properties = FiltrateProperties(excludeProperties, properties);
            properties = FiltrateNoDatabaseFieldProperties(properties);
            return properties;
        }

        public static List<PropertyInfo> GetProperties<TModel>(TModel model)
        {
            List<PropertyInfo> properties = GetAllProperties<TModel>(model);
            properties = FiltrateNullProperties<TModel>(model, properties);
            properties = FiltrateDateTimeProperties<TModel>(model, properties);
            properties = FiltrateNoDatabaseFieldProperties(properties);
            return properties;
        }

        public static List<PropertyInfo> GetProperties<TModel>(TModel model, string excludeProperty)
        {
            return GetProperties<TModel>(model, new List<string>() { excludeProperty });
        }

        public static List<PropertyInfo> GetProperties<TModel>(TModel model, List<string> excludeProperties)
        {
            List<PropertyInfo> properties = GetAllProperties<TModel>(model);
            properties = FiltrateProperties(excludeProperties, properties);
            properties = FiltrateNullProperties<TModel>(model, properties);
            properties = FiltrateDateTimeProperties<TModel>(model, properties);
            properties = FiltrateNoDatabaseFieldProperties(properties);
            return properties;
        }

        #endregion

        #region Filtrate

        public static List<PropertyInfo> FiltrateProperties(List<string> excludeProperties, List<PropertyInfo> properties)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();

            if (excludeProperties == null || properties == null)
            {
                return properties;
            }

            foreach (PropertyInfo property in properties)
            {
                if (!excludeProperties.Contains(property.Name))
                {
                    list.Add(property);
                }
            }

            return list;
        }

        public static List<PropertyInfo> FiltrateNullProperties<TModel>(TModel model, List<PropertyInfo> properties)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();
            object value = null;

            if (model == null || properties == null)
            {
                return properties;
            }

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

        public static List<PropertyInfo> FiltrateDateTimeProperties<TModel>(TModel model, List<PropertyInfo> properties)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();

            bool isDateTimeType = false;
            Type type = null;
            object value = null;

            if (model == null || properties == null)
            {
                return properties;
            }

            foreach (PropertyInfo property in properties)
            {
                value = property.GetValue(model, null);

                if (value != null)
                {
                    isDateTimeType = false;

                    if (property.PropertyType.Name == "DateTime")
                    {
                        isDateTimeType = true;
                    }
                    else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        type = property.PropertyType.GetGenericArguments()[0];

                        if (type.Name == "DateTime")
                        {
                            isDateTimeType = true;
                        }
                    }

                    if (isDateTimeType)
                    {
                        DateTime time = DateTime.MinValue;
                        DateTime.TryParse(value.ToString(), out time);

                        if (time != DateTime.MaxValue && time != DateTime.MinValue)
                        {
                            list.Add(property);
                        }
                    }
                    else
                    {
                        list.Add(property);
                    }
                }
            }

            return list;
        }

        public static List<PropertyInfo> FiltrateNoDatabaseFieldProperties(List<PropertyInfo> properties)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();

            if (properties == null)
            {
                return properties;
            }

            foreach (PropertyInfo property in properties)
            {
                var array = property.GetCustomAttributes(typeof(NoDatabaseFieldAttribute), true);

                if (array.OfType<NoDatabaseFieldAttribute>().Count() == 0)
                {
                    list.Add(property);
                }
            }

            return list;
        }

        #endregion

        #region Get propertyNames

        public static List<string> GetPropertyNames<TModel>(List<string> excludeProperties) where TModel : class, new()
        {
            List<string> list = new List<string>();
            List<PropertyInfo> properties = GetProperties<TModel>(excludeProperties);

            foreach (var property in properties)
            {
                list.Add(property.Name);
            }

            return list;
        }

        public static List<string> GetPropertyNames<TModel>(TModel model, List<string> excludeProperties)
        {
            List<string> list = new List<string>();
            List<PropertyInfo> properties = GetProperties<TModel>(model, excludeProperties);

            foreach (var property in properties)
            {
                list.Add(property.Name);
            }

            return list;
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

        #region Get PrimaryKey properties

        public static List<PropertyInfo> GetPrimaryKeyProperties(List<PropertyInfo> properties)
        {
            List<PropertyInfo> keys = new List<PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                var array = property.GetCustomAttributes(typeof(PrimaryKeyAttribute), true);

                if (array.OfType<PrimaryKeyAttribute>().Count() > 0)
                {
                    keys.Add(property);
                }
            }

            return keys;
        }

        #endregion

        #region Get RedisIndex properties

        public static List<PropertyInfo> GetRedisIndexProperties(List<PropertyInfo> properties)
        {
            List<PropertyInfo> keys = new List<PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                var array = property.GetCustomAttributes(typeof(RedisIndexAttribute), true);

                if (array.OfType<RedisIndexAttribute>().Count() > 0 && array.OfType<PrimaryKeyAttribute>().Count() == 0)
                {
                    keys.Add(property);
                }
            }

            return keys;
        }

        #endregion

        #region Get Attribute

        public static TAttribute GetAttribute<TAttribute>(PropertyInfo property) where TAttribute : class
        {
            var array = property.GetCustomAttributes(typeof(TAttribute), true);

            if (array.OfType<TAttribute>().Count() > 0)
            {
                return array[0] as TAttribute;
            }

            return null;
        }

        #endregion
    }
}