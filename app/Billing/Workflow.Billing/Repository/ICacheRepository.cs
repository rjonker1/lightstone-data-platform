using System;
using System.Threading.Tasks;
using DataPlatform.Shared.Repositories;

namespace Workflow.Billing.Repository
{
    public interface ICacheRepository<T>
    {
        T CacheGet(Guid entityId);
        void CacheSave(T entity);
        void CacheDelete(Guid entityId);
        Task<bool> CachePipelineInsert(IRepository<T> typedEntityRepository);
    }
}