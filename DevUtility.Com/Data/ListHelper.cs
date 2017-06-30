using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                    row[property.Name] = EntityHelper.GetPropertyValue<TModel>(model, property.Name);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        #endregion

        #region To Array

        public static string[][] ToArray<TModel>(List<TModel> list) where TModel : class, new()
        {
            return ToArray<TModel>(list, null);
        }

        public static string[][] ToArray<TModel>(List<TModel> list, List<string> excludeProperties) where TModel : class, new()
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }

            var properties = PropertyHelper.GetProperties<TModel>(excludeProperties);

            if (properties.Count == 0)
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
    }
}