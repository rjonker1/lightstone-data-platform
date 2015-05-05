namespace Lace.Shared.DataProvider.Contracts
{
    public interface IAmCachable
    {
        void AddToCache(ICacheRepository repository);
    }
}
