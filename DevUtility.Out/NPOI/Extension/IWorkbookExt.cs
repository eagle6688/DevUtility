using NPOI.SS.UserModel;
using System;
using System.Data;
using System.IO;

namespace DevUtility.Out.NPOI
{
    public static class IWorkbookExt
    {
        #region Apply Row's Style

        public static void ApplyRowStyle(this IWorkbook workbook, int usingRowIndex, int startRowIndex = 1)
        {
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);
                sheet.ApplyRowStyle(usingRowIndex, startRowIndex);
            }
        }

        #endregion

        #region To MemoryStream

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

        public static NpoiMemoryStream ToNpoiMemoryStream(this IWorkbook workbook)
        {
            if (workbook == null)
            {
                return null;
            }

            NpoiMemoryStream npoiMemoryStream = new NpoiMemoryStream();
            npoiMemoryStream.AllowClose = false;
            workbook.Write(npoiMemoryStream);
            npoiMemoryStream.Flush();
            npoiMemoryStream.Position = 0;
            npoiMemoryStream.AllowClose = true;
            return npoiMemoryStream;
        }

        #endregion

        #region Append

        public static void Append(this IWorkbook workbook, DataSet ds)
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

        public static void Append(this IWorkbook workbook, string sheetName, DataTable dt)
        {
            ISheet sheet = workbook.GetSheet(sheetName);

            if (sheet == null || dt == null)
            {
                return;
            }

            sheet.AppendRows(dt);
        }

        #endregion
    }
}