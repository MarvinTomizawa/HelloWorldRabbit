using System.Text;
using RabbitMQ.Client;
using RabbitTest.Publishers.Interfaces;

namespace RabbitTest.Publishers
{
    public class RabbitClient : IPublisherClient
    {
        public void Publish(string message, string queue)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel()){
                channel.QueueDeclare(queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body);
            }
        }
    }
}
