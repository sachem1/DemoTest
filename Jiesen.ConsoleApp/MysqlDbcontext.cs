using System.Data.SqlClient;
using Mondol.DapperPoco;
using Mondol.DapperPoco.Adapters;

namespace Jiesen.ConsoleApp
{
    public class MysqlDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseConnectionString("连接字符串");
            //使用SQL Server数据库
            optionsBuilder.UseSqlAdapter(new SqlServerAdapter(SqlClientFactory.Instance));
        }
    }
}