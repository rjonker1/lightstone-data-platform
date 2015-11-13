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
            if(message is IMessage<ClearCacheCommand>)
                container.Resolve<CacheConsumer>().Consume((IMessage<ClearCacheCommand>)message);

            if (message is IMessage<RefreshCacheCommand>)
                container.Resolve<CacheConsumer>().Consume((IMessage<RefreshCacheCommand>)message);

            if (message is IMessage<RestartCacheDataStoreCommand>)
                container.Resolve<CacheConsumer>().Consume((IMessage<RestartCacheDataStoreCommand>)message);
        }
    }
}