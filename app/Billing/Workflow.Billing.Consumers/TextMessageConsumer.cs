using Common.Logging;
using EasyNetQ.AutoSubscribe;
//using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Messages;

namespace Workflow.Billing.Consumers
{
    public class TextMessageConsumer : IConsume<TextMessage>
    {

        private static readonly ILog _log = LogManager.GetLogger<TextMessageConsumer>();

        public void Consume(TextMessage message)
        {
            _log.InfoFormat("Test message {0}", message);
        }
    }
}
