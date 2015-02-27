using Billing.Acceptance.Tests.Fixtures;
using Billing.Api.Connector;
using Billing.Api.Connector.Configuration;
using Billing.Api.Dtos;
using Billing.TestHelper.Mothers.CreatTransactionDto;
using Xunit;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    public class when_create_a_new_transaction : Specification, IUseFixture<RebuildBillingEnvironment>
    {
        private readonly IConnectToBilling connector;
        private readonly CreateTransaction transaction;
        private BillingConnectorResponse response;

        public when_create_a_new_transaction()
        {
            connector = new DefaultBillingConnector(new ApplicationConfigurationBillingConnectorConfiguration());
            transaction = new CreateTransactionMother().DefaultCreateTransaction();
        }

        public override void Observe()
        {
            response = connector.CreateTransaction(transaction);
        }

        [Observation]
        public void the_api_accepts_the_transaction()
        {
            response.Success.ShouldBeTrue();
        }

        [Observation]
        public void a_transaction_is_created()
        {
            
        }


        public void SetFixture(RebuildBillingEnvironment environmentSetup)
        {
            environmentSetup.Run();
        }
    }
}