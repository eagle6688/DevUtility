using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.LinqData
{
    public class DistinctService : BaseAppService
    {
        public override void Start()
        {
            List<Student> list = new List<Student>();

            list.Add(new Student()
            {
                Age = 1,
                Name = "Student1",
                ID = 1001
            });

            list.Add(new Student()
            {
                Age = 1,
                Name = "Student1",
                ID = 1002
            });

            var query = (from p in list
                         select new
                         {
                             p.Age,
                             p.Name
                         }).Distinct();

            DisplayMessage(Newtonsoft.Json.JsonConvert.SerializeObject(query.ToList()));
        }
    }
}