using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCommon
{
    public class StaticString
    {
        public const  string DefautlRedisConfigSection = "Redis";

        public const string DefaultRedisConfigDll = "Module.";

        public static string FormatKey(params string[] keys)
        {
            return string.Join("-", keys);
        }
    }
}
