using System.Collections.Generic;
using System.Linq;

namespace DataPlatform.Shared.Repositories
{
    public interface IRepository<T> : IQueryable<T>
    {
        T Get(object id);
        T Load(object id);
        T Persist(T entity);
        void Save(T entity);
        void Save(T entity, bool useCache = false);
        void SaveOrUpdate(T entity);
        void SaveOrUpdate(T entity, bool useCache = false);
        void BatchInsert(IEnumerable<T> repository, int batchSize);
        void BatchDelete(IEnumerable<T> repository, int batchSize);
        void Refresh(T entity);
        void Delete(T entity);
        void Delete(T entity, bool useCache = false);
    }
}