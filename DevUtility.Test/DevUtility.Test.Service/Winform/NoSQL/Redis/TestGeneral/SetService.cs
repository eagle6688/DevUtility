using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis
{
    public class SetService : BaseAppService
    {
        string key = "", value = "";

        RedisHelper redisHelper;

        public SetService(string host, int port, string password, string key, string value)
        {
            redisHelper = new RedisHelper(host, port, password);
            this.key = key;
            this.value = value;
        }

        public override void Start()
        {
            string message = string.Format(redisHelper.Set(key, value) ? "Success!" : "Failed");
            DisplayMessage(message);
        }
    }
}