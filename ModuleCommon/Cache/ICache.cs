using System;
using System.Collections.Generic;

namespace ModuleCommon.Cache
{
    public interface ICache : IDisposable
    {
        T Get<T>(string contextKey, string dataKey, Func<T> action, int? expireationSeconds = null);

        T Get<T>(string contextKey, string dataKey);

        IDictionary<string, T> Get<T>(string contextKey);

        void Set<T>(string contextKey, string dataKey, T value, int? expirationSeconds = null);

        void Remove(string contextKey, string dataKey);

        void Remove(string contextKey);

        bool Exist(string contextKey, string dataKey);
    }
}
