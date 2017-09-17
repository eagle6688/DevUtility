using DevUtility.Com.Data;
using DevUtility.Out.Net.WCF;
using DevUtility.Test.Common.Winform;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Enums
{
    public class GetTypeService : BaseAppService
    {
        string type = "";

        public GetTypeService(string type)
        {
            this.type = type;
        }

        public override void Start()
        {
            //var bindingType = EnumHelper.GetType<BindingType>(type);
            //DisplayMessage(bindingType.ToString());

            var testType = EnumHelper.GetType<TestType>(type);
            DisplayMessage(testType.ToString());

            var testType1 = (TestType)1;
            DisplayMessage(testType1.ToString());

            var testType2 = Enum.Parse(typeof(TestType), type);
            DisplayMessage(testType2.ToString());
            DisplayMessage(((int)testType2).ToString());
        }
    }
}