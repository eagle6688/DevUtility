using DevUtility.Test.Model.WebForm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DevUtility.Test.WebForm.Handlers
{
    /// <summary>
    /// Summary description for DataHandler
    /// </summary>
    public class DataHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageIndex = 0;
            int pageSize = 0;
            int length = 101;
            StringBuilder dataString = new StringBuilder("{");

            if (context.Request["pageIndex"] != null && context.Request["pageSize"] != null)
            {
                int.TryParse(context.Request["pageIndex"].ToString(), out pageIndex);
                int.TryParse(context.Request["pageSize"].ToString(), out pageSize);
            }

            if (context.Request["length"] != null)
            {
                int.TryParse(context.Request["length"].ToString(), out length);
            }

            if (pageIndex > 0 && pageSize > 0)
            {
                List<MyModel> list = new List<MyModel>();

                for (var i = 0; i < length; i++)
                {
                    MyModel model = new MyModel();
                    model.MyID = i + 1;
                    model.Name = "Name" + i;
                    model.CreateTime = DateTime.Now;
                    list.Add(model);
                }

                dataString.AppendFormat("\"Count\": \"{0}\", ", list.Count());
                dataString.Append("\"Data\": ");
                string jsonDataString = JsonConvert.SerializeObject(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
                dataString.Append(jsonDataString);
            }

            dataString.Append("}");
            context.Response.Write(dataString.ToString());
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