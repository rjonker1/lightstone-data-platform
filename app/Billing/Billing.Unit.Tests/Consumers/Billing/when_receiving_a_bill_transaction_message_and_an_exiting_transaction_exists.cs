using System;
using System.Linq.Expressions;
using Billing.TestHelper.Mothers.BillTransactionMessages;
using Moq;
using Shared.Public.TestHelpers.Extentions;
using Workflow.Billing;
using Workflow.Billing.Consumers;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.Billing
{
    public class when_receiving_a_bill_transaction_message_and_an_exiting_transaction_exists : Specification
    {
        private readonly BillTransactionConsumer consumer;
        private readonly BillTransactionMessage message;
        private readonly Mock<IRepository> repository;
        private Exception thrownException;

        public when_receiving_a_bill_transaction_message_and_an_exiting_transaction_exists()
        {
            repository = new Mock<IRepository>();
            repository.Setup(r => r.Get<InvoiceTransaction>(It.IsAny<Guid>()))
                .Returns(() => new InvoiceTransaction());

            consumer = new BillTransactionConsumer(repository.Object);

            message = BillTransactionMessageMother.BillTransactionMessage();
        }

        public override void Observe()
        {
            try
            {
                consumer.Consume(message);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void the_message_is_consumed()
        {
            thrownException.ShouldBeNull();
        }

        [Observation]
        public void a_new_transaction_is_not_created()
        {
            repository.IsNeverCalled(r => r.Add(It.IsAny<InvoiceTransaction>()));
        }
    }
}