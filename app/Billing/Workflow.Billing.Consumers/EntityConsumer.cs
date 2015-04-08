using System.Runtime.InteropServices;
using Castle.Windsor;
using EasyNetQ.AutoSubscribe;
using NHibernate;
using Shared.Messaging.Billing.Helpers;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers
{
    public class EntityConsumer : IConsume<UserMessage>
    {
        //private readonly ISession session;
        //private readonly IRepository<UserMessage> _repository;

        //public EntityConsumer(IRepository<UserMessage> repository)
        //{
        //    _repository = repository;
        //}

        //public void Consume(UserMessage entity)
        //{
        //    _repository.SaveOrUpdate(entity);
        //}
        public void Consume(UserMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}