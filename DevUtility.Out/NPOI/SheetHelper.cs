using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NPOI
{
    public class SheetHelper
    {
        public static void Create(IWorkbook workbook, List<string> sheets)
        {
            foreach (string sheet in sheets)
            {
                workbook.CreateSheet(sheet);
            }
        }
    }
}