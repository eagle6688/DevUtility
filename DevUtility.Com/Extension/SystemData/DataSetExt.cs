using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemData
{
    public static class DataSetExt
    {
        #region Apply column name

        public static void ApplyColumnName(this DataSet ds, int usingRowIndex = 0)
        {
            if (ds == null)
            {
                return;
            }

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                ds.Tables[i].ApplyColumnName(usingRowIndex);
            }
        }

        #endregion
    }
}