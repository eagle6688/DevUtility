using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net
{
    public delegate void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e);

    public delegate void DownloadDataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e);

    public delegate void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e);

    public delegate void UploadFileCompleted(object sender, UploadFileCompletedEventArgs e);
}