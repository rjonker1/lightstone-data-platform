using EasyNetQ;
using Workflow.Lace.Messages.Events;

namespace Workflow.Transactions.Receiver.Service.Handlers
{
    public class ContextReceiver
    {
        public void Consume(IMessage<SecurityFlagRaised> message)
        {

        }

        public void Consume(IMessage<DataProviderConfigured> message)
        {

        }

        public void Consume(IMessage<DataProviderCallEnded> message)
        {

        }

        public void Consume(IMessage<DataProviderCallStarted> message)
        {

        }

        public void Consume(IMessage<DataProviderError> message)
        {

        }

        public void Consume(IMessage<DataProviderResponseTransformed> message)
        {

        }
    }
}
