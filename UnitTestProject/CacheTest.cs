using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CacheAdapter;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class CacheTest
    {
        private readonly IConfiguration _configuration;
        public CacheTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(ApplicationEnvironment.ApplicationBasePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        [TestMethod]
        public void Redis_Test()
        {
            var factory = new CacheFactory(_configuration);
            string contextKey = "jiesen";
            var localCache = factory.GetLocalCache();
            localCache.Set(contextKey, "test", "123456");


            var redisCache = factory.GetRedisCache();
            redisCache.Set(contextKey, "test2", 456789);

            //var memcache = factory.GetMemcache();
            //memcache.Set(contextKey, "test3", 789123);
            Assert.IsNotNull(localCache.Get<object>(contextKey, "test"));
            Assert.IsNotNull(redisCache.Get<string>(contextKey, "test2"));
            Console.WriteLine($"localCache:{localCache.Get<object>(contextKey, "test")}");
            Console.WriteLine($"redisCache:{redisCache.Get<string>(contextKey, "test2")}");
            //Console.WriteLine($"memCache:{memcache.Get<string>(contextKey, "test3")}");


        }
    }

}
