using System;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Consumers.ConsumerTypes;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Consumers
{
    public class when_consuming_contract_message: BaseTestHelper
    {
        private readonly ContractMessage _message;
        private Exception thrownException;

        public when_consuming_contract_message()
        {
            _message = new ContractMessage
            {
                Id = Guid.NewGuid(),
                ContractId = Guid.NewGuid(),
                ContractName = "Testeroonie Contract 1",
                ContractBundleId = Guid.NewGuid(),
                ContractBundleName = "Bundle 1",
                ContractBundlePrice = 0.00,
                ContractBundleTransactionLimit = 500,
                HasPackagePriceOverride = true
            };
        }

        public override void Observe()
        {
            try
            {
                Container.Resolve<ContractConsumer>().Consume(new Message<ContractMessage>(_message));
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