namespace Lace.Domain.Core.Contracts.Caching
{
    public interface IAmCachable
    {
        void AddToCache(ICacheRepository repository);
    }
}
