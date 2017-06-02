using DevUtility.Com.Data;
using DevUtility.Out.Net.WCF;
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
            var bindingType = EnumHelper.GetType<BindingType>(type);
            DisplayMessage(bindingType.ToString());
        }
    }
}