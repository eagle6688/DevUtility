using DevUtility.Com.Application;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Application.ConfigHelperTest
{
    public class GetEndpointService : BaseAppService
    {
        string name = "";

        public GetEndpointService(string name)
        {
            this.name = name;
        }

        public override void Start()
        {
            var endpoint = ConfigHelper.GetEndpoint(name);

            if (endpoint != null)
            {
                DisplayMessage(endpoint.Address.ToString());
                DisplayMessage(endpoint.Binding);
            }
        }
    }
}