using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Distributed.Application.Business.Application.Consumers;
using Silverback.Messaging.Configuration;

namespace Poc.Distributed.Application.Infra.Bootstrap
{
    public static class KafkaService
    {
        public static IServiceCollection AddKafka(this IServiceCollection services)
        {
            services.AddSilverback()
                    .WithConnectionToMessageBroker(options => options.AddKafka())
                    .AddEndpointsConfigurator<EndpointConfigurator>()
                    .AddScopedSubscriber<MongoInsertConsumer>();

            services.AddHostedService<HostedService>();

            return services;
        }
        
        public static void Teste()
        {

        }
    }
}
