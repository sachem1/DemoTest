using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ModuleCommon.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Redis
{
    public class RedisCache : BaseCache, ICache
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
            T RedisAction()
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
            }

            return RedisAction();
        }

        public T Get<T>(string contextKey, string dataKey)
        {
            if (string.IsNullOrEmpty(contextKey) || string.IsNullOrEmpty(dataKey))
                return default(T);

            var result = _database.HashGet(GeneralContextKey(contextKey), dataKey);
            return ResolveJson<T>(result);
        }

        public IDictionary<string, T> Get<T>(string contextKey)
        {
            if (string.IsNullOrEmpty(contextKey))
                return default(IDictionary<string, T>);

            var result = _database.HashGetAll(GeneralContextKey(contextKey)).ToDictionary(item => (string)item.Name, item => ResolveJson<T>(item.Value));
            return result;
        }

        public void Set<T>(string contextKey, string dataKey, T value, int? expirationSeconds = null)
        {
            if (string.IsNullOrEmpty(contextKey) || string.IsNullOrEmpty(dataKey))
                return;

            _database.HashSet(GeneralContextKey(contextKey), dataKey, JsonConvert.SerializeObject(value));
            if (expirationSeconds.HasValue)
                _database.KeyExpire(contextKey, TimeSpan.FromSeconds(expirationSeconds.Value));
        }

        public void Remove(string contextKey, string dataKey)
        {
            if (string.IsNullOrEmpty(contextKey) || string.IsNullOrEmpty(dataKey))
                return;

            _database.HashDelete(GeneralContextKey(contextKey), dataKey);
        }

        public void Remove(string contextKey)
        {
            if (string.IsNullOrEmpty(contextKey))
                return;

            _database.HashDelete(GeneralContextKey(contextKey),RedisValue.Null);
        }

        public bool Exist(string contextKey, string dataKey)
        {
            if (string.IsNullOrEmpty(contextKey) || string.IsNullOrEmpty(dataKey))
                return false;

            var key = GeneralContextKey(contextKey);
            if (!_database.HashExists(key, dataKey))
                return false;

            return true;
        }

        private T ResolveJson<T>(RedisValue value)
        {
            if (!value.HasValue) return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }
        
    }
}
