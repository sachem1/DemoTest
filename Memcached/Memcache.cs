using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using ModuleCommon.Cache;

namespace Memcached
{
    public class Memcache : BaseCache, ICache
    {
        private readonly IMemcachedClient _client;

        public Memcache(MemcachedSetting setting, IMemcachedClient client)
        {
            _client = new MemcachedClient(null, new MemcachedClientConfiguration(null, new MemcachedClientOptions() { Protocol = MemcachedProtocol.Binary, Servers = new List<Server>() }));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exist(string contextKey, string dataKey)
        {
            var key = GeneralContextKey(contextKey + dataKey);

            var result = _client.Get(key);
            if (result == null) return false;
            return true;
        }

        public T Get<T>(string contextKey, string dataKey, Func<T> action, int? expireationSeconds = null)
        {
            ValidateKey(contextKey, dataKey);

            var cache = _client.Get<ConcurrentDictionary<string, T>>(GeneralContextKey(contextKey));

            if (cache == null)
            {
                var result = action();

                Set(contextKey, dataKey, result, expireationSeconds);

                return result;
            }

            if (cache.ContainsKey(dataKey))
            {
                cache.TryGetValue(dataKey, out T val);
                return val;
            }
            return default(T);
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
            throw new NotImplementedException();
        }

        private void ValidateKey(string contextKey, string dataKey)
        {
            if (string.IsNullOrEmpty(contextKey)) throw new ArgumentNullException($"缓存{nameof(contextKey)}不能为空!");
            if (string.IsNullOrEmpty(dataKey)) throw new ArgumentNullException($"缓存{nameof(dataKey)}不能为空!");
        }

        private MemcachedClientConfiguration Convert(MemcachedSetting setting)
        {
            var config = new MemcachedClientConfiguration(null, new MemcachedClientOptions());

            var serverList = setting.ServerList.Split(',');
            foreach (var item in serverList)
            {
                var addr = item.Split(':');
                var port = System.Convert.ToInt32(addr[1]);
                var ipAddress = IPAddress.Parse(addr[0]);
                config.Servers.Add(new IPEndPoint(ipAddress, port));
            }
            return config;
        }
    }
}