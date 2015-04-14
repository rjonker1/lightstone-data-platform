using AutoMapper;
using DataPlatform.Shared.Repositories;
using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers
{
    public class EntityConsumer : IConsume<UserMessage>
    {
        private readonly IRepository<UserMeta> _repository;
        private readonly IRepository<Transaction> _transactions;

        private readonly IRepository<PreBilling> _preBillings; 
        //private readonly IRepository<User> _users;

        public EntityConsumer(IRepository<UserMeta> repository, IRepository<Transaction> transactions, IRepository<PreBilling> preBillings)//, IRepository<User> users)
        {
            _repository = repository;
            _transactions = transactions;
            _preBillings = preBillings;
        }

        public void Consume(UserMessage message)
        {
            //New User
            var entity = Mapper.Map<UserMessage, UserMeta>(message);
            _repository.SaveOrUpdate(entity);
        }

    }

    
}