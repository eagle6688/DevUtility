using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NpoiExt
{
    /// <summary>
    /// 2017-03-16
    /// </summary>
    public class NpoiHelper
    {
        #region Read

        public static DataSet Read(string path)
        {
            IWorkbook workbook = ReadToWorkbook(path);

            if (workbook == null)
            {
                return null;
            }

            return Read(workbook);
        }

        public static IWorkbook ReadToWorkbook(string path)
        {
            if (File.Exists(path))
            {
                return WorkbookFactory.Create(path);
            }

            return null;
        }

        public static DataSet Read(IWorkbook workbook)
        {
            if (workbook == null)
            {
                return null;
            }

            DataSet ds = new DataSet();

            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                DataTable table = new DataTable();
                ISheet sheet = workbook.GetSheetAt(i);

                if (!string.IsNullOrWhiteSpace(sheet.SheetName))
                {
                    table.TableName = sheet.SheetName;
                }

                IRow firstRow = sheet.GetRow(0);

                if (firstRow == null)
                {
                    continue;
                }

                int rowCount = sheet.LastRowNum + 1;
                int columnsCount = firstRow.LastCellNum;

                for (int j = 0; j < columnsCount; j++)
                {
                    table.Columns.Add(j.ToString());
                }

                for (int j = 0; j < rowCount; j++)
                {
                    IRow row = sheet.GetRow(j);

                    if (row != null)
                    {
                        DataRow dr = table.NewRow();

                        for (int k = 0; k < columnsCount; k++)
                        {
                            ICell cell = row.GetCell(k);

                            if (cell != null)
                            {
                                dr[k] = cell.ToString();
                            }
                        }

                        table.Rows.Add(dr);
                    }
                }

                sheet = null;
                ds.Tables.Add(table);
            }

            return ds;
        }

        #endregion

        #region Write

        public static MemoryStream Write(DataSet ds)
        {
            HSSFWorkbook workbook = GetWorkbook();

            foreach (DataTable table in ds.Tables)
            {
                GetWorksheet(ref workbook, table);
            }

            return workbook.ToMemoryStream();
        }

        public static NpoiMemoryStream WriteToNpoiMemoryStream(DataSet ds)
        {
            HSSFWorkbook workbook = GetWorkbook();

            foreach (DataTable table in ds.Tables)
            {
                GetWorksheet(ref workbook, table);
            }

            return workbook.ToNpoiMemoryStream();
        }

        #endregion

        #region Write big data to excel

        public static void InitExcel(string excelName, string tableName, long recordsCount)
        {
            string extension = Path.GetExtension(excelName);

            if (File.Exists(excelName))
            {
                File.Delete(excelName);
            }

            if (IsExcel03(extension))
            {
                Create03Workbook(excelName, tableName, recordsCount);
            }
            else if (IsExcel07(extension))
            {
                Create07Workbook(excelName, tableName, recordsCount);
            }
        }

        public static void WriteExcel(string excelName, DataTable table)
        {
            using (FileStream fileStream = File.Open(excelName, FileMode.Open))
            {
                IWorkbook workbook = new XSSFWorkbook(fileStream);
            }
        }

        private static void Create03Workbook(string excelName, string tableName, long recordsCount)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            Create03Sheets(ref workbook, tableName, recordsCount);

            using (FileStream fileStream = File.Create(excelName))
            {
                workbook.Write(fileStream);
            }
        }

        private static void Create03Sheets(ref HSSFWorkbook workbook, string tableName, long recordsCount)
        {
            int sheetsCount = GetSheetsCount(recordsCount, ExcelCom.Excel03Properties);

            foreach (string sheetName in GetSheetsNames(tableName, sheetsCount))
            {
                workbook.CreateSheet(sheetName);
            }
        }

        private static void Create07Workbook(string excelName, string tableName, long recordsCount)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            Create07Sheets(ref workbook, tableName, recordsCount);

            using (FileStream fileStream = File.Create(excelName))
            {
                workbook.Write(fileStream);
            }
        }

        private static void Create07Sheets(ref XSSFWorkbook workbook, string tableName, long recordsCount)
        {
            int sheetsCount = GetSheetsCount(recordsCount, ExcelCom.Excel07Properties);

            foreach (string sheetName in GetSheetsNames(tableName, sheetsCount))
            {
                workbook.CreateSheet(sheetName);
            }
        }

        private static List<string> GetSheetsNames(string tableName, int sheetsCount)
        {
            List<string> list = new List<string>();

            if (string.IsNullOrEmpty(tableName))
            {
                tableName = "Sheet{0}";
            }
            else
            {
                tableName += "{0}";
            }

            for (int i = 0; i < sheetsCount; i++)
            {
                list.Add(string.Format(tableName, i));
            }

            return list;
        }

        #endregion

        #region Get workbook

        public static HSSFWorkbook GetWorkbook()
        {
            return GetWorkbook("NPOI Team", "NPOI");
        }

        public static HSSFWorkbook GetWorkbook(string companyName, string subject)
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = companyName;
            hssfworkbook.DocumentSummaryInformation = dsi;

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = subject;
            hssfworkbook.SummaryInformation = si;
            return hssfworkbook;
        }

        #endregion

        #region Get worksheet

        public static void GetWorksheet(ref HSSFWorkbook workbook, DataTable dt)
        {
            GetWorksheet(ref workbook, 26, 15, dt);
        }

        public static void GetWorksheet(ref HSSFWorkbook workbook, short rowHeight, int columnWidth, DataTable dt)
        {
            ISheet sheet = workbook.CreateSheet(dt.TableName);
            sheet.DefaultRowHeight = rowHeight;
            sheet.DefaultColumnWidth = columnWidth;

            IRow row = sheet.CreateRow(0);
            row.HeightInPoints = rowHeight;

            ICellStyle headerStyle = GetHeaderStyle(workbook);
            ICellStyle dataStyle = GetDataStyle(workbook);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
                cell.CellStyle = headerStyle;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + 1);
                dataRow.HeightInPoints = rowHeight;

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = dataRow.CreateCell(j);
                    string value = dt.Rows[i][j] != null ? dt.Rows[i][j].ToString() : "";
                    cell.SetCellValue(value);
                    cell.CellStyle = dataStyle;
                }
            }
        }

        #endregion

        #region Style

        public static ICellStyle GetHeaderStyle(IWorkbook workbook)
        {
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.FontName = "宋体";
            font.Boldweight = 600;
            font.Color = HSSFColor.Black.Index;
            style.SetFont(font);
            return style;
        }

        public static ICellStyle GetDataStyle(IWorkbook workbook)
        {
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.FontName = "宋体";
            font.Color = HSSFColor.Black.Index;
            style.SetFont(font);
            return style;
        }

        #endregion

        #region Combine cell

        public static void CombineCell(ISheet sheet, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowStart, rowEnd, colStart, colEnd);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        #endregion

        #region Verify

        public static bool IsExcel(string extension)
        {
            return ExcelCom.AllowedExtensions.Contains(extension);
        }

        public static bool IsExcel03(string extension)
        {
            return ExcelCom.AllowedExtensions.ToList().IndexOf(extension) == 0;
        }

        public static bool IsExcel07(string extension)
        {
            return ExcelCom.AllowedExtensions.ToList().IndexOf(extension) == 1;
        }

        #endregion

        #region Get Sheets count

        private static int GetSheetsCount(long recordsCount, ExcelProperties excelProperties)
        {
            int count = (int)recordsCount / excelProperties.MaxRowsCount;

            if (recordsCount % excelProperties.MaxRowsCount > 0)
            {
                count++;
            }

            return count;
        }

        #endregion

        /*
         * new start
         */



        #region Create

        public static void Create(string file)
        {
            IWorkbook workbook;

            using (FileStream fileStream = File.Create(file))
            {
                workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");
                workbook.Write(fileStream);
            }
        }

        #endregion


    }
}