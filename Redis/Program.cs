using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using ModuleCommon.Cache;
using StackExchange.Redis;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalCache_Test();


            //暂停
            Console.ReadLine();
        }

        public static void LocalCache_Test()
        {
            MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions() { ExpirationScanFrequency = TimeSpan.FromSeconds(100) });

            string key = "memoryKey";
            memoryCache.Set(key, DateTime.Now.ToString(CultureInfo.InvariantCulture));
            var cacheResult = memoryCache.Get(key);
            Console.WriteLine($"local cache: {cacheResult}");

        }


        public static void RedisCache_Test()
        {
            var configRoot = new ConfigurationBuilder().AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Redis:ServerList", "59.110.216.148:6380")
            }).Build();
            var redisSetting = configRoot.GetSection("Redis").Get<RedisSetting>();
            Console.WriteLine($"Redis Url:{redisSetting.ServerList}");
            redisSetting.ClientName = "RedisTest";
            redisSetting.SyncTimeout = 10000;
            redisSetting.DefaultDb = 0;

            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(Extentions.Convert(redisSetting));

            var database = connectionMultiplexer.GetDatabase();
            database.StringSet("test1", DateTime.Now.Ticks);
            Console.WriteLine($"test1-->:{database.StringGet("test1")}");


        }

    }
}
