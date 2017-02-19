using DevUtility.Com.IO;
using DevUtility.Com.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DevUtility.Test.WebForm.jquery.plugins.jquery.uploader
{
    /// <summary>
    /// Summary description for TestUploaderHandler
    /// </summary>
    public class TestUploaderHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            OperationResult result = new OperationResult();
            string saveDir = context.Server.MapPath("~/App_Data/");
            string fileName = context.Request.Files[0].FileName;

            if (!DirectoryHelper.Create(saveDir))
            {
                result.SetErrorMessage(string.Format("Create directory {0} failed.", saveDir));
                context.Response.Write(JsonConvert.SerializeObject(result));
                context.Response.End();
                return;
            }

            string savePath = Path.Combine(saveDir, fileName);
            context.Request.Files[0].SaveAs(savePath);
            context.Response.Write(JsonConvert.SerializeObject(result));
            context.Response.End();
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