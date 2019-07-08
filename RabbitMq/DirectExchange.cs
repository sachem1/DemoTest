using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;

namespace RabbitMq
{
    public class DirectExchange
    {
        private readonly string _exchangeName = "rabbit_exchange_directTest";
        private string queueName = "queue_v1";
        private string routingKey = "direct";
        public void TestProduce()
        {
            var conn = new RabbitMqConnection().GetConnection();
            var channel = conn.CreateModel();

            channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueDeclare(queueName + 2, false, false, false, null);

            channel.QueueBind(queueName, _exchangeName, routingKey, null);
            channel.QueueBind(queueName + 2, _exchangeName, routingKey, null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("rabbitmq direct test");
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.ContentEncoding = "text/plain";

            channel.BasicPublish(_exchangeName, routingKey, properties, messageBodyBytes);

        }

        public void TestConsume()
        {
            //var tcs = new TaskCompletionSource<bool>();
            Console.WriteLine("start received");
            var conn = new RabbitMqConnection().GetConnection();
            var channel = conn.CreateModel();
            channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueDeclare(queueName + 2, false, false, false, null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (obj, eventsouce) =>
            {
                var message = Encoding.UTF8.GetString(eventsouce.Body);
                Console.WriteLine($"received {message}");
                // tcs.SetResult(true);
            };
            channel.BasicConsume(queueName, true, consumer);
            channel.BasicConsume(queueName + 2, true, consumer);
            //tcs.Task.Wait(2000);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {

        }
    }
}
