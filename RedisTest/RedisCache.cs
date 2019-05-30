using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ModuleTestCommon.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisTest
{
    public class RedisCache : ICache
    {
        private readonly IDatabase _database;

        public RedisCache(IDatabase database)
        {
            _database = database;
        }
        [ExcludeFromCodeCoverage]
        public void Dispose()
        {

        }

        public T Get<T>(string contextKey, string dataKey, Func<T> action, int? expireationSeconds = null)
        {
            Func<T> redisAction = () =>
            {
                string key = GeneralContextKey(contextKey);
                if (_database.HashExists(key, dataKey))
                {
                    return ResolveJson<T>(_database.HashGet(key, dataKey));
                }

                var data = action();
                if (data == null)
                    throw new NullReferenceException("缓存数据不能为空!");

                _database.HashSet(key, dataKey, JsonConvert.SerializeObject(data));
                if (expireationSeconds.HasValue && expireationSeconds != 0)
                {
                    _database.KeyExpire(key, TimeSpan.FromSeconds(expireationSeconds.Value));
                }
                return data;
            };

            return redisAction();
        }

        public T Get<T>(string contextKey, string dataKey)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, T> Get<T>(string contextKey)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string contextKey, string dataKey, T value, int? expirationSeconds = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(string contextKey, string dataKey)
        {
            throw new NotImplementedException();
        }

        public void Remove(string contextKey)
        {
            throw new NotImplementedException();
        }

        private T ResolveJson<T>(RedisValue value)
        {
            if (!value.HasValue) return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        private string GeneralContextKey(string contextKey)
        {
            return contextKey;
        }
    }
}
