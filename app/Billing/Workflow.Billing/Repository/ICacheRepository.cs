using System;

namespace Workflow.Billing.Repository
{
    public interface ICacheRepository<T>
    {
        T CacheGet(Guid entityId);
        void CacheSave(T entity);
        void CacheDelete(Guid entityId);
    }
}