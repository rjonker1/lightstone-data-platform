using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.EasyNetQ
{
    public class when_publishing_new_package_to_queue : Specification
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_package_to_queue()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var packageId = new Guid("E2E91BEA-B301-4CAD-A58A-425BC613C22C");

            var client = new PackageMessage()
            {
                Id = packageId,
                PackageId = packageId,
                PackageName = "PackageTest 1",
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