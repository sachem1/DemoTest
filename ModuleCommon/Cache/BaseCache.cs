using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCommon.Cache
{
    public abstract class BaseCache
    {
        protected string GeneralContextKey(string contextKey)
        {
            return contextKey;
        }
        protected int _timeout = 300;
    }
}
