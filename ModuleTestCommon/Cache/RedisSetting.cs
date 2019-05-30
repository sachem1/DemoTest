using System;
using StackExchange.Redis;

namespace ModuleTestCommon.Cache
{
    public class RedisSetting
    {
        public string ServerList { get; set; }

        public string ClientName { get; set; }

        public string Version { get; set; } = "3.2.100";

        public int DefaultDb { get; set; }

        public string Password { get; set; } = "123456";

        public int SyncTimeout { get; set; }
    }
}
