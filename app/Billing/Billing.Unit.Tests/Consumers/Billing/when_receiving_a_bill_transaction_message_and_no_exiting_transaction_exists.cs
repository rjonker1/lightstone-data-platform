
//namespace Billing.Api.Tests.Consumers.Billing
//{
//    public class when_receiving_a_bill_transaction_message_and_no_exiting_transaction_exists : Specification
//    {
//        private readonly BillTransactionConsumer consumer;
//        private readonly BillTransactionMessage message;
//        private readonly Mock<IRepository> repository;
//        private Exception thrownException;

//        public when_receiving_a_bill_transaction_message_and_no_exiting_transaction_exists()
//        {
//            repository = new Mock<IRepository>();
//            consumer = new BillTransactionConsumer(repository.Object);

//            message = BillTransactionMessageMother.BillTransactionMessage();
//        }

//        public override void Observe()
//        {
//            try
//            {
//                consumer.Consume(message);
//            }
//            catch (Exception e)
//            {
//                thrownException = e;
//            }
//        }

//        [Observation]
//        public void the_message_is_consumed()
//        {
//            thrownException.ShouldBeNull();
//        }

//        [Observation]
//        public void a_new_transaction_is_created()
//        {
//            repository.Verify(r => r.Add(It.Is<InvoiceTransaction>(t => CompareTransaction(t))));
//        }

//        private bool CompareTransaction(InvoiceTransaction transaction)
//        {
//            if (transaction == null)
//                return false;

//            return transaction.Id == message.TransactionId &&
//                   transaction.Date == message.TransactionDate &&
//                   transaction.Package.Equals(message.PackageIdentifier) &&
//                   transaction.User.Equals(message.UserIdentifier) &&
//                   transaction.Request.Equals(message.RequestIdentifier);
//        }
//    }
//}