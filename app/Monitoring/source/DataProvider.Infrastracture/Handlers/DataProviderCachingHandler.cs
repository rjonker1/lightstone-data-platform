using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Base.Services;
using Lace.Caching.Messages;

namespace DataProvider.Infrastructure.Handlers
{
    public class DataProviderCachingHandler : IHandleDataProviderCaching
    {
        private readonly IPublishCacheMessages _publisher;

        public DataProviderCachingHandler(IPublishCacheMessages publisher)
        {
            _publisher = publisher;
        }

        public void Handle(ClearCacheCommand command)
        {
            _publisher.SendToBus(command);
        }

        public void Handle(RefreshCacheCommand command)
        {
            _publisher.SendToBus(command);
        }

        public void Handle(RestartCacheDataStoreCommand command)
        {
            _publisher.SendToBus(command);
        }
    }
}