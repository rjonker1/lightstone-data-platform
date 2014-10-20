using System.Linq;

namespace PackageBuilder.Core.Repositories
{
    public interface IRepository<T> : IQueryable<T>
    {
        T Get(object id);
        T Load(object id);
        T Persist(T entity);
        void Save(T entity);
        void SaveOrUpdate(T entity);
        void Refresh(T entity);
        void Delete(T entity);
    }
}