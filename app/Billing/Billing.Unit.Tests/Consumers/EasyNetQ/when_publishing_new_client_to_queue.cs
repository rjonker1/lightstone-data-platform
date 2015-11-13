using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_new_client_to_queue : BaseTestHelper
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_client_to_queue()
        {
            _bus = Container.Resolve<IAdvancedBus>();
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var client = new ClientMessage()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                AccountNumber = "UNITTESTCL001",
                BillingType = "Response",
                CreatedBy = "UNITTEST",
                ClientId = new Guid("45547DDC-6AB7-4C45-BF50-9F6066AB3EEF"),
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