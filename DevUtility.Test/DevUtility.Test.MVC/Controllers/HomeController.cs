using DevUtility.Test.MVC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevUtility.Test.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        #region Index

        [Auth(IsAuth = true)]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Auth

        [Auth(IsAuth = false)]
        public ActionResult Auth()
        {
            return View();
        }

        #endregion

        #region Login

        public ActionResult Login()
        {
            return View();
        }

        #endregion
    }
}