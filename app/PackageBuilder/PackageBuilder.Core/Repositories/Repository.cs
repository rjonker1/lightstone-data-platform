using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T Get(object id)
        {
            return _session.Get<T>(id);
        }

        public T Load(object id)
        {
            return _session.Load<T>(id);
        }

        public T Persist(T entity)
        {
            _session.Persist(entity);
            return entity;
        }

        public void Save(T entity)
        {
            if ((entity is Entity) && (entity as Entity).Id == new Guid())
                return;

            _session.Save(entity);
        }

        public void Update(T entity)
        {
            if ((entity is Entity) && (entity as Entity).Id == new Guid())
                return;

            _session.Update(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            if ((entity is Entity) && (entity as Entity).Id == new Guid())
                return;

            _session.SaveOrUpdate(entity);
        }

        public void Refresh(T entity)
        {
            if ((entity is Entity) && (entity as Entity).Id == new Guid())
                return;

            var id = _session.GetIdentifier(entity);
            _session.Evict(entity);
            _session.Load(entity, id);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }

        #region IQueryable members

        public IEnumerator<T> GetEnumerator()
        {
            return GetLinq().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetLinq().GetEnumerator();
        }

        public Expression Expression
        {
            get { return GetLinq().Expression; }
        }

        public Type ElementType
        {
            get { return GetLinq().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return GetLinq().Provider; }
        }
        
        protected virtual IQueryable<T> GetLinq()
        {
            return _session.Query<T>();
        }

        #endregion
    }
}