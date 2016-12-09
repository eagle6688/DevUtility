using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.RandomHelper
{
    public class GetRandomNumberService : BaseAppService
    {
        public override void Start()
        {
            for (int i = 0; i < 20; i++)
            {
                int num = DevUtility.Com.Data.RandomHelper.GetRandomNumber(0, 2);
                DisplayMessage(num.ToString());
            }
        }
    }
}