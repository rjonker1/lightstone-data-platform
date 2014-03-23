using Billing.Api.Dtos;
using Billing.Api.Tests.Fakes;
using Billing.Api.Tests.Mothers.CreatTransactionDto;
using Nancy;
using Nancy.Testing;
using Workflow;
using Workflow.Billing.Messages;
using Xunit.Extensions;

namespace Billing.Api.Tests
{
    public class when_creating_a_new_billing_transaction : Specification
    {
        private readonly Browser browser;
        private BrowserResponse result;
        private readonly CreateTransaction transaction;
        private readonly TestMessagePublisher publisher;

        public when_creating_a_new_billing_transaction()
        {
            publisher = new TestMessagePublisher();

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
        public void success_is_returned()
        {
            result.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }

        [Observation]
        public void a_message_is_published_to_create_the_billing_transaction()
        {
            publisher.PublishedMessage.ShouldNotBeNull();
            publisher.PublishedMessage.ShouldBeType<BillTransactionMessage>();
        }

        [Observation]
        public void the_published_message_has_the_correct_information()
        {
            var message = publisher.PublishedMessage as BillTransactionMessage;

            message.TransactionId.ShouldEqual(transaction.TransactionId);
            message.UserId.ShouldEqual(transaction.UserId);
        }
    }
}
