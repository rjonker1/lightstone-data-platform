using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_package_message: BaseTestHelper
    {
        private readonly PackageMessage _message;
        private Exception thrownException;

        public when_consuming_package_message()
        {
            _message = new PackageMessage
            {
                Id = Guid.NewGuid(),
                PackageId = Guid.NewGuid(),
                PackageName = "TESTPackage"
            };
        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<PackageConsumer>().Consume(new Message<PackageMessage>(_message));
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