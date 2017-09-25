using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NPOI
{
    public class ExcelCom
    {
        #region Variables

        public const int MaxSheetsCount = 255;

        public const string Excel2003Extension = ".xls";

        public const string Excel2007Extension = ".xlsx";

        public static string[] Extensions = { Excel2003Extension, Excel2007Extension };

        #endregion

        #region Excel 2003 Properties

        public static ExcelProperties Excel2003Properties
        {
            get
            {
                return new ExcelProperties()
                {
                    MaxRowsCount = 65536,
                    MaxColumnsCount = 256
                };
            }
        }

        #endregion

        #region Excel 2007 Properties

        public static ExcelProperties Excel2007Properties
        {
            get
            {
                return new ExcelProperties()
                {
                    MaxRowsCount = 1048576,
                    MaxColumnsCount = 16384
                };
            }
        }

        #endregion

        #region Is Excel

        public static bool IsExcel(string extension)
        {
            return Extensions.Contains(extension);
        }

        #endregion

        #region Is Excel 2007

        public static bool IsExcel2007(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            return Path.GetExtension(fileName).Equals(Excel2007Extension);
        }

        public static bool IsExcel2007Ext(string extension)
        {
            return Extensions.ToList().IndexOf(extension) == 1;
        }

        #endregion

        #region Is Excel 2003

        public static bool IsExcel2003(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            return Path.GetExtension(fileName).Equals(Excel2003Extension);
        }

        public static bool IsExcel2003Ext(string extension)
        {
            return Extensions.ToList().IndexOf(extension) == 0;
        }

        #endregion

        #region Sheet name

        public const string SheetNameFormat = "Sheet{0}";

        public static string GetSheetName(int index)
        {
            return string.Format(SheetNameFormat, index);
        }

        #endregion
    }
}