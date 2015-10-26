using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.EasyNetQ
{
    public class when_publishing_new_transaction_cleanup_schedule_to_queue: BaseTestHelper
    {
        private readonly IAdvancedBus _bus;
        private TransactionRequestCleanupMessage cleanup;

        public when_publishing_new_transaction_cleanup_schedule_to_queue()
        {
            _bus = Container.Resolve<IAdvancedBus>();
        }

        public override void Observe()
        {

        }

        [Observation]
        public void it_should_publish_a_schedule_transaction()
        {
            var bus = new TransactionBus(_bus);

            cleanup = new TransactionRequestCleanupMessage
            {
                RequestId = new Guid()
            };

            bus.SendDynamic(cleanup);

            _bus.ShouldNotBeNull();
        }
    }
}