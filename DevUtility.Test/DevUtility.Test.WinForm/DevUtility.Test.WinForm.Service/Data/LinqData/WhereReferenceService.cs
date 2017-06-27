using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.LinqData
{
    public class WhereReferenceService : BaseAppService
    {
        public override void Start()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student()
            {
                Name = "A"
            });

            students.Add(new Student()
            {
                Name = "B"
            });

            var temp = students.Where(q => q.Name.Equals("A")).ToList();
            temp.ForEach(q => q.Age = 1);
            DisplayMessage("OK");
        }
    }
}