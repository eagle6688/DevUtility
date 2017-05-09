using DevUtility.Out.Net;
using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class DownloadService : BaseAppService
    {
        #region Start

        public override void Start()
        {
            FtpHelper ftpHelperForWindows = new FtpHelper();
            //ftpHelperForWindows.Download("ftp://10.100.97.145:2101/setup.exe", @"E:\Downloads\setup.exe");
            //DisplayMessage("Download completed.");

            ftpHelperForWindows.DownloadProgressChangedEvent = (object sender, DownloadProgressChangedEventArgs e) =>
            {
                DisplayMessage($"BytesReceived: {e.BytesReceived}, ProgressPercentage: {e.ProgressPercentage}, TotalBytesToReceive: {e.TotalBytesToReceive}, UserState: {e.UserState}");
            };

            ftpHelperForWindows.DownloadAsync("ftp://10.100.97.145:2101/VisualStudio2017_ProductLaunchPoster-1.png", @"E:\Downloads\test.png");
        }

        #endregion
    }
}