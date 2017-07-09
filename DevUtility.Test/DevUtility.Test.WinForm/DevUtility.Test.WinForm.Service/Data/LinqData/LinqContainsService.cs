using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.LinqData
{
    public class LinqContainsService : BaseAppService
    {
        string input = string.Empty;

        public LinqContainsService(string input)
        {
            this.input = input;
        }

        public override void Start()
        {
            var students = GetStudents();
            DisplayMessage($"Get {students.Count} students");
            ContainsSearch(students);
            MultiContainsSearch(students);
            MultiEqualsSearch(students);
        }

        private List<Student> GetStudents()
        {
            var list = new List<Student>();

            for (int i = 0; i < 20000; i++)
            {
                list.Add(new Student
                {
                    ID = i + 1,
                    Age = i + 10,
                    Name = $"Student{i}FromSchool1"
                });
            }

            for (int i = 0; i < 30000; i++)
            {
                list.Add(new Student
                {
                    ID = i + 20001,
                    Age = i + 10,
                    Name = $"Student{i}FromSchool2"
                });
            }

            for (int i = 0; i < 20000; i++)
            {
                list.Add(new Student
                {
                    ID = i + 50001,
                    Age = i + 10,
                    Name = $"Student{i}FromSchool3"
                });
            }

            for (int i = 0; i < 30000; i++)
            {
                list.Add(new Student
                {
                    ID = i + 70001,
                    Age = i + 10,
                    Name = $"Student{i}FromSchool4"
                });
            }

            return list;
        }

        private void ContainsSearch(List<Student> students)
        {
            DateTime start = DateTime.Now;

            var query = (from s in students
                         where s.Name.IndexOf(input, StringComparison.OrdinalIgnoreCase) > -1
                         select s).ToList();

            DisplayMessage($"cost {DateTime.Now.Subtract(start).TotalMilliseconds} ms");
            DisplayMessage($"{query.Count} items found!");
        }

        private void MultiContainsSearch(List<Student> students)
        {
            DateTime start = DateTime.Now;

            var query1 = from s in students
                         where s.Name.IndexOf(input, StringComparison.OrdinalIgnoreCase) > -1
                         select s;

            var query2 = from s in students
                         where s.Name.IndexOf(input, StringComparison.OrdinalIgnoreCase) > -1
                         select s;

            var query3 = from s in students
                         where s.Name.IndexOf(input, StringComparison.OrdinalIgnoreCase) > -1
                         select s;

            var list = query1.Concat(query2).Concat(query3).Distinct().ToList();
            DisplayMessage($"cost {DateTime.Now.Subtract(start).TotalMilliseconds} ms");
            DisplayMessage($"{list.Count} items found!");
        }

        private void MultiEqualsSearch(List<Student> students)
        {
            DateTime start = DateTime.Now;

            var query1 = from s in students
                         where s.Name.Equals(input, StringComparison.OrdinalIgnoreCase)
                         select s;

            var query2 = from s in students
                         where s.Name.Equals(input, StringComparison.OrdinalIgnoreCase)
                         select s;

            var query3 = from s in students
                         where s.Name.Equals(input, StringComparison.OrdinalIgnoreCase)
                         select s;

            var list = query1.Concat(query2).Concat(query3).Distinct().ToList();
            DisplayMessage($"cost {DateTime.Now.Subtract(start).TotalMilliseconds} ms");
            DisplayMessage($"{list.Count} items found!");
        }
    }
}