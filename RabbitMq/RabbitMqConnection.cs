using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMq
{
    public class RabbitMqConnection
    {
        public IConnection GetConnection()
        {
            var factory = new ConnectionFactory();
            factory.UserName = "admin";
            factory.Password = "admin123";
            factory.HostName = "59.110.216.148";

            IConnection conn = factory.CreateConnection();
            return conn;
        }
    }
}
