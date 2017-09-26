using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NPOI
{
    public class NPOIHelper
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

                int rowsCount = sheet.LastRowNum + 1;
                int columnsCount = firstRow.LastCellNum;

                for (int j = 0; j < columnsCount; j++)
                {
                    table.Columns.Add(j.ToString());
                }

                for (int j = 0; j < rowsCount; j++)
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



        #region Create

        public static void Create(string fileName, string sheetName)
        {
            IWorkbook workbook = WorkbookHelper.Create(fileName);

            if (workbook == null)
            {
                throw new Exception("Cannot create IWorkbook object!");
            }

            workbook.CreateSheet(sheetName);
            Create(workbook, fileName);
        }

        public static void Create(IWorkbook workbook, string fileName)
        {
            if (workbook == null)
            {
                throw new Exception("workbook cannot be null!");
            }

            using (FileStream fileStream = File.Create(fileName))
            {
                workbook.Write(fileStream);
            }
        }

        public static void Create(string templateFileName, string fileName, DataSet ds)
        {
            if (!File.Exists(templateFileName))
            {
                throw new Exception("Template file not found!");
            }

            if (File.Exists(fileName))
            {
                throw new Exception("File exists!");
            }

            IWorkbook templateWorkbook = WorkbookHelper.CreateInputWorkbook(templateFileName);

            if (templateWorkbook == null)
            {
                throw new Exception("Cannot create IWorkbook object!");
            }

            IWorkbook workbook = templateWorkbook;
            Create(workbook, fileName);
        }

        public static void Create(string templateFileName, string fileName, string sheetName, DataTable table)
        {
            if (!File.Exists(templateFileName))
            {
                throw new Exception("Template file not found!");
            }

            if (File.Exists(fileName))
            {
                throw new Exception("File exists!");
            }

            IWorkbook templateWorkbook = WorkbookHelper.CreateInputWorkbook(templateFileName);

            if (templateWorkbook == null)
            {
                throw new Exception("Cannot create IWorkbook object!");
            }

            IWorkbook workbook = WorkbookHelper.Append(templateWorkbook, sheetName, table);
            Create(workbook, fileName);
        }

        #endregion

        #region Append

        public static void Append(string fileName, DataSet ds)
        {
            WorkbookHelper.Append(fileName, ds);
        }

        public static void Append(string fileName, string sheetName, DataTable dt)
        {
            WorkbookHelper.Append(fileName, sheetName, dt);
        }

        #endregion
    }
}