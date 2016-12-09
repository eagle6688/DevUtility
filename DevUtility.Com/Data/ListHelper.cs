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

            List<string> columns = PropertyHelper.GetPropertyNames<TModel>(excludeProperties);

            foreach (string column in columns)
            {
                table.Columns.Add(column);
            }

            foreach (TModel model in list)
            {
                DataRow row = table.NewRow();

                foreach (string column in columns)
                {
                    row[column] = EntityHelper.GetPropertyValue<TModel>(model, column);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        #endregion
    }
}