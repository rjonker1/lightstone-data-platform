using System.Linq;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class TransactionRequestConsumer : IConsumeMessages<TransactionRequestMessage>
    {
        private readonly IRepository<TransactionRequest> _transactionRequestRepository;

        public TransactionRequestConsumer(IRepository<TransactionRequest> transactionRequestRepository)
        {
            _transactionRequestRepository = transactionRequestRepository;
        }

        public void Consume(IMessage<TransactionRequestMessage> message)
        {
            var entity = _transactionRequestRepository.FirstOrDefault(x => x.RequestId == message.Body.RequestId);

            if (entity != null)
            {
                entity.UserState = message.Body.UserState;

                _transactionRequestRepository.SaveOrUpdate(entity);
            }
        }
    }
}