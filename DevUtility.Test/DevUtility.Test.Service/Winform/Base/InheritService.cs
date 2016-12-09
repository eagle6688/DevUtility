using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Base
{
    public class InheritService : BaseAppService
    {
        public override void Start()
        {
            Son son = new Son();
            son.Name = "ASD";
            son.Age = 123;

            Father father = (Father)son;
            DisplayMessage(father.Name);
        }
    }

    class Father
    {
        public string Name { set; get; }
    }

    class Son : Father
    {
        public int Age { set; get; }
    }
}