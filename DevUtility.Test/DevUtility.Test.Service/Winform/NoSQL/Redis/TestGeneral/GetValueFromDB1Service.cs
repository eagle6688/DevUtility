using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis
{
    public class GetValueFromDB1Service : BaseAppService
    {
        string key = "";

        RedisHelper redisHelper;

        public GetValueFromDB1Service(string host, int port, string password, string key)
        {
            this.key = key;
            redisHelper = new RedisHelper(host, port, password, 1);
        }

        public override void Start()
        {
            DisplayMessage(string.Format("Value of Key {0} in DB1 is {1}.", key, redisHelper.GetValue(key)));
        }
    }
}