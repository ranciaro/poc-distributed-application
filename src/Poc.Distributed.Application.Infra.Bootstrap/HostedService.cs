using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Silverback.Messaging.Broker;
using Silverback.Messaging.Broker.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _adminClient = _confluentAdminClientBuilder.Build(new ClientConfig() { BootstrapServers = _configuration.GetConnectionString("Kafka") });
            IList<PartitionsSpecification> topicsToCreate = new List<PartitionsSpecification>() { new PartitionsSpecification { Topic = "sql-inserted-event", IncreaseTo = 1 } };
            //if(_configuration.GetValue<bool>("AllowedSwagger"))
            //await _adminClient.CreateTopicsAsync(new List<TopicSpecification>() { new TopicSpecification() { Name = "sql-inserted-event" } });
            //await _adminClient.CreatePartitionsAsync(topicsToCreate);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}