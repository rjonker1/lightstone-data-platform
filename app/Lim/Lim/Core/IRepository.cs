using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Lim.Core
{
    public interface IRepository : IWriteOnlyRepository, IReadOnlyRepository
    {
    }

    public interface IWriteOnlyRepository
    {
        void Save<T>(T entity) where T : class;
        void SaveOrUpdate<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Merge<T>(T entity) where T : class;
    }

    public interface IReadOnlyRepository
    {
        T Get<T>(object id);
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
    }
}