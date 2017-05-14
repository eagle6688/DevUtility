using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FtpDeleteHelper : BaseNetHelper
    {
        #region Variables

        FtpHelper ftpHelper;

        List<FtpItemInfo> list = new List<FtpItemInfo>();

        List<FtpItemInfo> directories = new List<FtpItemInfo>();

        #endregion

        #region Constructor

        public FtpDeleteHelper()
            : this("anonymous", "")
        {

        }

        public FtpDeleteHelper(string loginName, string password)
            : this(loginName, password, null)
        {

        }

        public FtpDeleteHelper(string loginName, string password, WebProxy webProxy)
            : base(loginName, password, webProxy)
        {
            ftpHelper = new FtpHelper(loginName, password, webProxy);
        }

        #endregion

        #region Delete

        public void Delete(string ftpPath)
        {
            var item = ftpHelper.GetItemInfo(ftpPath);

            if (item == null)
            {
                return;
            }

            if (item.Type == FtpItemTypes.File)
            {
                ftpHelper.DeleteFile(item.FtpPath);
                return;
            }

            directories.Add(item);
            var subItems = ftpHelper.GetDirectoryItems(ftpPath);
            list.AddRange(subItems);
            Delete(0);

            for (int i = directories.Count - 1; i >= 0; i--)
            {
                ftpHelper.DeleteDirectory(directories[i].FtpPath);
            }
        }

        private void Delete(int index)
        {
            if (index >= list.Count)
            {
                return;
            }

            if (list[index].Type == FtpItemTypes.Directory)
            {
                var subNodes = ftpHelper.GetDirectoryItems(list[index].FtpPath);

                if (subNodes.Count == 0)
                {
                    ftpHelper.DeleteDirectory(list[index].FtpPath);
                }
                else
                {
                    directories.Add(list[index]);
                    list.AddRange(subNodes);
                    subNodes = null;
                }
            }
            else
            {
                if (list[index].Type == FtpItemTypes.File)
                {
                    ftpHelper.DeleteFile(list[index].FtpPath);
                }
            }

            Delete(index + 1);
        }

        #endregion
    }
}