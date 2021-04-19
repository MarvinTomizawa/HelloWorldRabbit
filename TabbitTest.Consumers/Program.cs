using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TabbitTest.Consumers
{
    class Program
    {
        const string QueueName = "HelloWorld";
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var client = connection.CreateModel())
            {
                client.QueueDeclare(queue: QueueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(client);

                consumer.Received += (_, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                };

                client.BasicConsume(queue: QueueName,
                    autoAck: false,
                    consumer);
            }

            Console.WriteLine("Press enter to quit");
            Console.ReadLine();
        }
    }
}
