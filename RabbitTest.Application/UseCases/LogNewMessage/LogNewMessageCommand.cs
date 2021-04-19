using MediatR;

namespace RabbitTest.Application.UseCases.LogNewMessage
{
    public class LogNewMessageCommand : IRequest<LogNewMessageResponse>
    {
        public string message;
    }
}
