using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.IO.Path
{
    public class CombineService : BaseAppService
    {
        public override void Start()
        {
            DisplayMessage(System.IO.Path.Combine("asd", "qwe"));
        }
    }
}