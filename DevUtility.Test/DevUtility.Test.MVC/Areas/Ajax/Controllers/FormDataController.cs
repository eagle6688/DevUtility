using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevUtility.Test.MVC.Areas.Ajax.Controllers
{
    public class FormDataController : Controller
    {
        //
        // GET: /Ajax/FormData/

        #region Index
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(HttpPostedFileBase MyFile)
        {
            OperationResult result = new OperationResult();
            return Json(result);
        }

        #endregion

        #region Test DateTime Zone

        public JsonResult TestDateTimeZone()
        {
            DateTime utcTime = new DateTime(2016, 9, 16, 1, 1, 1, DateTimeKind.Utc);
            DateTime localTime = new DateTime(2016, 9, 16, 1, 1, 1, DateTimeKind.Local);

            return Json(new
            {
                UTCTime = utcTime,
                UTCTimeStr = utcTime.ToString("yyyy-MM-dd HH:mm:ss"),
                UTCTimeLocalStr = utcTime.ToLocalTime().ToString(),
                LocalTime = localTime,
                LocalTimeStr = localTime.ToString("yyyy-MM-dd HH:mm:ss"),
                LocalTimeUTCStr = localTime.ToUniversalTime().ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}