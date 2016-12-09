using DevUtility.Out.NoSQL.Redis;
using DevUtility.Out.NoSQL.Redis.ModelHelper;
using DevUtility.Test.Model.Com;
using DevUtility.Test.Model.Winform.Data;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.TestRedisRelationDataHelper
{
    public class GetModelKeyService : BaseAppService
    {
        RedisConfig redisConfig;

        public GetModelKeyService(string host, int port, string password)
        {
            redisConfig = new RedisConfig()
            {
                Host = host,
                Port = port,
                Password = password
            };

        }

        public override void Start()
        {
            TestToModel model = new TestToModel
            {
                ID = 1001,
                LongID = 100001,
                Name = "Eagle",
                Age = 22
            };

            DisplayMessage(string.Format("TestToModel' key is {0}", ""));

            StudentScore studentScore = new StudentScore()
            {
                StudentID = 1
            };

            DisplayMessage(string.Format("StudentScore' key is {0}", ""));
        }
    }
}