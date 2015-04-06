using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;

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
