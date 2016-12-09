using DevUtility.Com.Data.Cryptography;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Data.Cryptography.SHA1HelperTest
{
    public class TestFileSHA1Service : BaseAppService
    {
        string value = "";

        public TestFileSHA1Service(string value)
        {
            this.value = value;
        }

        public override void Start()
        {
            string encodeValue = SHA1Helper.EncryptFile(value);
            DisplayMessage(string.Format("Encrypt: {0}", encodeValue));
        }
    }
}