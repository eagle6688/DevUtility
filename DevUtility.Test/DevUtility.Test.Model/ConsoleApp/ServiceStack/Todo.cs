using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.ConsoleApp.ServiceStack
{
    public class Todo
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public bool Done { get; set; }
    }
}