using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Convert
{
    public class Count0ToListService : BaseAppService
    {
        public override void Start()
        {
            var students = new List<Student>();
            DisplayMessage($"students count = {students.Count}");

            var list = students.Select(q => q.Name).ToList();
            DisplayMessage($"list count = {list.Count}");
        }
    }
}