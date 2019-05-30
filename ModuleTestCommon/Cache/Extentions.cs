using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace ModuleTestCommon.Cache
{
    public static class Extentions
    {
        public static ConfigurationOptions Convert(RedisSetting setting)
        {
            string[] writeServerList = setting.ServerList.Split(',');
            var sdkOptions = new ConfigurationOptions
            {
                ClientName = setting.ClientName,
                KeepAlive = 5 * 60,
                DefaultVersion = new Version(setting.Version),
                AbortOnConnectFail = false,
                DefaultDatabase = setting.DefaultDb,
                ConnectRetry = 10,
                Password = setting.Password,
                SyncTimeout = setting.SyncTimeout * 1000
            };
            foreach (var s in writeServerList)
            {
                sdkOptions.EndPoints.Add(s);
            };
            return sdkOptions;
        }
    }
}
