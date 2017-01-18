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
        #region ConvertToDataTable

        public static DataTable ConvertToDataTable<TModel>(List<TModel> list, List<string> excludeProperties) where TModel : class, new()
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
    }
}