using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Com
{
    public class Subject : BaseEntity
    {
        [PrimaryKey]
        public int ID { set; get; }

        [RedisIndex]
        public string Name { set; get; }
    }
}