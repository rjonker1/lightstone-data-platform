//using Billing.Api.Dtos;
//using Billing.TestHelper.Fakes;
//using Billing.TestHelper.Mothers.CreatTransactionDto;
//using Nancy;
//using Nancy.Testing;
//using Xunit.Extensions;

//namespace Billing.Api.Tests.Api.Transaction
//{
//    public class when_creating_a_new_billing_transaction_as_an_unauthorised_user : TransactionModuleTestBase, AsUnautorisedUser
//    {
//        private readonly CreateTransaction transaction;
//        private BrowserResponse result;

//        public when_creating_a_new_billing_transaction_as_an_unauthorised_user()
//            : base(new NullPublisher())
//        {
//            transaction = new CreateTransactionMother().DefaultCreateTransaction();
//        }

//        public override void Observe()
//        {
//            result = Post(with => with.JsonBody(transaction));
//        }

//        [Observation]
//        public void an_unautorised_error_is_returned()
//        {
//            result.StatusCode.ShouldEqual(HttpStatusCode.Unauthorized);
//        }

//    }
//}