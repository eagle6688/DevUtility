using DevUtility.Win.Services.AppService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Convert
{
    public class ArrayListService : BaseAppService
    {
        public override void Start()
        {
            ArrayList list1 = new ArrayList();
            list1.Add(1);
            list1.Add("ASD");

            DisplayMessage(Newtonsoft.Json.JsonConvert.SerializeObject(list1));

            ArrayList list2 = new ArrayList();
            list2.Add(1);
            list2.Add("GUID");

            DisplayMessage(Newtonsoft.Json.JsonConvert.SerializeObject(list2));
        }
    }
}