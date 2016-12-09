using DevUtility.Com.Data.Cryptography;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.Cryptography.AESHelperTest
{
    public class TestEncryptService : BaseAppService
    {
        string value = "";

        public TestEncryptService(string value)
        {
            this.value = value;
        }

        public override void Start()
        {
            string key = "1234567890";
            DisplayMessage(string.Format("key:{0}, value:{1}", key, value));
            //DisplayMessage(string.Format("Encrypt base64: {0}", AESHelper.EncryptToBase64(key, value)));
            DisplayMessage(string.Format("Encrypt hex: {0}", AESHelper.Encrypt(key, value)));
        }
    }
}