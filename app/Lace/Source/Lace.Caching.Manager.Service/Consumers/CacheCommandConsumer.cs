using EasyNetQ;
using Lace.Caching.Manager.Service.Handlers;
using Lace.Caching.Messages;

namespace Lace.Caching.Manager.Service.Consumers
{
    public class CacheCommandConsumer
    {
        private readonly IHandleClearingData _clear;
        private readonly IHandleRefreshingData _refresh;

        public CacheCommandConsumer(IHandleClearingData clear, IHandleRefreshingData refresh)
        {
            _clear = clear;
            _refresh = refresh;
        }

        public void Consume(IMessage<ClearCacheCommand> message)
        {
            _clear.Handle();
        }

        public void Consume(IMessage<RefreshCacheCommand> message)
        {
           _refresh.Handle();
        }

        public void Consume(IMessage<RestartCacheDataStoreCommand> message)
        {
            //TODO: Restart redis
        }
    }
}
