using DevUtility.Out.Net.WCF;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.WCF
{
    public class PushMessageService : BaseAppService
    {
        #region Variables

        string input = "";

        #endregion

        #region Constructor

        public PushMessageService(string input)
        {
            this.input = input;
        }

        #endregion

        #region Start

        public override void Start()
        {
            using (IPushMessage client = WCFHelper.CreateService<IPushMessage>("BasicHttpBinding_IPushMessage"))
            {
                client.Push(input);
            }

            WCFHelper.ExecuteMethod<IPushMessage>("BasicHttpBinding_IPushMessage", "Push", new object[] { input });
        }

        #endregion
    }
}