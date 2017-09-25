using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NPOI
{
    public static class ISheetExt
    {
        #region Apply Row's Style

        /// <summary>
        /// Appling row style to other rows
        /// </summary>
        /// <param name="sheet"></param>
        public static void ApplyRowStyle(this ISheet sheet, int usingRowIndex, int startRowIndex = 1)
        {
            if (sheet.FirstRowNum == -1 || sheet.LastRowNum == -1)
            {
                return;
            }

            IRow row = sheet.GetRow(usingRowIndex);

            if (row == null)
            {
                return;
            }

            int rowsCount = sheet.LastRowNum + 1;
            int columnsCount = row.LastCellNum;
            ICellStyle rowStyle = row.RowStyle.Clone(sheet.Workbook);
            ICellStyle[] cellStyles = new ICellStyle[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                ICell cell = row.GetCell(i);

                if (cell != null)
                {
                    cellStyles[i] = cell.CellStyle.Clone(sheet.Workbook);
                }
            }

            for (int i = startRowIndex; i < rowsCount; i++)
            {
                if (i != usingRowIndex)
                {
                    IRow tRow = sheet.GetRow(i);
                    tRow.Height = row.Height;
                    tRow.HeightInPoints = row.HeightInPoints;
                    tRow.ZeroHeight = row.ZeroHeight;

                    if (row.RowStyle != null)
                    {
                        tRow.RowStyle = rowStyle;
                    }

                    for (int j = 0; j < columnsCount; j++)
                    {
                        ICell tCell = tRow.GetCell(j);

                        if (tCell == null)
                        {
                            continue;
                        }

                        if (cellStyles[j] != null)
                        {
                            tCell.CellStyle = cellStyles[j];
                        }
                    }
                }
            }
        }

        #endregion

        #region Append rows

        public static void AppendRows(this ISheet sheet, DataTable dt)
        {
            int startRowNum = sheet.LastRowNum + 1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(startRowNum + i);

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);
                    object value = dt.Rows[i][j];
                    string cellValue = "";

                    if (value != null)
                    {
                        cellValue = value.ToString();
                    }

                    cell.SetCellValue(cellValue);
                }
            }
        }

        #endregion
    }
}