using Silverback.Messaging.Configuration.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.Distributed.Application.Infra.Bootstrap
{
    public static class SqlInsertedInbound
    {
        public static IKafkaConsumerEndpointBuilder AddSqlInsertedInbound(this IKafkaConsumerEndpointBuilder endpoint)
        {
            return endpoint.ConsumeFrom(EndpointConfigurator.SqlInsertedEventName)
                           .Configure(config =>
                           {
                               config.GroupId = EndpointConfigurator.ConsumerGroupId;
                               config.AllowAutoCreateTopics = true;
                               //config.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                           })
                           .OnError(policy => policy.Retry(5));
        }
    }
}