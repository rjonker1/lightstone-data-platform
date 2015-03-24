using System;
using System.Collections.Generic;
using Castle.Windsor;
using MemBus;

namespace Billing.Infrastructure
{
    public class MessageAdapter : IocAdapter
    {

        private readonly IWindsorContainer _container;

        public MessageAdapter(IWindsorContainer container)
        {
            _container = container;
        }

        public IEnumerable<object> GetAllInstances(Type desiredType)
        {
            yield return _container.Resolve(desiredType);
        }
    }
}