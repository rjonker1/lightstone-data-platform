using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_invoice_transaction_created_message: BaseTestHelper
    {
        private readonly InvoiceTransactionCreated _message;
        private Exception thrownException;

        public when_consuming_invoice_transaction_created_message()
        {
            _message = new InvoiceTransactionCreated(Guid.NewGuid());
        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<InvoiceTransactionConsumer>().Consume(new Message<InvoiceTransactionCreated>(_message));
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_consume_message()
        {
            thrownException.ShouldBeNull();
        }
    }
}