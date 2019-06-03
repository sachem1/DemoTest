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
        private readonly MemoryCache _memoryCache;

        public LocalCache(MemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exist(string contextKey, string dataKey)
        {
            return _memoryCache.Get(GeneralContextKey(contextKey)) is ConcurrentDictionary<string, object> hset && hset.ContainsKey(dataKey);
        }

        public T Get<T>(string contextKey, string dataKey, Func<T> action, int? expireationSeconds = null)
        {
            ValidateKey(contextKey, dataKey);

            string key = GeneralContextKey(contextKey) + dataKey;
            var result = _memoryCache.Get<T>(key);
            if (result != null) return result;

            var second = expireationSeconds ?? _timeout;
            result = action();
            Set(contextKey, dataKey, result, second);
            return result;
        }

        public T Get<T>(string contextKey, string dataKey)
        {
            ValidateKey(contextKey, dataKey);

            var hset = _memoryCache.Get<ConcurrentDictionary<string, T>>(GeneralContextKey(contextKey));

            if (!hset.ContainsKey(dataKey)) return default(T);
            hset.TryGetValue(dataKey, out T val);
            return val;
        }

        public IDictionary<string, T> Get<T>(string contextKey)
        {
            if (string.IsNullOrEmpty(contextKey)) throw new ArgumentNullException();

            return _memoryCache.Get<ConcurrentDictionary<string, T>>(GeneralContextKey(contextKey));
        }

        public void Remove(string contextKey, string dataKey)
        {
            ValidateKey(contextKey, dataKey);

            var cache = _memoryCache.Get<ConcurrentDictionary<string, object>>(GeneralContextKey(contextKey));
            if (cache.ContainsKey(dataKey))
            {
                cache.Remove(dataKey, out object _);
                Set(contextKey, dataKey, cache);
            }
        }

        public void Remove(string contextKey)
        {
            if (string.IsNullOrEmpty(contextKey)) throw new ArgumentNullException();

            _memoryCache.Remove(GeneralContextKey(contextKey));
        }

        public void Set<T>(string contextKey, string dataKey, T value, int? expirationSeconds = null)
        {
            ValidateKey(contextKey, dataKey);
            int seconds = expirationSeconds ?? _timeout;

            if (Exist(contextKey, dataKey))
            {
                var cache = _memoryCache.Get<ConcurrentDictionary<string, object>>(GeneralContextKey(contextKey));
                cache.AddOrUpdate(dataKey, value, (k, v) => v);
                _memoryCache.Set(contextKey, cache, DateTime.Now.AddSeconds(seconds));
            }
            else
            {
                ConcurrentDictionary<string, object> hset = new ConcurrentDictionary<string, object>();
                hset.TryAdd(dataKey, value);
                _memoryCache.Set(contextKey, hset, DateTime.Now.AddSeconds(seconds));
            }
        }

        private void ValidateKey(string contextKey, string dataKey)
        {
            var key = GeneralContextKey(contextKey);
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"缓存{nameof(contextKey)}不能为空！");
            if (string.IsNullOrEmpty(dataKey)) throw new ArgumentNullException($"缓存{nameof(dataKey)}不能为空！");
        }
    }
}
