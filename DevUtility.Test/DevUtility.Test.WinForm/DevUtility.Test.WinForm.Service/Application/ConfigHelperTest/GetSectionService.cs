using DevUtility.Com.Application;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Application.ConfigHelperTest
{
    public class GetSectionService : BaseAppService
    {
        string name = "";

        public GetSectionService(string name)
        {
            this.name = name;
        }

        public override void Start()
        {
            var section = ConfigHelper.GetSection(name);
        }
    }
}