﻿using System;
using System.Collections;
using System.Collections.Generic;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_registering_multiple_exchanges_queues_for_message_types : Specification
    {
        private readonly IAdvancedBus _bus;
        private InvoiceTransactionCreated transaction;

        public when_registering_multiple_exchanges_queues_for_message_types()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
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