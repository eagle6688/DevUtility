using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis
{
    public class LuaService : BaseAppService
    {
        string luaScripts = "";

        RedisHelper redisHelper;

        public LuaService(string host, int port, string password, string luaScripts)
        {
            redisHelper = new RedisHelper(host, port, password);
            this.luaScripts = luaScripts;
        }

        public override void Start()
        {
            DisplayMessage(redisHelper.ExecuteLua(
                "return redis.call('set', KEYS[1], ARGV[1]) and redis.call('set', KEYS[2], ARGV[2])", 
                new List<string>() { "asd", "qwe" },
                new List<string>() { "123", "456" }));
        }
    }
}