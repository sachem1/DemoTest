using System;
using System.Threading;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace MemcachedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string cacheKey = "test";
            using (var mc = new MemcachedClient())
            {
                for (int i = 0; i < 10; i++)
                {
                    mc.Store(StoreMode.Set, cacheKey+i, DateTime.Now);
                    Thread.Sleep(200);
                    var result = mc.Get(cacheKey + i);
                    Console.WriteLine($"获取到的缓存:{result}");
                }
                Console.ReadLine();
            }
        }
    }
}
