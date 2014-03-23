using Billing.Api.Dtos;
using Billing.Api.Tests.Fakes;
using Billing.Api.Tests.Mothers.CreatTransactionDto;
using Nancy;
using Nancy.Testing;
using Workflow;
using Xunit.Extensions;

namespace Billing.Api.Tests
{
    public class when_creating_a_new_billing_transaction_and_a_failure_occurs : Specification
    {
        private readonly Browser browser;
        private BrowserResponse result;
        private readonly CreateTransaction transaction;
        private readonly FailingMessagePublisher publisher;

        public when_creating_a_new_billing_transaction_and_a_failure_occurs()
        {
            publisher = new FailingMessagePublisher();

            browser = new Browser(with =>
                                  {
                                      with.Module<Transaction>();
                                      with.Dependency<IPublishMessages>(publisher);
                                  });
            transaction = new CreateTransactionMother().DefaultCreateTransaction();
        }

        public override void Observe()
        {
            result = browser.Post("/transaction", with => with.JsonBody(transaction));
        }

        [Observation]
        public void an_error_code_is_returned()
        {
            result.StatusCode.ShouldEqual(HttpStatusCode.InternalServerError);
        }
    }
}