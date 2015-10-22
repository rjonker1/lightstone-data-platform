using Castle.Windsor;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;

namespace Workflow.Billing.Consumers
{

    public class TransactionConsumer<T>
    {
        public TransactionConsumer(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<InvoiceTransactionCreated>) container.Resolve<InvoiceTransactionConsumer>().Consume(message as IMessage<InvoiceTransactionCreated>);
            if (message is IMessage<UserMessage>) container.Resolve<UserConsumer>().Consume(message as IMessage<UserMessage>);
            if (message is IMessage<CustomerMessage>) container.Resolve<CustomerConsumer>().Consume(message as IMessage<CustomerMessage>);
            if (message is IMessage<ClientMessage>) container.Resolve<ClientConsumer>().Consume(message as IMessage<ClientMessage>);
            if (message is IMessage<PackageMessage>) container.Resolve<PackageConsumer>().Consume(message as IMessage<PackageMessage>);
            if (message is IMessage<ContractMessage>) container.Resolve<ContractConsumer>().Consume(message as IMessage<ContractMessage>);
            if (message is IMessage<TransactionRequestMessage>) container.Resolve<TransactionRequestConsumer>().Consume(message as IMessage<TransactionRequestMessage>);
        }
    }

}