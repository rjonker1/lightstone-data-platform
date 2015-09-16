using System;
using System.Collections;
using System.Collections.Generic;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_registering_multiple_exchanges_queues_for_message_types : BaseTestHelper
    {
        private readonly IAdvancedBus _bus;
        private InvoiceTransactionCreated transaction;

        public when_registering_multiple_exchanges_queues_for_message_types()
        {
            _bus = Container.Resolve<IAdvancedBus>();
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            //Register Exchanges and Queues for multiple message types
            var messageTypes = new ArrayList
            {
                new InvoiceTransactionCreated(), 
                new EntityMessage()
            };

            IEnumerable<Object> listedMessageTypes = messageTypes.ToArray();

            bus.RegisterQueuesExchanges(listedMessageTypes);
            //END - Register
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}