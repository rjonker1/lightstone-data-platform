using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Repositories;
using NHibernate;
using NHibernate.Linq;
using Workflow.Billing.Helpers.Extensions;

namespace Workflow.Billing.Repository
{
    
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;
        private readonly ICacheProvider<T> _cacheProvider; 

        private PipelineExtensions pipelineExtensions;

        public Repository(ISession session, ICacheProvider<T> cacheProvider)
        {
            _session = session;
            _cacheProvider = cacheProvider;
            pipelineExtensions = new PipelineExtensions();
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
            ValidateEntity(entity);
            _session.Persist(entity);
            return entity;
        }

        public virtual void Save(T entity)
        {
            //ValidateEntity(entity);

            var currSession = pipelineExtensions.BeforeTransaction(_session);

            currSession.Save(entity);

            pipelineExtensions.AfterTransaction(currSession);
        }

        public void Save(T entity, bool useCache = false)
        {
            var currSession = pipelineExtensions.BeforeTransaction(_session);

            currSession.Save(entity);
            if (useCache) _cacheProvider.CacheSave(entity);

            pipelineExtensions.AfterTransaction(currSession);
        }

        public void Update(T entity)
        {
            ValidateEntity(entity);
            _session.Update(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            ValidateEntity(entity);

            var currSession = pipelineExtensions.BeforeTransaction(_session);

            //currSession.SaveOrUpdate(entity);
            currSession.Merge(entity);

            pipelineExtensions.AfterTransaction(currSession);
        }

        public void SaveOrUpdate(T entity, bool useCache = false)
        {
            ValidateEntity(entity);

            var currSession = pipelineExtensions.BeforeTransaction(_session);

            currSession.Merge(entity);
            if (useCache) _cacheProvider.CacheSave(entity);

            pipelineExtensions.AfterTransaction(currSession);
        }

        public void Refresh(T entity)
        {
            ValidateEntity(entity);

            var id = _session.GetIdentifier(entity);
            _session.Evict(entity);
            _session.Load(entity, id);
        }

        public void Delete(T entity)
        {
            ValidateEntity(entity);
            _session.Delete(entity);
        }

        public void Delete(T entity, bool useCache = false)
        {
            throw new NotImplementedException();
        }

        private void ValidateEntity(T entity)
        {
            if ((entity is Entity) && (entity as Entity).Id == new Guid())
            {
                this.Info(() => "Not a valid NHibernate entity {0} - {1}".FormatWith((entity as Entity).Id, entity));
                throw new InvalidOperationException();
            }
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