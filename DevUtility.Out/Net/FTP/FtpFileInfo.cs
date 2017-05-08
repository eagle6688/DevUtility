using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FtpFileInfo
    {
        public string Name { set; get; }

        public long Size { set; get; }

        public FtpFileTypes Type { set; get; }

        public DateTime UpdateTime { set; get; }
    }
}