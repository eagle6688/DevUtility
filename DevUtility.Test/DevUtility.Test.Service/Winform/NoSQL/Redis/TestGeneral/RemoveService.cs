using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis
{
    public class RemoveService : BaseAppService
    {
        string key = "";

        RedisHelper redisHelper;

        public RemoveService(string host, int port, string password, string key)
        {
            redisHelper = new RedisHelper(host, port, password);
            this.key = key;
        }

        public override void Start()
        {
            string message = string.Format(redisHelper.Remove(key) ? "Success!" : "Failed");
            DisplayMessage(message);
        }
    }
}