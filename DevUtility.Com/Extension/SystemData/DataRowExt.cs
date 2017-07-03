using DevUtility.Com.Application.ComAttributes;
using DevUtility.Com.Base;
using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Extension.SystemData
{
    public static class DataRowExt
    {
        #region Convert to model

        public static TModel ConvertToModel<TModel>(this DataRow dr) where TModel : class, new()
        {
            if (dr == null)
            {
                return null;
            }

            TModel model = new TModel();
            DataColumnCollection columns = dr.Table.Columns;
            List<PropertyInfo> properties = PropertyHelper.GetProperties<TModel>();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;

                if (columns.Contains(propertyName) && property.CanWrite)
                {
                    object value = dr[propertyName];

                    if (value is DBNull || value == DBNull.Value)
                    {
                        continue;
                    }

                    EntityHelper.SetModel<TModel>(ref model, property, value);
                }
            }

            return model;
        }

        #endregion

        #region Convert to value

        public static T ConvertToValue<T>(this DataRow dr)
        {
            if (dr == null)
            {
                return default(T);
            }

            object value = dr[0];

            if (value == null || value is DBNull || value == DBNull.Value)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        #endregion

        #region Convert to model with ReportFieldAttribute

        public static TReportModel ConvertToModelWithReportFieldAttribute<TReportModel>(this DataRow dr) where TReportModel : class, new()
        {
            if (dr == null)
            {
                return null;
            }

            TReportModel model = new TReportModel();
            DataColumnCollection columns = dr.Table.Columns;
            var properties = PropertyHelper.GetProperties<TReportModel>();

            foreach (var property in properties)
            {
                string fieldName = "";
                var attributes = property.GetCustomAttributes(typeof(ReportFieldAttribute), true);

                if (attributes.Length > 0)
                {
                    fieldName = (attributes[0] as ReportFieldAttribute).Name;
                }
                else
                {
                    fieldName = property.Name;
                }

                if (!(columns.Contains(fieldName) && property.CanWrite))
                {
                    continue;
                }

                object value = dr[fieldName];

                if (value is DBNull || value == DBNull.Value)
                {
                    continue;
                }

                EntityHelper.SetModel<TReportModel>(ref model, property, value);
            }

            return model;
        }

        #endregion
    }
}