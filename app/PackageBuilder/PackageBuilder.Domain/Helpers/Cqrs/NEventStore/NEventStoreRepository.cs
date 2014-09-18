using System;
using CommonDomain;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using NEventStore;

namespace PackageBuilder.Domain.Helpers.Cqrs.NEventStore
{
    public interface IRepository<T> : IRepository
    {
        void Save(IAggregate aggregate, Guid commitId);
    }

    public class NEventStoreRepository<T> : EventStoreRepository, IRepository<T>
    {
        public NEventStoreRepository(IStoreEvents eventStore, IConstructAggregates factory, IDetectConflicts conflictDetector) : base(eventStore, factory, conflictDetector)
        {
        }

        public void Save(IAggregate aggregate, Guid commitId)
        {
            this.Save(typeof(T).Name, aggregate, commitId);
        }
    }
}