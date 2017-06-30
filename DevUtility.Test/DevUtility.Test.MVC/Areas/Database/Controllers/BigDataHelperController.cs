using DevUtility.Com.Data;
using DevUtility.Com.Database.DBHelper;
using DevUtility.Test.Common.TestMVC;
using DevUtility.Test.Model.MvcApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevUtility.Test.MVC.Areas.Database.Controllers
{
    public class BigDataHelperController : Controller
    {
        //
        // GET: /Database/BigDataHelper/

        public ActionResult Index()
        {
            BigDataHelper bigDataHelper = new BigDataHelper(DBConn.PublisherDBConn);
            List<TestTable> list = new List<TestTable>();

            list.Add(new TestTable()
            {
                Name = "Test"
            });

            DataTable table = ListHelper.ToDataTable<TestTable>(list, new List<string>() { "ID" });
            table.TableName = "Test";
            bool result = bigDataHelper.Insert(table);

            return View();
        }
    }
}