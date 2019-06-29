using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCommon.Entity
{
    public class Customer:Entity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
    }
}
