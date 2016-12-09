using DevUtility.Com.Extension.SystemCollections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Extension.SystemData
{
    public static class DataTableExt
    {
        #region Get level

        public static int GetLevel(ref DataTable dt, string keyField, string parentIDField, string parentID, string rootValue)
        {
            int level = -1;

            if (parentID == rootValue)
            {
                level = 0;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (parentID == dr[keyField].ToString())
                    {
                        level = GetLevel(ref dt, keyField, parentIDField, dr[parentIDField].ToString(), rootValue) + 1;
                    }
                }
            }

            return level;
        }

        #endregion

        #region Create DataTable

        public static DataTable CreateDataTable<TModel>(TModel model)
        {
            Type type = typeof(TModel);
            DataTable dataTable = new DataTable(type.Name);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }

            return dataTable;
        }

        #endregion

        #region Fill DataTable

        public static DataTable FillDataTable<TModel>(TModel model)
        {
            if (model == null)
            {
                return null;
            }

            DataTable dt = CreateDataTable<TModel>(model);
            DataRow dataRow = dt.NewRow();

            foreach (PropertyInfo propertyInfo in typeof(TModel).GetProperties())
            {
                dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
            }

            dt.Rows.Add(dataRow);
            return dt;
        }

        public static DataTable FillDataTable<TModel>(List<TModel> list)
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }

            DataTable dt = CreateDataTable(list[0]);

            foreach (TModel model in list)
            {
                DataRow dataRow = dt.NewRow();

                foreach (PropertyInfo propertyInfo in typeof(TModel).GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                }

                dt.Rows.Add(dataRow);
            }

            return dt;
        }

        #endregion

        #region Set ColumnName

        public static void SetColumnName(ref DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ColumnName = dt.Rows[0][i].ToString();
                }

                dt.Rows.RemoveAt(0);
            }
        }

        #endregion

        #region Get list without repeated data

        public static List<string> GetUniqueList(this DataTable dt, int index)
        {
            List<string> list = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                list.AddUnique(dr[index].ToString());
            }

            return list;
        }

        public static List<string> GetUniqueList(this DataTable dt, string filed)
        {
            List<string> list = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                list.AddUnique(dr[filed].ToString());
            }

            return list;
        }

        #endregion

        #region Convert to model

        public static TModel ConvertToModel<TModel>(this DataTable dt) where TModel : class, new()
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].ConvertToModel<TModel>();
            }

            return null;
        }

        #endregion

        #region Convert to list

        public static List<T> ConvertToValues<T>(this DataTable dt)
        {
            List<T> list = new List<T>();

            if (dt == null || dt.Rows.Count == 0)
            {
                return list;
            }

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.ConvertToValue<T>());
            }

            return list;
        }

        public static List<TModel> ConvertToList<TModel>(this DataTable dt) where TModel : class, new()
        {
            List<TModel> list = new List<TModel>();

            if (dt == null || dt.Rows.Count == 0)
            {
                return list;
            }

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.ConvertToModel<TModel>());
            }

            return list;
        }

        public static List<TModel> ConvertToModelWithReportFieldAttribute<TModel>(this DataTable dt) where TModel : class, new()
        {
            List<TModel> list = new List<TModel>();

            if (dt == null || dt.Rows.Count == 0)
            {
                return list;
            }

            foreach (DataRow dr in dt.Rows)
            {
                TModel model = dr.ConvertToModelWithReportFieldAttribute<TModel>();

                if (model != null)
                {
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion

        #region Apply column name

        public static void ApplyColumnName(this DataTable dt, int usingRowIndex = 0)
        {
            if (usingRowIndex > (dt.Rows.Count - 1))
            {
                return;
            }

            DataRow row = dt.Rows[usingRowIndex];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(row[i].ToString()))
                {
                    return;
                }
            }

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = row[i].ToString();
            }

            dt.Rows.RemoveAt(usingRowIndex);
        }

        #endregion
    }
}