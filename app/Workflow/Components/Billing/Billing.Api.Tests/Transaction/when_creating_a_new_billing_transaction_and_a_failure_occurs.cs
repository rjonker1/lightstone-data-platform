using Billing.Api.Dtos;
using Billing.Api.Tests.Fakes;
using Billing.Api.Tests.Mothers.CreatTransactionDto;
using Nancy;
using Nancy.Testing;
using Xunit.Extensions;

namespace Billing.Api.Tests.Transaction
{
    public class when_creating_a_new_billing_transaction_and_a_failure_occurs : TransactionModuleTestBase
    {
        private BrowserResponse result;
        private readonly CreateTransaction transaction;

        public when_creating_a_new_billing_transaction_and_a_failure_occurs() : base(new FailingMessagePublisher())
        {
            transaction = new CreateTransactionMother().DefaultCreateTransaction();
        }

        public override void Observe()
        {
            result = browser.Post(url, with => with.JsonBody(transaction));
        }

        [Observation]
        public void an_error_code_is_returned()
        {
            result.StatusCode.ShouldEqual(HttpStatusCode.InternalServerError);
        }
    }
}