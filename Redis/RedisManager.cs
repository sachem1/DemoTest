using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using ModuleCommon.Cache;
using StackExchange.Redis;

namespace Redis
{
    public class RedisManager
    {
        public static ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionMultiplexers=new ConcurrentDictionary<string, ConnectionMultiplexer>();

        public static ConcurrentDictionary<string, RedisSetting> RedisSettings =new ConcurrentDictionary<string, RedisSetting>();


        public static IDatabase GetRedisDatabase(RedisSetting setting)
        {
            //这里需要提取,单一性
            var config = RedisSettings.GetOrAdd(setting.ClientName,x=> setting);
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(AnalysisRedisSection(config));
            return connectionMultiplexer.GetDatabase();
        }

        public static ConfigurationOptions AnalysisRedisSection(RedisSetting redisSetting)
        {
            string[] writeServerList = redisSetting.ServerList.Split(',');
            var sdkOptions = new ConfigurationOptions
            {
                ClientName = redisSetting.ClientName,
                KeepAlive = 5 * 60,
                DefaultVersion = new Version(redisSetting.Version),
                AbortOnConnectFail = false,
                DefaultDatabase = redisSetting.DefaultDb,
                ConnectRetry = 10,
                Password = redisSetting.Password,
                SyncTimeout = redisSetting.SyncTimeout * 1000
            };
            foreach (var s in writeServerList)
            {
                sdkOptions.EndPoints.Add(s);
            };
            return sdkOptions;
        }
    }
}
