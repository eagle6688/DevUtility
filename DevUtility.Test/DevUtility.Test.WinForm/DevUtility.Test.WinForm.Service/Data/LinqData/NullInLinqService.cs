using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.LinqData
{
    public class NullInLinqService : BaseAppService
    {
        public override void Start()
        {
            List<Student> students = null;

            var query = from q in students
                        where q.Name == "asd"
                        select q;

            if (query == null)
            {
                DisplayMessage("Null");
            }
            else
            {
                DisplayMessage("No Null object!");
            }
        }
    }
}