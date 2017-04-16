using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace DevUtility.Test.WebForm.Handlers
{
    /// <summary>
    /// Summary description for Concurrency
    /// </summary>
    public class Concurrency : IHttpHandler
    {
        string param = string.Empty;

        static string sParam = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            param = context.Request.QueryString["p"];
            sParam = context.Request.QueryString["p"];

            Thread.Sleep(3000);

            context.Response.Write($"{param}, {sParam}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}