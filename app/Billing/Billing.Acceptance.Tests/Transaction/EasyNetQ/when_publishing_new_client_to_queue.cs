using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_publishing_new_client_to_queue : Specification
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_client_to_queue()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var client = new ClientMessage()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                AccountNumber = "UNITTESTCL001",
                CreatedBy = "UNITTEST",
                ClientId = Guid.NewGuid(),
                ClientName = "Client 1"
            };

            bus.SendDynamic(client);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}