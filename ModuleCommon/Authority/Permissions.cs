using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCommon.Authority
{
    [Flags]
    public enum Permissions
    {
        Insert =1,
        Update=2,
        Query=4,
        Delete=8
    }


}
