using DevUtility.Com.Extension.SystemExt;
using DevUtility.Com.Model;
using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class DeleteService : BaseAppService
    {
        #region Variables

        string url, user, pwd;

        #endregion

        #region Constructor

        public DeleteService(string url, string user, string pwd)
        {
            this.url = url;
            this.user = user;
            this.pwd = pwd;
        }

        #endregion

        #region Start

        public override void Start()
        {
            //FtpHelper ftpHelper = new FtpHelper(user, pwd);

            //try
            //{
            //    ftpHelper.DeleteFile(url);
            //    DisplayMessage("Remove file completed!");
            //}
            //catch (Exception exception)
            //{
            //    DisplayMessage(exception.ToExceptionContent().ToString());
            //}

            //try
            //{
            //    ftpHelper.DeleteDirectory(url);
            //    DisplayMessage("Remove directory completed!");
            //}
            //catch (Exception exception)
            //{
            //    DisplayMessage(exception.ToExceptionContent().ToString());
            //}

            OperationResult result = FtpUtility.Delete(user, pwd, url);
            DisplayMessage(result.Message);
            DisplayMessage("Completed!");
        }

        #endregion
    }
}