using System.Linq;
using Common.Logging;
using Recoveries.Core.Messages;
using Recoveries.Domain.Base;
using Recoveries.Infrastructure.Configuration;

namespace Recoveries.Domain.Consumers
{
    public class RetryErrorsOnAllQueuesConsumer : AbstractConsumer<RetryErrorsOnAllQueuesMessage>
    {
        private static readonly ILog Log = LogManager.GetLogger<RetryErrorsOnAllQueuesConsumer>();
        private readonly IHandleErrorMessageRecovery _handleError;

        public RetryErrorsOnAllQueuesConsumer(IHandleErrorMessageRecovery handleError)
        {
            _handleError = handleError;
        }

        public override void Consume(RetryErrorsOnAllQueuesMessage message)
        {
            Log.InfoFormat("Attempting to Recover errors for {0} Configurations", ConfigurationReader.Configurations.Count());
            _handleError.HandleAll(ConfigurationReader.Configurations);
            Log.InfoFormat("Handled Recovery messages on queues. Number of Configurations handled {0}", ConfigurationReader.Configurations.Count());
        }
    }

    public class RetryErrorsOnAQueuesConsumer : AbstractConsumer<RetryErrorsOnAQueueMessage>
    {
        private static readonly ILog Log = LogManager.GetLogger<RetryErrorsOnAQueuesConsumer>();
        private readonly IHandleErrorMessageRecovery _handleError;
        public RetryErrorsOnAQueuesConsumer(IHandleErrorMessageRecovery handleError)
        {
            _handleError = handleError;
        }
        public override void Consume(RetryErrorsOnAQueueMessage message)
        {
            Log.InfoFormat("Attempting to Retry Errors on queue {0}", message.Configuration.Options.ErrorQueueName);
            _handleError.Handle(message.Configuration.Options);
            Log.InfoFormat("Handled Recovery messages on queue {0}", message.Configuration.Options.ErrorQueueName);
        }
    }
}