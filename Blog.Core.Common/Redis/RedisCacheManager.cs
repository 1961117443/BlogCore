using Blog.Core.Common.Helper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Common.Redis
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly object redisConnectionLock = new object();

        private readonly string redisConnectionString;
        public volatile ConnectionMultiplexer redisConnection;

        public RedisCacheManager()
        {
            var RedisConnectionString = Appsettings.app("AppSettings", "RedisConfig", "ConnectionString");
            if (string.IsNullOrWhiteSpace(RedisConnectionString))
            {
                throw new ArgumentException("redis config is empty", nameof(RedisConnectionString));
            }
            this.redisConnectionString = RedisConnectionString;
            this.redisConnection = GetRedisConnection();
        }

        /// <summary>
        /// 核心代码，获取连接实例
        /// 通过双if 夹lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetRedisConnection()
        {
            //双if+lock，防止异步编程中，出现单例无效的问题
            if (this.redisConnection==null || !this.redisConnection.IsConnected)
            {
                lock (redisConnectionLock)
                {
                    if (this.redisConnection == null || !this.redisConnection.IsConnected)
                    {
                        if (this.redisConnection != null)
                        {
                            //释放redis链接
                            this.redisConnection.Dispose();
                        }
                        this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
                    } 
                }
            }
            return this.redisConnection;
        }

        public IDatabase Database
        {
            get
            {
                return GetRedisConnection().GetDatabase();
            }
        }
       

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public TEntity Get<TEntity>(string key)
        {
            var value = this.Database.StringGet(key);
            if (value.HasValue)
            {
                return SerializeHelper.Deserialize<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        public bool Get(string key)
        {
            return this.Database.KeyExists(key);
        }

        public void Remove(string key)
        {
            this.Database.KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value!=null)
            {
                this.Database.StringSet(key, SerializeHelper.Serialize(value), cacheTime);
            }
        }
    }
}
