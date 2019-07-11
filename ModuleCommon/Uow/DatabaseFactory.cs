using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ModuleCommon.Uow
{
    public class DatabaseFactory
    {
        public string connString = "";

        public IDbConnection GetConnection(string connstring)
        {
            return null;
        }
    }
}
