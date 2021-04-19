using RabbitTest.Application.Infra;

namespace RabbitTest.Application.Messages
{
    public class HelloWorldMessage : IMessage
    {
        public string Content { get; set; }
    }
}
