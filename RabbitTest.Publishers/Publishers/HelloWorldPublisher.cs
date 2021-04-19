using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitTest.Application.Infra;
using RabbitTest.Application.Messages;
using RabbitTest.Publishers.Interfaces;

namespace RabbitTest.Publishers.Publishers
{
    public class HelloWorldPublisher : IPublisher<HelloWorldMessage>
    {
        private readonly string QueueName = "HelloWorldPublished";
        private readonly ILogger<HelloWorldPublisher> _logger;
        private readonly IPublisherClient _client;

        public HelloWorldPublisher(ILogger<HelloWorldPublisher> logger, IPublisherClient client)
        {
            _logger = logger;
            _client = client;
        }

        public bool Publish(HelloWorldMessage message)
        {
            try
            {
                var stringfiedMessage = JsonConvert.SerializeObject(message);

                _client.Publish(stringfiedMessage, QueueName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro para processar : {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
