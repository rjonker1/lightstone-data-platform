using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using DataPlatform.Shared.Helpers.Extensions;
using NHibernate;
using NHibernate.Linq;
using Shared.Messaging.Billing.Helpers;

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

    public class Repository<Q> : IRepository<Q>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public Q Get(object id)
        {
            return _session.Get<Q>(id);
        }

        public Q Load(object id)
        {
            return _session.Load<Q>(id);
        }

        public Q Persist(Q entity)
        {
            ValidateEntity(entity);
            _session.Persist(entity);
            return entity;
        }

        public void Save(Q entity)
        {
            ValidateEntity(entity);
            _session.Save(entity);
        }

        public void Update(Q entity)
        {
            ValidateEntity(entity);
            _session.Update(entity);
        }

        public void SaveOrUpdate(Q entity)
        {
            ValidateEntity(entity);
            _session.SaveOrUpdate(entity);
        }

        public void Refresh(Q entity)
        {
            ValidateEntity(entity);

            var id = _session.GetIdentifier(entity);
            _session.Evict(entity);
            _session.Load(entity, id);
        }

        public void Delete(Q entity)
        {
            ValidateEntity(entity);
            _session.Delete(entity);
        }

        private void ValidateEntity(Q entity)
        {
            if ((entity is Entity) && (entity as Entity).Id == new Guid())
            {
                this.Info(() => "Not a valid NHibernate entity {0} - {1}".FormatWith((entity as Entity).Id, entity));
                throw new InvalidOperationException();
            }
        }

        #region IQueryable members

        public IEnumerator<Q> GetEnumerator()
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

        protected virtual IQueryable<Q> GetLinq()
        {
            return _session.Query<Q>();
        }

        #endregion
    }
}