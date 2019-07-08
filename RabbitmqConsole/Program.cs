using System;
using System.Threading;
using RabbitMq;

namespace RabbitmqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var directExchange = new DirectExchange();
            //directExchange.TestConsume();

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    directExchange.TestProduce();
                }
                Console.WriteLine("发送完毕!");
                Thread.Sleep(2000);
            }

          

        }
    }
}
