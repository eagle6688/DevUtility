using DevUtility.Com.Model;
using DevUtility.Out.Extensions.System.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace DevUtility.Test.WebForm.jquery.plugins.jquery.upload.helper
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            OperationResult result = new OperationResult();

            if (context.Request.SaveAsSlice(ref result))
            {
                string objectFilePath = context.Server.MapPath(string.Format("~/App_Data/{0}", context.Request["fileName"]));

                if (context.Request.CombineSlices(objectFilePath, ref result))
                {
                    context.Response.Write("Combined!");
                    context.Response.End();
                }
            }

            context.Response.Write("Empty!");
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