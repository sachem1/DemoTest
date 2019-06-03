using System;
using Microsoft.Extensions.Configuration;
using ModuleCommon;
using ModuleCommon.Cache;
using Redis;

namespace CacheAdapter
{
    public class CacheFactory
    {
        private readonly IConfiguration _configuration;

        public CacheFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public ICache GetLocalCache()
        {
            return new LocalCache(new MemoryCacheSetting(){TimeOut = 300});
        }

        public ICache GetRedisCache(string sectionName = StaticString.DefautlRedisConfigSection)
        {
            var setting = GetSetting(sectionName);
            return new RedisCache(setting);
        }

        public ICache GetMemcache()
        {
            return null;
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public RedisSetting GetSetting(string sectionName = StaticString.DefautlRedisConfigSection)
        {
            try
            {
                string dllName = StaticString.DefaultRedisConfigDll;
                var section = _configuration.GetSection(sectionName);
                var result = section.Get<RedisSetting>();
                result.ClientName = StaticString.FormatKey(dllName, sectionName);

                return result;
            }
            catch (Exception)
            {
                throw new Exception("读取缓存配置错误");
            }
        }
    }
}
