using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_new_transaction_to_queue : BaseTestHelper
    {
        private readonly IAdvancedBus _bus;
        private InvoiceTransactionCreated transaction;

        public when_publishing_new_transaction_to_queue()
        {
            _bus = Container.Resolve<IAdvancedBus>();
        }

        public override void Observe()
        {

        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            var bus = new TransactionBus(_bus);

            // Customer
            transaction = new InvoiceTransactionCreated(new Guid("4B905242-4352-4A36-B1CD-CF6832606703"));

            bus.SendDynamic(transaction);

            _bus.ShouldNotBeNull();
        }
    }
}