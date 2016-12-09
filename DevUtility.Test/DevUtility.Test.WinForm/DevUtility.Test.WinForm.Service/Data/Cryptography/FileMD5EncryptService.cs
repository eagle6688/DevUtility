using DevUtility.Com.Data.Cryptography;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Cryptography
{
    public class FileMD5EncryptService : BaseAppService
    {
        string value = "";

        public FileMD5EncryptService(string value)
        {
            this.value = value;
        }

        public override void Start()
        {
            string encodeValue = MD5Helper.EncryptFile(value);
            DisplayMessage(string.Format("Encrypt: {0}", encodeValue));
        }
    }
}