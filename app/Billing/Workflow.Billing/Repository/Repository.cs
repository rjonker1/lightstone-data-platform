﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataPlatform.Shared.Helpers.Extensions;
using NHibernate;
using NHibernate.Linq;
using Shared.Messaging.Billing.Helpers;
using Workflow.Billing.Helpers.Extensions;

namespace Workflow.Billing.Repository
{
    //public class Repository : IRepository
    //{
    //private readonly IDbConnection _connection;
    //private readonly IRepositoryMapper _mapper;

    //public Repository(IDbConnection connection, IRepositoryMapper mapper)
    //{
    //    _mapper = mapper;
    //    _connection = connection;
    //}

    //public TType Get<TType>(Guid id) where TType : class
    //{
    //    var mapping = _mapper.GetMapping(typeof(TType));

    //    return mapping.Get(_connection, id) as TType;

    //}

    //public void Add<TType>(TType instance)
    //{
    //    var mapping = _mapper.GetMapping(instance);

    //    mapping.Insert(_connection, instance);
    //}
    //}

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        private PipelineExtensions pipelineExtensions;

        public Repository(ISession session)
        {
            _session = session;
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

        public void Save(T entity)
        {
            ValidateEntity(entity);
            _session.Save(entity);
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

            currSession.SaveOrUpdate(entity);

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