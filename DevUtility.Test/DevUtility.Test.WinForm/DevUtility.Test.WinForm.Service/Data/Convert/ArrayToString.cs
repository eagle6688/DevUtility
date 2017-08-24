using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Convert
{
    public class ArrayToString : BaseAppService
    {
        public override void Start()
        {
            List<string> list = null;
            DisplayMessage(string.Join(",", list));
        }
    }
}