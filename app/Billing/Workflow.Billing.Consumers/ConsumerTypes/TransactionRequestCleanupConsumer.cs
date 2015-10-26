using System;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Billing.Helpers.Schedules;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class TransactionRequestCleanupConsumer : IConsumeMessages<TransactionRequestCleanupMessage>
    {
        private readonly ICleanup _cleanTransactionRequests;

        public TransactionRequestCleanupConsumer(ICleanup cleanTransactionRequests)
        {
            _cleanTransactionRequests = cleanTransactionRequests;
        }

        public void Consume(IMessage<TransactionRequestCleanupMessage> message)
        {
            if (message.Body.RequestId == new Guid())
            {
                _cleanTransactionRequests.Clean();
            }
        }
    }
}