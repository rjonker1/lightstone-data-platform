using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Framing;

namespace Recoveries
{
    public interface IQueueInsertion
    {
        void PublishMessagesToQueue(IEnumerable<HosepipeMessage> messages, IQueueOptions options);
    }

    public class QueueInsertion : IQueueInsertion
    {
        public void PublishMessagesToQueue(IEnumerable<HosepipeMessage> messages, IQueueOptions options)
        {
            using (var connection = HosepipeConnection.FromParamters(options))
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