using System.Threading.Tasks;
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
            
            var consumerRouter = ConsumerRouter(message, container);
            consumerRouter.Wait();
        }

        public async Task ConsumerRouter(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<ReportMessage>)
            {
                var consumer = container.Resolve<ReportConsumer>();
                await consumer.Consume(message as IMessage<ReportMessage>);
            }
        }
    }

}