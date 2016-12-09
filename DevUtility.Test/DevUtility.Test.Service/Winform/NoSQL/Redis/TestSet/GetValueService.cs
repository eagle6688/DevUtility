using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.TestSet
{
    public class GetValueService : BaseAppService
    {
        string key = "";

        RedisHelper redisHelper;

        public GetValueService(string host, int port, string password, string db, string key)
        {
            this.key = key;
            redisHelper = new RedisHelper(host, port, password, int.Parse(db));
        }

        public override void Start()
        {
            DisplayMessage(string.Join(",", redisHelper.SGet(key)));
        }
    }
}