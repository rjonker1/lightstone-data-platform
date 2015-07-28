using System.Collections.Generic;
namespace Recoveries
{
    public interface IPurgeQueue
    {
        IEnumerable<uint> PurgeQueue(IQueueOptions options);
    }

    public class PurgeErrorQueue : IPurgeQueue
    {
        public IEnumerable<uint> PurgeQueue(IQueueOptions options)
        {
            using (var connection = HosepipeConnection.FromParamters(options))
            using (var channel = connection.CreateModel())
            {

                var messages = channel.BasicGet(options.ErrorQueueName, options.RequireHandshake);
                channel.QueuePurge(options.ErrorQueueName);
                yield return messages.MessageCount;
            }
        }
    }
}