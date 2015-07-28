using System.Collections.Generic;
using Common.Logging;
using RabbitMQ.Client.Exceptions;

namespace Recoveries
{
    public interface IPurgeQueue
    {
        IEnumerable<uint> PurgeQueue(IQueueOptions options);
    }

    public class PurgeErrorQueue : IPurgeQueue
    {
        private readonly ILog _log = LogManager.GetLogger<PurgeErrorQueue>();
        public IEnumerable<uint> PurgeQueue(IQueueOptions options)
        {
            
            using (var connection = HosepipeConnection.FromParamters(options))
            using (var channel = connection.CreateModel())
            {
                uint count = 0;
                try
                {
                    var messages = channel.BasicGet(options.ErrorQueueName, true);
                    if (messages == null) yield break;
                    channel.QueueBind(options.ErrorQueueName, messages.Exchange,messages.RoutingKey);
                    count = messages.MessageCount;
                    channel.QueuePurge(options.ErrorQueueName);
                }
                catch (OperationInterruptedException exception)
                {
                    _log.ErrorFormat("Error Occurred Getting a message from queue because {0}", exception, exception.Message);
                    yield break;
                }
                
                yield return count;
            }
        }
    }
}