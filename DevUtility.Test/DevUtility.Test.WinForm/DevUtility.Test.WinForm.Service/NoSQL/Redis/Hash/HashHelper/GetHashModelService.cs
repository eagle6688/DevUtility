using DevUtility.Com.Extension.SystemCollections;
using DevUtility.Out.NoSQL.Redis;
using DevUtility.Test.Model.Com;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.NoSQL.Redis.HashHelper
{
    public class GetHashModelService : BaseAppService
    {
        #region Variables

        string key = "";

        RedisHelper redisHelper;

        #endregion

        #region Constructor

        public GetHashModelService(string host, int port, string password, string key)
        {
            redisHelper = new RedisHelper(host, port, password);
            this.key = key;
        }

        #endregion

        #region Start

        public override void Start()
        {
            Dictionary<string, string> dictionary = redisHelper.HGet(key);
            var model = dictionary.ToModel<Subject>();
            DisplayMessage("Susscess!");
        }

        #endregion
    }
}