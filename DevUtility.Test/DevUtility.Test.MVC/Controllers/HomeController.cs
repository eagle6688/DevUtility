using DevUtility.Test.MVC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [Auth(IsAuth = true)]
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

        #region URL

        public ActionResult URL()
        {
            List<string> list = new List<string>();
            list.Add(string.Format("{0}: {1}", "Request.Url             ", Request.Url));
            list.Add(string.Format("{0}: {1}", "Request.Url.AbsolutePath", Request.Url.AbsolutePath));
            list.Add(string.Format("{0}: {1}", "Request.Url.AbsoluteUri ", Request.Url.AbsoluteUri));
            list.Add(string.Format("{0}: {1}", "Request.Url.Authority   ", Request.Url.Authority));
            list.Add(string.Format("{0}: {1}", "Request.Url.DnsSafeHost ", Request.Url.DnsSafeHost));
            list.Add(string.Format("{0}: {1}", "Request.Url.Host        ", Request.Url.Host));
            list.Add(string.Format("{0}: {1}", "Request.Url.LocalPath   ", Request.Url.LocalPath));
            list.Add(string.Format("{0}: {1}", "Request.Url.OriginalString", Request.Url.OriginalString));
            list.Add(string.Format("{0}: {1}", "Request.Url.PathAndQuery", Request.Url.PathAndQuery));
            list.Add(string.Format("{0}: {1}", "Request.Url.Port        ", Request.Url.Port));
            list.Add(string.Format("{0}: {1}", "Request.Url.Query       ", Request.Url.Query));
            list.Add(string.Format("{0}: {1}", "Request.Url.Scheme      ", Request.Url.Scheme));
            list.Add(string.Format("{0}: {1}", "Request.Url.Segments    ", Request.Url.Segments));
            return View(list);
        }

        #endregion
    }
}