using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers
{
    public class EntityConsumer : IConsume<UserMessage>
    {
        private readonly IRepository<UserMessage> _repository;

        public EntityConsumer(IRepository<UserMessage> repository)
        {
            _repository = repository;
        }

        public void Consume(UserMessage entity)
        {
            _repository.SaveOrUpdate(entity);
        }

    }
}