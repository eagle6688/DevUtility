using DevUtility.Com.Data.Cryptography;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.Cryptography.SHA256HelperTest
{
    public class TestSHA256Service : BaseAppService
    {
        string value = "";

        public TestSHA256Service(string value)
        {
            this.value = value;
        }

        public override void Start()
        {
            DisplayMessage(string.Format("value:{0}", value));
            string encodeValue = SHA256Helper.Encrypt(value);
            DisplayMessage(string.Format("Encrypt: {0}", encodeValue));
        }
    }
}