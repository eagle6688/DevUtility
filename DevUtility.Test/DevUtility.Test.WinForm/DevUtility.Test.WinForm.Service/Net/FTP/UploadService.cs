using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class UploadService : BaseAppService
    {
        #region Variables

        string user, pwd;

        #endregion

        #region Constructor

        public UploadService(string user, string pwd)
        {
            this.user = user;
            this.pwd = pwd;
        }

        #endregion

        #region Start

        public override void Start()
        {
            FtpHelper ftpHelper = new FtpHelper();
            ftpHelper.Upload(@"E:\Downloads\CentOS EV.txt", "ftp://10.100.97.145:2101/CentOS EV.txt");
            DisplayMessage("Upload completed!");

            ftpHelper.UploadProgressChangedEvent = (object sender, UploadProgressChangedEventArgs e) =>
            {
                DisplayMessage($"ProgressPercentage: {e.ProgressPercentage}, TotalBytesToReceive: {e.TotalBytesToReceive}, TotalBytesToSend: {e.TotalBytesToSend}, BytesReceived: {e.BytesReceived}, BytesSent: {e.BytesSent}");
            };

            ftpHelper.UploadAsync(@"E:\Downloads\VisualStudio2017_ProductLaunchPoster-1.png", "ftp://10.100.97.145:2101/VisualStudio2017_ProductLaunchPoster-1.png");
        }

        #endregion
    }
}