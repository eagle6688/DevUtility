using DevUtility.Com.Model;
using DevUtility.Test.Model.MvcApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevUtility.Test.MVC.Controllers
{
    public class WebSocketController : Controller
    {
        // GET: WebSocket

        #region Index

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Start Server

        public JsonResult StartServer()
        {
            OperationResult result = new OperationResult();

            if (!GlobalModel.Instance.Start())
            {
                result.SetErrorMessage("Server had been started.");
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            result.Message = "Server has been started.";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Stop server

        public JsonResult StopServer()
        {
            OperationResult result = new OperationResult();
            GlobalModel.Instance.Stop();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}