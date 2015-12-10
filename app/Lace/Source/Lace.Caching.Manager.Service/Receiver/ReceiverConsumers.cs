using System;
using System.Collections.Generic;
using Castle.Windsor;
using EasyNetQ;
using Lace.Caching.Manager.Service.Consumers;
using Lace.Caching.Messages;

namespace Lace.Caching.Manager.Service.Receiver
{
    public class ReceiverConsumers<T>
    {
        public ReceiverConsumers(IMessage<T> message, IWindsorContainer container)
        {
            Action<IWindsorContainer, IMessage<T>> consumer;
            if (_consumers.TryGetValue(typeof(T), out consumer))
                consumer(container, message);
        }

        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary
            <Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {
                typeof (ClearCacheCommand),
                (container, message) => container.Resolve<CacheConsumer>().Consume((IMessage<ClearCacheCommand>) message)
            },
            {
                typeof (RefreshCacheCommand),
                (container, message) => container.Resolve<CacheConsumer>().Consume((IMessage<RefreshCacheCommand>) message)
            },
            {
                typeof (RestartCacheDataStoreCommand),
                (container, message) => container.Resolve<CacheConsumer>().Consume((IMessage<RestartCacheDataStoreCommand>) message)
            },
        };
    }
}