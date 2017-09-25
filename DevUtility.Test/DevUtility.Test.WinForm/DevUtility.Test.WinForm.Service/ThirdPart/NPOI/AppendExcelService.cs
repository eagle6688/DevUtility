using DevUtility.Out.NpoiExt;
using DevUtility.Win.Services.AppService;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.ThirdPart.NPOI
{
    public class AppendExcelService : BaseAppService
    {
        string file = "";

        public AppendExcelService(string file)
        {
            this.file = file;
        }

        public override void Start()
        {
            IWorkbook workbook;

            DataTable dt = new DataTable();
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");

            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = $"A{i}";
                dr[1] = $"B{i}";
                dr[2] = $"C{i}";
                dt.Rows.Add(dr);
            }

            using (FileStream inFileStream = new FileStream(file, FileMode.Open))
            {
                workbook = new XSSFWorkbook(inFileStream);
                workbook.AppendRows("Sheet1", dt);
            }

            using (FileStream outFileStream = new FileStream(file, FileMode.Open))
            {
                workbook.Write(outFileStream);
            }
        }
    }
}