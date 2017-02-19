using DevUtility.Com.Model;
using DevUtility.Out.Extensions.System.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevUtility.Test.WebForm.jquery.plugins.jquery.slicingUploader
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
            string sliceSaveDir = context.Server.MapPath("~/App_Data/");

            if (context.Request.SaveAsSlice(sliceSaveDir, ref result))
            {
                string objectFilePath = context.Server.MapPath(string.Format("~/App_Data/{0}", context.Request["fileName"]));

                if (context.Request.CombineSlices(sliceSaveDir, objectFilePath, ref result))
                {
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    context.Response.End();
                    return;
                }
            }

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