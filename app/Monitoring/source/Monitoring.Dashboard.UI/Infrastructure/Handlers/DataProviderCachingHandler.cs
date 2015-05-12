using Lace.Caching.Messages;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
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