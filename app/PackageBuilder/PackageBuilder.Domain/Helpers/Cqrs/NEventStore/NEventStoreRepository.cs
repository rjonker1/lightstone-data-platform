using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using NEventStore;

namespace PackageBuilder.Domain.Helpers.Cqrs.NEventStore
{
    public interface IRepository<T> : IRepository
    {
        T GetById(Guid id, int version);
        void Save(IAggregate aggregate, Guid commitId);
    }

    public class NEventStoreRepository<T> : EventStoreRepository, IRepository<T> where T : AggregateBase
    {
        public NEventStoreRepository(IStoreEvents eventStore, IConstructAggregates factory, IDetectConflicts conflictDetector) : base(eventStore, factory, conflictDetector)
        {
        }

        public T GetById(Guid id, int version)
        {
            return GetById<T>(typeof(T).Name, id, 1);
        }

        public void Save(IAggregate aggregate, Guid commitId)
        {
            this.Save(typeof(T).Name, aggregate, commitId);
        }
    }
}