using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Com
{
    public class Student : BaseEntity
    {
        [PropertyIndex(1)]
        [PrimaryKey]
        public long ID { set; get; }

        [PropertyIndex(0)]
        [RedisIndex]
        public string Name { set; get; }

        public int Gender { set; get; }

        [PropertyIndex(2)]
        public int Age { set; get; }

        public DateTime? Entry { set; get; }
    }
}