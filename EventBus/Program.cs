using System;
using Autofac;
using EventBus.Db;
using EventBus.Entitys;
using EventBus.Event;
using EventBus.Publish;

namespace EventBus
{
    class Program
    {
        public static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var builder = new ContainerBuilder();

            builder.RegisterType<EntityHandlerEvent>().As<IConsumer<EntityAddEvent<Order>>>();
            builder.RegisterType<EntityHandlerEvent>().As<IConsumer<EntityUpdateEvent<Order>>>();
            Container= builder.Build();

            var order = new Order() { Id = 1 };
            DbContext db = new DbContext();
            db.InsertData(order);

            db.UpdateData(order);

            Console.ReadLine();
        }
    }
}
