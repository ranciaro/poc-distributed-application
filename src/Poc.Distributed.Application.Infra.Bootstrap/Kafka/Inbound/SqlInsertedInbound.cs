using Poc.Distributed.Application.Infra.Bootstrap.Kafka.EndpointsConfigurator;
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
            return endpoint.ConsumeFrom(KafkaTopics.SqlInsertedEventName)
                           .Configure(config =>
                           {
                               config.GroupId = EndpointConfigurator.ConsumerGroupId;
                           })
                           .OnError(policy => policy.Retry(5));
        }
    }
}