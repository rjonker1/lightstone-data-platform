using NServiceBus;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Repository;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Transaction : IHandleMessages<TransactionCreated>
    {
        private readonly IRepository _repository;

        public Transaction()
        {

        }

        public Transaction(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(TransactionCreated message)
        {
            
        }
    }
}
