using Common.Logging;
using Recoveries.ErrorQueues.Messages;

namespace Recoveries.Router.Consumers
{
    public class RetryErrorsOnAllQueuesConsumer : AbstractConsumer<RetryErrorsOnAllQueuesMessage>
    {
        private static readonly ILog Log = LogManager.GetLogger<RetryErrorsOnAllQueuesConsumer>();

        public override void Consume(RetryErrorsOnAllQueuesMessage message)
        {
            Log.InfoFormat("Attempting to Retry Errors on All Queues");
        }
    }

    public class RetryErrorsOnAQueuesConsumer : AbstractConsumer<RetryErrorsOnQueueMessage>
    {
        private static readonly ILog Log = LogManager.GetLogger<RetryErrorsOnAQueuesConsumer>();

        public override void Consume(RetryErrorsOnQueueMessage message)
        {
            Log.InfoFormat("Attempting to Retry Errors on A Specific Queues");
        }
    }
}