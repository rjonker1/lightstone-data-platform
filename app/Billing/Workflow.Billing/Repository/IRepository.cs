using System;
using System.Linq;

namespace Workflow.Billing.Repository
{
    public interface IRepository<T> : IQueryable<T> where T : class 
    {
        //TType Get<TType>(Guid id) where TType : class;
        //void Add<TType>(TType instance);

        T Get(object id);
        T Load(object id);
        T Persist(T entity);
        void Save(T entity);
        void SaveOrUpdate(T entity);
        void Refresh(T entity);
        void Delete(T entity);
    }
}