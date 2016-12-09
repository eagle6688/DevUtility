using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class UploadService : BaseAppService
    {
        #region Variables

        string host, user, pwd;

        #endregion

        #region UploadService

        public UploadService(string host, string user, string pwd)
        {
            this.host = host;
            this.user = user;
            this.pwd = pwd;
        }

        #endregion

        #region Start

        public override void Start()
        {
            FTPHelper ftpHelper = new FTPHelper(user, pwd);
            string message = "";

            if (!ftpHelper.UploadOverMove("ftp://127.0.0.1/storage/", @"E:\Downloads\Hotel.png", "ftp://127.0.0.1/storage/Hotel.png", "Hotel.png", ref message))
            {
                DisplayMessage("Failed!");
            }
            else
            {
                DisplayMessage("Success!");
            }
        }

        #endregion
    }
}