using DevUtility.Com.Base;
using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Base.Property
{
    public class FiltrateInvalidDateTimeService : BaseAppService
    {
        #region Start

        public override void Start()
        {
            Student student = new Student()
            {
                ID = 10001,
                Age = 20,
                Name = "Trump",
                Gender = 1,
                IsDeleted = 0,
                Entry = DateTime.Now
            };

            var properties = PropertyHelper.GetProperties<Student>();
            var result = PropertyHelper.FiltrateInvalidDateTimeProperties<Student>(student, properties);
            DisplayMessage("OK");
        }

        #endregion
    }
}