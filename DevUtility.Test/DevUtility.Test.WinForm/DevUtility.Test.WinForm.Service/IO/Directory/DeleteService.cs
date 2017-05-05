using DevUtility.Com.IO;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.IO.Directory
{
    public class DeleteService : BaseAppService
    {
        string dir = "";

        public DeleteService(string dir)
        {
            this.dir = dir;
        }

        public override void Start()
        {
            if (DirectoryHelper.Delete(dir))
            {
                DisplayMessage("Success.");
            }
            else
            {
                DisplayMessage("Failed!");
            }
        }
    }
}