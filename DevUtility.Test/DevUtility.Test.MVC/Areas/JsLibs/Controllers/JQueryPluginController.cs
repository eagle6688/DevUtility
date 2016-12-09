using DevUtility.Test.Model.MvcApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevUtility.Test.MVC.Areas.JsLibs.Controllers
{
    public class JQueryPluginController : Controller
    {
        // GET: JsLibs/JQueryPlugin

        #region Index

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Redirect Post

        [HttpPost]
        public JsonResult RedirectPost(TestTable model)
        {
            return Json(model);
        }

        #endregion
    }
}