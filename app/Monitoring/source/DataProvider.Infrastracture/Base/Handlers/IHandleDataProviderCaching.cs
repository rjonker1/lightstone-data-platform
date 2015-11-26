using Lace.Caching.Messages;

namespace DataProvider.Infrastructure.Base.Handlers
{
    public interface IHandleDataProviderCaching
    {
        void Handle(ClearCacheCommand command);
        void Handle(RefreshCacheCommand command);
        void Handle(RestartCacheDataStoreCommand command);
    }
}
