using DevUtility.Com.IO.Files;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.DataTableExt
{
    public class TestDataTableService : BaseAppService
    {
        public override void Start()
        {
            DataTable csvDT = CsvHelper.GetData(@"D:\Download\asd.csv");
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");

            var row = dt.NewRow();
            row["ID"] = "B37B71F7-D2DA-4525-A054-371040F24189";
            dt.Rows.Add(row);

            var rows = dt.Select("ID='" + Guid.Parse("B37B71F7-D2DA-4525-A054-371040F24189") + "'");
            DisplayMessage(rows.Length.ToString());
        }
    }
}