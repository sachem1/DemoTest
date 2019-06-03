using System;
using System.Collections.Generic;
using System.Threading;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Microsoft.Extensions.Logging;

namespace Memcached
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory loggerFacotry = new LoggerFactory();

            string cacheKey = "test";

            using (var mc = new MemcachedClient(loggerFacotry, new MemcachedClientConfiguration(loggerFacotry, new MemcachedClientOptions() { Servers = new List<Server>() { new Server() { Address = "59.110.216.148", Port = 11211 } } })))
            {
                for (int i = 0; i < 10; i++)
                {
                    mc.Store(StoreMode.Set, cacheKey + i, DateTime.Now);
                    Thread.Sleep(200);
                    var result = mc.Get(cacheKey + i);
                    Console.WriteLine($"获取到的缓存:{result}");
                }
                Console.ReadLine();
            }
        }
    }
}
