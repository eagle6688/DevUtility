using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.Com
{
    [RedisIndex]
    public class StudentScore : BaseEntity
    {
        [PrimaryKey]
        public long StudentID { set; get; }

        [PrimaryKey]
        public int SubjectID { set; get; }

        [PrimaryKey]
        public string Type { set; get; }

        public double Score { set; get; }
    }
}