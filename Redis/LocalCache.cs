using Microsoft.Extensions.Caching.Memory;
using ModuleCommon.Cache;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Redis
{
    public class LocalCache : BaseCache, ICache
    {
        private MemoryCache memoryCache;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exist(string contextKey, string dataKey)
        {
            return memoryCache.Get(GeneralContextKey(contextKey)) is ConcurrentDictionary<string, object> hset && hset.ContainsKey(dataKey);
        }

        public T Get<T>(string contextKey, string dataKey, Func<T> action, int? expireationSeconds = null)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string contextKey, string dataKey)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, T> Get<T>(string contextKey)
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

        public void Set<T>(string contextKey, string dataKey, T value, int? expirationSeconds = null)
        {
            ValidateKey(contextKey, dataKey);
            int seconds = expirationSeconds ?? _timeout;

            if (Exist(contextKey, dataKey))
            {
                var cache = memoryCache.Get<ConcurrentDictionary<string, object>>(GeneralContextKey(contextKey));
                cache.AddOrUpdate(dataKey, value, (k, v) => v);
                memoryCache.Set(contextKey, cache, DateTime.Now.AddSeconds(seconds));
            }
            else
            {
                ConcurrentDictionary<string, object> hset = new ConcurrentDictionary<string, object>(new Dictionary<string, object>() { { dataKey, value } });
                memoryCache.Set(contextKey, hset, DateTime.Now.AddSeconds(seconds));
            }
        }

        private void ValidateKey(string contextKey, string dataKey)
        {
            var key = GeneralContextKey(contextKey);
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(dataKey)) throw new ArgumentNullException("缓存Key不能为空！");
        }
    }
}
