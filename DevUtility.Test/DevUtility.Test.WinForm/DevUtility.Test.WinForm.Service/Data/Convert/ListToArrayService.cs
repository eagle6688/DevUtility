using DevUtility.Com.Application.ComAttributes;
using DevUtility.Com.Data;
using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Data.Convert
{
    public class ListToArrayService : BaseAppService
    {
        public override void Start()
        {
            List<Student> list = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Student()
                {
                    Age = i + 20,
                    Name = $"s{i}",
                    CreateTime = DateTime.Now,
                    Gender = 1,
                    ID = i,
                    IsDeleted = 0
                });
            }

            string[][] array = ListHelper.ToArray<Student>(list);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(array);
            //DisplayMessage(json);

            var properties = Com.Base.PropertyHelper.GetPropertiesByAttribute<Student, PropertyIndexAttribute>();
            properties = PropertyIndexAttribute.SortByIndex(properties);
            string[][] array1 = ListHelper.ToArray<Student>(list, properties);
            string json1 = Newtonsoft.Json.JsonConvert.SerializeObject(array1);
            DisplayMessage(json1);

            var students = ListHelper.ToList<Student>(array1, properties);
            string json2 = Newtonsoft.Json.JsonConvert.SerializeObject(students);
            DisplayMessage(json2);
        }
    }
}