using Microsoft.Extensions.Configuration;
using Poc.Distributed.Application.Business.Domain.Events;
using Poc.Distributed.Application.Infra.Bootstrap.Kafka.EndpointsConfigurator;
using Silverback.Messaging.Configuration;

namespace Poc.Distributed.Application.Infra.Bootstrap
{
    public class EndpointConfigurator : IEndpointsConfigurator
    {
        
        internal const string ConsumerGroupId = "poc-distributed-application";
        private readonly IConfiguration _configuration;
        public EndpointConfigurator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IEndpointsConfigurationBuilder builder)
        {
            builder.AddKafkaEndpoints(endpoints => endpoints
                    .Configure(config =>
                    {
                        config.BootstrapServers = _configuration.GetConnectionString("Kafka");
                    })
                    .AddInbound(endpoint => endpoint.AddSqlInsertedInbound())
                    .AddOutbound<SqlInsertedEvent>(x => x.ProduceTo(KafkaTopics.SqlInsertedEventName)));
        }
    }
}
