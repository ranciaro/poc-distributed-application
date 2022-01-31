using Poc.Distributed.Application.Business.Domain.Events;
using Silverback.Messaging.Configuration.Kafka;
using Silverback.Messaging.Messages;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Business.Application.Consumers
{
    public class MongoInsertConsumer
    {
        public async Task OnSqlInsertedEventAsync(IInboundEnvelope<SqlInsertedEvent> sqlInsertedEvent)
        {
            var message = sqlInsertedEvent.Message;
            // ...your message handling logic...
        }
    }
}
