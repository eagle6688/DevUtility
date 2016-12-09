using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Com
{
    public class Teacher : BaseEntity
    {
        [PrimaryKey]
        public long ID { set; get; }

        [RedisIndex]
        public string Name { set; get; }

        public int Gender { set; get; }

        public int Age { set; get; }

        [RedisIndex]
        public int SubjectID { set; get; }
    }
}