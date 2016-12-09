using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Com
{
    public class BaseEntity
    {
        public int IsDeleted { set; get; }

        public DateTime CreateTime { set; get; }

        public BaseEntity()
        {
            CreateTime = DateTime.Now;
        }
    }
}