using DevUtility.Com.Data.Cryptography;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.Cryptography.AESHelperTest
{
    public class TestDecryptService : BaseAppService
    {
        string value = "";

        public TestDecryptService(string value)
        {
            this.value = value;
        }

        public override void Start()
        {
            string key = "esupport.enterprise";
            DisplayMessage(string.Format("key:{0}, value:{1}", key, value));
            //DisplayMessage(string.Format("Decrypt base64: {0}", AESHelper.DecryptFromBase64(key, value)));
            DisplayMessage(string.Format("Decrypt hex: {0}", AESHelper.Decrypt(key, value)));
        }
    }
}