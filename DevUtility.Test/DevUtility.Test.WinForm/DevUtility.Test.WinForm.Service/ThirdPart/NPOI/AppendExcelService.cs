using DevUtility.Out.NPOI;
using DevUtility.Win.Services.AppService;
using System;
using System.Data;

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

            NPOIHelper.Append(file, "haha", dt);
        }
    }
}