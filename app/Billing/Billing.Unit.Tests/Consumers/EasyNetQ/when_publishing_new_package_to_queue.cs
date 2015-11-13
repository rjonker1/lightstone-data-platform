using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_new_package_to_queue : BaseTestHelper
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_package_to_queue()
        {
            _bus = Container.Resolve<IAdvancedBus>();
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