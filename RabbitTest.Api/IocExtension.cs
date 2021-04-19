using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitTest.Application.Infra;
using RabbitTest.Application.Messages;
using RabbitTest.Application.UseCases.LogNewMessage;
using RabbitTest.Publishers;
using RabbitTest.Publishers.Interfaces;
using RabbitTest.Publishers.Publishers;

namespace RabbitTest.Api
{
    public static class IocExtension
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services )
            => services
                .AddMediatR(typeof(Startup))
                .AddScoped<IRequestHandler<LogNewMessageCommand, LogNewMessageResponse>, LogNewMessageHandler>();

        public static IServiceCollection AddMessagingClient(this IServiceCollection services)
            => services.AddSingleton<IPublisherClient, RabbitClient>();

        public static IServiceCollection AddPublishers(this IServiceCollection services)
            => services.AddSingleton<IPublisher<HelloWorldMessage>, HelloWorldPublisher>();
    }
}
