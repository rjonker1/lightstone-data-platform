using System.Linq;
using Common.Logging;
using EasyNetQ;
using Recoveries.ErrorQueues;
using Recoveries.ErrorQueues.Messages;

namespace Recoveries.Router.Consumers
{
    public class RetryErrorsOnAllQueuesConsumer : AbstractConsumer<IMessage<RetryErrorsOnAllQueuesMessage>>
    {
        private static readonly ILog Log = LogManager.GetLogger<RetryErrorsOnAllQueuesConsumer>();

        public override void Consume(IMessage<RetryErrorsOnAllQueuesMessage> message)
        {
            Log.InfoFormat("Attempting to Recover errors for {0} Configurations", ConfigurationReader.Configurations.Count());
            ErrorMessageRecoveryHandler.Create().HandleAll(ConfigurationReader.Configurations);
            Log.InfoFormat("Handled Recovery messages on queues. Number of Configurations handled {0}", ConfigurationReader.Configurations.Count());
        }
    }

    public class RetryErrorsOnAQueuesConsumer : AbstractConsumer<IMessage<RetryErrorsOnAQueueMessage>>
    {
        private static readonly ILog Log = LogManager.GetLogger<RetryErrorsOnAQueuesConsumer>();

        public override void Consume(IMessage<RetryErrorsOnAQueueMessage> message)
        {
            Log.InfoFormat("Attempting to Retry Errors on queue {0}", message.Body.Configuration.Options.ErrorQueueName);
            ErrorMessageRecoveryHandler.Create().Handle(message.Body.Configuration.Options);
            Log.InfoFormat("Handled Recovery messages on queue {0}", message.Body.Configuration.Options.ErrorQueueName);
        }
    }
}