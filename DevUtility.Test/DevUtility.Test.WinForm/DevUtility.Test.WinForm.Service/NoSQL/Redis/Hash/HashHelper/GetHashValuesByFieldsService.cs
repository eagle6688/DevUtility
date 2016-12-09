using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.NoSQL.Redis.Hash.HashHelper
{
    public class GetHashValuesByFieldsService : BaseAppService
    {
        #region Variables

        string value = "";

        RedisHelper redisHelper;

        #endregion

        #region Constructor

        public GetHashValuesByFieldsService(string host, int port, string password, string value)
        {
            redisHelper = new RedisHelper(host, port, password);
            this.value = value;
        }

        #endregion

        #region Start

        public override void Start()
        {
            var fields = value.Split(',').ToList();
            var list = redisHelper.HGetValues("$d_Student:101", fields);
            DisplayMessage(string.Join(",", list));
        }

        #endregion
    }
}