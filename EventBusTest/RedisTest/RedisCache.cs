using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ModuleTestCommon.Cache;
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
    }
}
