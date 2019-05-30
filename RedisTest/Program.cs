using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using ModuleTestCommon.Cache;
using StackExchange.Redis;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();
            var configRoot = new ConfigurationBuilder().AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Redis:ServerList", "59.110.216.148:6380")
            }).Build();
            var redisSetting = configRoot.GetSection("Redis").Get<RedisSetting>();
            Console.WriteLine($"Redis Url:{redisSetting.ServerList}");
            redisSetting.ClientName = "RedisTest";
            redisSetting.SyncTimeout = 10000;
            redisSetting.DefaultDb = 0;

            ConnectionMultiplexer connectionMultiplexer=ConnectionMultiplexer.Connect(Extentions.Convert(redisSetting));

            var database = connectionMultiplexer.GetDatabase();
            database.StringSet("test1", DateTime.Now.Ticks);
            Console.WriteLine($"test1-->:{database.StringGet("test1")}");
            Console.ReadLine();
        }


    }
}
