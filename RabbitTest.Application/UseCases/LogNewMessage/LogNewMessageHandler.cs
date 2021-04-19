using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using RabbitTest.Application.Infra;
using RabbitTest.Application.Messages;

namespace RabbitTest.Application.UseCases.LogNewMessage
{
    public class LogNewMessageHandler : IRequestHandler<LogNewMessageCommand, LogNewMessageResponse>
    {
        private readonly ILogger<LogNewMessageHandler> _logger;
        private readonly IPublisher<HelloWorldMessage> _publisher;
        public LogNewMessageHandler(ILogger<LogNewMessageHandler> logger, IPublisher<HelloWorldMessage> publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task<LogNewMessageResponse> Handle(LogNewMessageCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                _logger.LogInformation(request.message);

                _publisher.Publish(new HelloWorldMessage{
                    Content = request.message
                });
                
                return new LogNewMessageResponse();
            }, cancellationToken);
        }
    }
}
