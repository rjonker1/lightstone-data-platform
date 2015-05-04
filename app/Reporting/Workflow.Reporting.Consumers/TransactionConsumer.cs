using Castle.Windsor;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Reporting.Consumers.ConsumerTypes;

namespace Workflow.Reporting.Consumers
{
    public class TransactionConsumer<T>
    {
        public TransactionConsumer(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<ReportMessage>) container.Resolve<ReportConsumer>().Consume(message as IMessage<ReportMessage>);
        }
    }

}