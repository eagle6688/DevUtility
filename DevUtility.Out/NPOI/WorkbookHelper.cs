using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NPOI
{
    public class WorkbookHelper
    {
        #region Create

        public static IWorkbook Create(string fileName)
        {
            if (ExcelCom.IsExcel2007(fileName))
            {
                return new XSSFWorkbook();
            }

            if (ExcelCom.IsExcel2003(fileName))
            {
                return new HSSFWorkbook();
            }

            return null;
        }

        public static IWorkbook CreateInputWorkbook(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                if (ExcelCom.IsExcel2007(fileName))
                {
                    return new XSSFWorkbook(fileStream);
                }

                if (ExcelCom.IsExcel2003(fileName))
                {
                    return new HSSFWorkbook(fileStream);
                }
            }

            return null;
        }

        #endregion

        #region Append

        public static void Append(IWorkbook workbook, string fileName)
        {
            if (workbook == null)
            {
                throw new Exception("Workbook cannot be null!");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                workbook.Write(fileStream);
            }
        }

        public static void Append(string fileName, DataSet ds)
        {
            IWorkbook workbook = CreateInputWorkbook(fileName);

            if (workbook == null)
            {
                throw new Exception("Workbook cannot be null!");
            }

            workbook.Append(ds);
            Append(workbook, fileName);
        }

        public static void Append(string fileName, string sheetName, DataTable table)
        {
            IWorkbook workbook = CreateInputWorkbook(fileName);

            if (workbook == null)
            {
                throw new Exception("Workbook cannot be null!");
            }

            workbook.Append(sheetName, table);
            Append(workbook, fileName);
        }

        #endregion
    }
}