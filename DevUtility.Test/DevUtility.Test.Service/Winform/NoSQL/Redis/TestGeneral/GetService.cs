using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis
{
    public class GetService : BaseAppService
    {
        string key = "";

        RedisHelper redisHelper;

        public GetService(string host, int port, string password, string key)
        {
            this.key = key;
            redisHelper = new RedisHelper(host, port, password, 0);
        }

        public override void Start()
        {
            DisplayMessage(string.Format("Value of Key {0} is {1}.", key, redisHelper.GetValue(key)));
        }
    }
}