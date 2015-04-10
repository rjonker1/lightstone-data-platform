using AutoMapper;
using DataPlatform.Shared.Repositories;
using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers
{
    public class EntityConsumer : IConsume<UserMessage>
    {
        private readonly IRepository<UserMeta> _repository;

        public EntityConsumer(IRepository<UserMeta> repository)
        {
            _repository = repository;
        }

        public void Consume(UserMessage message)
        {
            var entity = Mapper.Map<UserMessage, UserMeta>(message);
            _repository.SaveOrUpdate(entity);
        }

    }
}