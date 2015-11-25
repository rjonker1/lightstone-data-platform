using System;
using System.Threading.Tasks;

namespace PackageBuilder.Infrastructure.NEventStore
{
    public interface ICacheProvider<T>
    {
        Task<T> CacheGet(Guid entityId);
        void CacheSave(Guid entityId, T entity);
        void CacheDelete(Guid entityId);
    }
}