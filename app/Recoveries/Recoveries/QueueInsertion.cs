using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Framing;
using Recoveries.Core;
using Recoveries.Domain.Base;

namespace Recoveries
{
    public class QueueInsertion : IQueueInsertion
    {
        public void PublishMessagesToQueue(IEnumerable<RecoveryMessage> messages, IQueueOptions options)
        {
            using (var connection = RabbitConnection.FromOptions(options))
            using (var channel = connection.CreateModel())
            {
                foreach (var message in messages)
                {
                    var body = Encoding.UTF8.GetBytes(message.Body);

                    var properties = new BasicProperties();
                    message.Properties.CopyTo(properties);

                    channel.BasicPublish(message.Info.Exchange, message.Info.RoutingKey, properties, body);
                }
            }
        }
    }
}