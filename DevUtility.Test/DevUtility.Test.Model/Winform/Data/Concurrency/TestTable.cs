using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Winform.Data.Concurrency
{
    public class TestTable
    {
        public long ID { set; get; }

        public string Name { set; get; }

        public int IsDeleted { set; get; }
    }
}