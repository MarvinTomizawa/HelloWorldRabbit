using System;

namespace RabbitTest.Publishers.Interfaces
{
    public interface IPublisherClient
    {
        void Publish(string message, string queue);
    }
}
