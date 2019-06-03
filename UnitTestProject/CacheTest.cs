using System;
using System.Collections.Generic;
using System.Text;
using CacheAdapter;
using Microsoft.Extensions.Configuration;

namespace UnitTestProject
{
    public class CacheTest
    {
        private readonly IConfiguration _configuration;

        public CacheTest(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Redis_Test()
        {
            var factory = new CacheFactory(_configuration);
            string contextKey = "jiesen";
            var localCache = factory.GetLocalCache();
            localCache.Set(contextKey, "test", "123456");


            var redisCache = factory.GetRedisCache();
            redisCache.Set(contextKey, "test2", 456789);

            var memcache = factory.GetMemcache();
            memcache.Set(contextKey, "test3", 789123);

            Console.WriteLine($"localCache:{localCache.Get<string>(contextKey, "test")}");
            Console.WriteLine($"redisCache:{redisCache.Get<string>(contextKey, "test2")}");
            Console.WriteLine($"memCache:{memcache.Get<string>(contextKey, "test3")}");


        }
    }

}
