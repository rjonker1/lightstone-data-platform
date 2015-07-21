using System;

namespace PackageBuilder.Core.Repositories
{
    public interface ICacheRepository <T>
    {
        T CacheGet(Guid entityId);
        void CacheSave(T entity);
        T CacheDelete(Guid entityId);
    }
}