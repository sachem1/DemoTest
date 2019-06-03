using System;
using System.Collections.Generic;
using System.Text;
using Enyim.Caching.Memcached;

namespace ModuleCommon.Cache
{
    public class MemcachedSetting
    {
        public int TimeOut { get; set; }

        public MemcachedProtocol Protocol { get; set; }

        public string ServerList { get; set; }
    }
}
