using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class UserConsumer
    {
        private readonly IRepository<UserMeta> _userMetaRepository;

        public UserConsumer(IRepository<UserMeta> userMetaRepository)
        {
            _userMetaRepository = userMetaRepository;
        }

        public void Consume(IMessage<UserMessage> message)
        {
            //New User
            var entity = Mapper.Map<UserMessage, UserMeta>(message.Body);
            _userMetaRepository.SaveOrUpdate(entity);
        }
    }
}