using DevUtility.Out.NoSQL.Redis;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.NoSQL.Redis.RedisHelperTest
{
    public class IsConnectedService : BaseAppService
    {
        #region Variables

        RedisHelper redisHelper;

        #endregion

        #region Constructor

        public IsConnectedService(string host, string password)
        {
            redisHelper = new RedisHelper(host, 6379, password);
        }

        #endregion

        #region Start

        public override void Start()
        {
            DisplayMessage(string.Format("Connecting {0}!", redisHelper.IsConnected() ? "success" : "failed"));
        }

        #endregion
    }
}