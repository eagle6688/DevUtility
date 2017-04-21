using DevUtility.Com.Data.Cryptography;
using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevUtility.Test.MVC.Areas.Data.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Data/Security

        #region Index

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region AES Encrypt

        [HttpPost]
        public JsonResult AESEncrypt(string code, string value)
        {
            OperationResult result = new OperationResult();
            result.Data = AESHelper.Encrypt(code, value);
            return Json(result);
        }

        #endregion
    }
}