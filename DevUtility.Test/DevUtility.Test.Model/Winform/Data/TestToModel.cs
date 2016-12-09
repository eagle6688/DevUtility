using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Winform.Data
{
    public class TestToModel
    {
        [PrimaryKey]
        public int ID { set; get; }

        [PrimaryKey]
        public long LongID { set; get; }

        public string Name { set; get; }

        public int Age { set; get; }
    }
}