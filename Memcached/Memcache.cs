using Enyim.Caching;
using ModuleCommon.Cache;
using System;
using System.Collections.Generic;

namespace MemcachedTest
{
    public class Memcache : BaseCache, ICache
    {
        private readonly MemcachedClient _client;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Exist(string contextKey, string dataKey)
        {            
            //if (_client.KeyExists(GeneralContextKey(contextKey) + dataKey){
                
            //}
            return false;
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
            throw new NotImplementedException();
        }
    }
}