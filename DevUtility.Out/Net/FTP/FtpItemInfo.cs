using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FtpItemInfo
    {
        public string FtpPath { set; get; }

        public string Name { set; get; }

        public long Size { set; get; }

        public FtpItemTypes Type { set; get; }

        public DateTime UpdateTime { set; get; }

        public string UnixAuthority { set; get; }
    }
}