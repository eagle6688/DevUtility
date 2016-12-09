using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public class RedisConfig
    {
        #region Variables

        public const string ConnectionStringFormat = "{0}@{1}:{2}";

        #endregion

        #region Properties

        /// <summary>
        /// Host name or IP address
        /// </summary>
        public string Host { set; get; }

        /// <summary>
        /// Redis port
        /// </summary>
        public int Port { set; get; }

        /// <summary>
        /// If this is an SSL connection
        /// </summary>
        public bool Ssl { set; get; }

        /// <summary>
        /// The Redis DB this connection should be set to
        /// </summary>
        public long Db { set; get; }

        /// <summary>
        /// A text alias to specify for this connection for analytic purposes
        /// </summary>
        public string Client { set; get; }

        /// <summary>
        /// UrlEncoded version of the Password for this connection
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// Timeout in ms for making a TCP Socket connection
        /// </summary>
        public int ConnectTimeout { set; get; }

        /// <summary>
        /// Timeout in ms for making a synchronous TCP Socket Send
        /// </summary>
        public int SendTimeout { set; get; }

        /// <summary>
        /// Timeout in ms for waiting for a synchronous TCP Socket Receive
        /// </summary>
        public int ReceiveTimeout { set; get; }

        /// <summary>
        /// Timeout in Seconds for an Idle connection to be considered active
        /// </summary>
        public int IdleTimeOutSecs { set; get; }

        /// <summary>
        /// Use a custom prefix for ServiceStack.Redis internal index colletions
        /// </summary>
        public string NamespacePrefix { set; get; }

        /// <summary>
        /// Prefix of key name.
        /// </summary>
        public string KeyNamePrefix { set; get; }

        public string ConnectionString
        {
            get
            {
                return string.Format(ConnectionStringFormat, Password, Host, Port);
            }
        }

        #endregion

        #region Constructor

        public RedisConfig()
            : this("127.0.0.1", 6379, "", 0)
        {
        }

        public RedisConfig(string host, int port, string password, int db)
        {
            Host = host;
            Port = port;
            Password = password;
            Db = db;
            ConnectTimeout = 3000;
        }

        #endregion

        #region Set PooledRedisClientManager

        public void SetPooledRedisClientManager(ref PooledRedisClientManager pooledRedisClientManager)
        {
            pooledRedisClientManager.PoolTimeout = 10000;

            if (ConnectTimeout > 0)
            {
                pooledRedisClientManager.ConnectTimeout = ConnectTimeout;
            }

            if (SendTimeout > 0)
            {
                pooledRedisClientManager.SocketSendTimeout = SendTimeout;
            }

            if (ReceiveTimeout > 0)
            {
                pooledRedisClientManager.SocketReceiveTimeout = ReceiveTimeout;
            }

            if (IdleTimeOutSecs > 0)
            {
                pooledRedisClientManager.IdleTimeOutSecs = IdleTimeOutSecs;
            }

            if (!string.IsNullOrEmpty(NamespacePrefix))
            {
                pooledRedisClientManager.NamespacePrefix = NamespacePrefix;
            }
        }

        #endregion
    }
}