using System;
using System.Collections.Generic;
using Lim.Core;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Read
{
    public class ReadRepository : IRepository
    {
        public void Save<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Merge<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(object id)
        {
            throw new NotImplementedException();
        }

        public T Find<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
