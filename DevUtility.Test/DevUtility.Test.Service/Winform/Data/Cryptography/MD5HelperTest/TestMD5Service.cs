using DevUtility.Com.Data.Cryptography;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.Cryptography.MD5HelperTest
{
    public class TestMD5Service : BaseAppService
    {
        string value = "";

        public TestMD5Service(string value)
        {
            this.value = value;
        }

        public override void Start()
        {
            DisplayMessage(string.Format("value:{0}", value));
            string encodeValue = MD5Helper.Encrypt(value);
            DisplayMessage(string.Format("Encrypt: {0}", encodeValue));
        }
    }
}