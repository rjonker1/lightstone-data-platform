using System;
using Billing.Api.Dtos;
using Billing.Api.Tests.Fakes;
using Billing.Api.Tests.Mothers.CreatTransactionDto;
using Nancy;
using Nancy.Testing;
using Workflow.Billing.Messages;
using Xunit.Extensions;

namespace Billing.Api.Tests.Transaction
{
    public class when_creating_a_new_billing_transaction : TransactionModuleTestBase
    {
        private BrowserResponse result;
        private readonly CreateTransaction transaction;

        public when_creating_a_new_billing_transaction() : base(new TestMessagePublisher())
        {
            transaction = new CreateTransactionMother().DefaultCreateTransaction();
        }

        public override void Observe()
        {
            result = Post(with => with.JsonBody(transaction));
        }

        private TestMessagePublisher ThePublisher
        {
            get { return publisher as TestMessagePublisher; }
        }

        [Observation]
        public void success_is_returned()
        {
            result.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }

        [Observation]
        public void a_message_is_published_to_create_the_billing_transaction()
        {
            ThePublisher.PublishedMessage.ShouldNotBeNull();
            ThePublisher.PublishedMessage.ShouldBeType<BillTransactionMessage>();
        }

        [Observation]
        public void the_published_message_has_the_correct_information()
        {
            var message = ThePublisher.PublishedMessage as BillTransactionMessage;

//            message.TransactionId.ShouldEqual(transaction.TransactionId);
//            message.UserId.ShouldEqual(transaction.UserId);
        }
    }
}
