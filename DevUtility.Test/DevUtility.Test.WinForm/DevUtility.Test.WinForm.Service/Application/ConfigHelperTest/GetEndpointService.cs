using DevUtility.Out.Application;
using DevUtility.Win.Services.AppService;

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