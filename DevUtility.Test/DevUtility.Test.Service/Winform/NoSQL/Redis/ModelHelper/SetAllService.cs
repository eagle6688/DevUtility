using DevUtility.Out.NoSQL.Redis;
using DevUtility.Out.NoSQL.Redis.ModelHelper;
using DevUtility.Test.Common.Winform;
using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.ModelHelper
{
    public class SetAllService : BaseAppService
    {
        #region Variables

        RedisJsonHelper<Student> redisJsonHelper;

        #endregion

        #region Constructor

        public SetAllService(string host, string password)
        {
            var dataConfig = RedisConfigHelper.DefaultRedisConfig;
            dataConfig.Host = host;
            dataConfig.Password = password;

            var indexConfig = RedisConfigHelper.DefaultIndexRedisConfig;
            indexConfig.Host = host;
            indexConfig.Password = password;

            redisJsonHelper = new RedisJsonHelper<Student>(dataConfig);
        }

        #endregion

        #region Start

        public override void Start()
        {
            var list = new List<Student>();
            list.Add(new Student()
            {
                ID = 1,
                Name = "Squirrel1"
            });

            list.Add(new Student()
            {
                ID = 2,
                Name = "Squirrel2"
            });

            redisJsonHelper.Save(list);
            DisplayMessage("SetAll OK!");
        }

        #endregion
    }
}