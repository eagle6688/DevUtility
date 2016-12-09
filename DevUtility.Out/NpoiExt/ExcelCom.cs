using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NpoiExt
{
    public class ExcelCom
    {
        public const int MaxSheetsCount = 255;

        public static string[] AllowedExtensions = { ".xls", ".xlsx" };

        public static ExcelProperties Excel03Properties
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

        public static ExcelProperties Excel07Properties
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
    }
}