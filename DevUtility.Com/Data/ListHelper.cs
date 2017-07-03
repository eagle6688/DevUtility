using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Data
{
    public class ListHelper
    {
        #region To DataTable

        public static DataTable ToDataTable<TModel>(List<TModel> list, List<string> excludeProperties) where TModel : class, new()
        {
            DataTable table = new DataTable();

            if (list == null || list.Count == 0)
            {
                return table;
            }

            var properties = PropertyHelper.GetProperties<TModel>(excludeProperties);

            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (TModel model in list)
            {
                DataRow row = table.NewRow();

                foreach (var property in properties)
                {
                    row[property.Name] = EntityHelper.GetPropertyValue<TModel>(model, property);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        #endregion

        #region To Array

        public static string[][] ToArray<TModel>(List<TModel> list) where TModel : class, new()
        {
            return ToArray<TModel>(list, new List<string>());
        }

        public static string[][] ToArray<TModel>(List<TModel> list, List<string> excludeProperties) where TModel : class, new()
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }

            var properties = PropertyHelper.GetProperties<TModel>(excludeProperties);
            return ToArray<TModel>(list, properties);
        }

        public static string[][] ToArray<TModel>(List<TModel> list, List<PropertyInfo> properties) where TModel : class, new()
        {
            if (list == null || list.Count == 0 || properties == null || properties.Count == 0)
            {
                return null;
            }

            string[][] array = new string[list.Count][];

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = EntityHelper.ToArray<TModel>(list[i], properties);
            }

            return array;
        }

        #endregion

        #region To List

        public static List<TModel> ToList<TModel>(string[][] array, List<PropertyInfo> properties) where TModel : class, new()
        {
            if (array == null || array.Length == 0 || properties == null || properties.Count == 0)
            {
                return new List<TModel>();
            }

            List<TModel> list = new List<TModel>();

            for (int i = 0; i < array.Length; i++)
            {
                TModel model = EntityHelper.ToModel<TModel>(array[i], properties);
                list.Add(model);
            }

            return list;
        }

        #endregion
    }
}