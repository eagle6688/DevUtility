using DevUtility.Test.Model.ESP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.RedisData.ESP
{
    public class RPublish_RestrictionDal : BaseRDal2<RPublish_Restriction>
    {
        public RPublish_RestrictionDal(string host, string password) : base(host, password)
        {
        }
    }
}