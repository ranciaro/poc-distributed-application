using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Poc.Distributed.Application.Infra.Bootstrap.Kafka.EndpointsConfigurator;
using Silverback.Messaging.Broker;
using Silverback.Messaging.Broker.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Infra.Bootstrap
{
    public class HostedService : IHostedService
    {
        private IConfiguration _configuration;
        private IAdminClient _adminClient;
        private readonly IBrokerCollection _brokers;
        private readonly IConfluentAdminClientBuilder _confluentAdminClientBuilder;

        public HostedService(IConfiguration configuration,
                             IBrokerCollection brokers,
                             IConfluentAdminClientBuilder confluentAdminClientBuilder)
        {
            _configuration = configuration;
            _brokers = brokers;
            _confluentAdminClientBuilder = confluentAdminClientBuilder;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_configuration.GetValue<bool>("AutoCreateTopics"))
                CreateKafkaTopics();

            return Task.CompletedTask;
        }

        private void CreateKafkaTopics()
        {
            _adminClient = _confluentAdminClientBuilder.Build(new ClientConfig() { BootstrapServers = _configuration.GetConnectionString("Kafka") });
            var topicsToCreate = typeof(KafkaTopics).GetAllPublicConstantValues<string>().Select(x => new TopicSpecification() { Name = x }).ToList();
            foreach (var topic in topicsToCreate)
                _adminClient.GetMetadata(topic.Name, TimeSpan.FromSeconds(30));
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}