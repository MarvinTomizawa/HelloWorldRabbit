namespace RabbitTest.Application.Infra
{
    public interface IPublisher<IMessage>
    {
        bool Publish(IMessage message);
    }
}
