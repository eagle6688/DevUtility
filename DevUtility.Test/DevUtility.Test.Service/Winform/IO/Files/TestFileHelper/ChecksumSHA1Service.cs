using DevUtility.Com.IO.Files;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.IO.Files.TestFileHelper
{
    public class ChecksumSHA1Service : BaseAppService
    {
        string filePath = "";

        public ChecksumSHA1Service(string filePath)
        {
            this.filePath = filePath;
        }

        public override void Start()
        {
            DisplayMessage(DateTime.Now.ToLongTimeString());

            string sha1Checksum = FileHelper.ChecksumSHA1(filePath);
            DisplayMessage(sha1Checksum);

            DisplayMessage(DateTime.Now.ToLongTimeString());
        }
    }
}