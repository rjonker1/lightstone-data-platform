using Lace.Caching.Messages;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderCaching
    {
        void Handle(ClearCacheCommand command);
        void Handle(RefreshCacheCommand command);
        void Handle(RestartCacheDataStoreCommand command);
    }
}
