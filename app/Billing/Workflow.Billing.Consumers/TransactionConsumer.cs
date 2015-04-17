﻿using Castle.Windsor;
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
        }
    }

}