using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NpoiExt
{
    public static class IWorkbookExt
    {
        #region Apply RowStyle

        public static void ApplyRowStyle(this IWorkbook workbook, int usingRowIndex, int startRowIndex = 1)
        {
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);
                sheet.ApplyRowStyle(usingRowIndex, startRowIndex);
            }
        }

        #endregion

        #region Append rows

        public static void AppendRows(this IWorkbook workbook, DataSet ds)
        {
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);

                if (i < ds.Tables.Count)
                {
                    sheet.AppendRows(ds.Tables[i]);
                }
            }
        }

        public static void AppendRows(this IWorkbook workbook, string sheetName, DataTable dt)
        {
            ISheet sheet = workbook.GetSheet(sheetName);

            if (sheet == null || dt == null)
            {
                return;
            }

            sheet.AppendRows(dt);
        }

        #endregion

        #region Convert to MemoryStream

        public static MemoryStream ToMemoryStream(this IWorkbook workbook)
        {
            if (workbook == null)
            {
                return null;
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            memoryStream.Flush();
            memoryStream.Position = 0;
            return memoryStream;
        }

        #endregion
    }
}