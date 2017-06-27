using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Research.Others
{
    public class StaticPropertyService : BaseAppService
    {
        static Student GetStudent
        {
            get
            {
                return new Student();
            }
        }

        public override void Start()
        {
            var s1 = GetStudent;
            var s2 = GetStudent;

            if (s1 == s2)
            {
                DisplayMessage("Equal!");
                return;
            }

            DisplayMessage("Not equal!");
        }
    }
}