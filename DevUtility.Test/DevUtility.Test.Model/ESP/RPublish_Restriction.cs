using DevUtility.Com.Application.ComAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.ESP
{
    public class RPublish_Restriction
    {
        [PrimaryKey]
        public long FixIID { set; get; }

        [RedisIndex]
        public string RestrictionType { set; get; }
    }
}