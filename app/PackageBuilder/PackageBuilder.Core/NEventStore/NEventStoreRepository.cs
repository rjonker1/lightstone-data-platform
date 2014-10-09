using System;
using System.Runtime.Remoting.Messaging;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using MemBus.Support;
using NEventStore;
using Raven.Abstractions;

namespace PackageBuilder.Core.NEventStore
{
    public interface INEventStoreRepository<T> : IRepository
    {
        T GetById(Guid id);
        T GetById(Guid id, int version);
        void Save(IAggregate aggregate, Guid commitId);
    }

    public class NEventStoreRepository<T> : EventStoreRepository, INEventStoreRepository<T> where T : AggregateBase
    {
        public NEventStoreRepository(IStoreEvents eventStore, IConstructAggregates factory, IDetectConflicts conflictDetector)
            : base(eventStore, factory, conflictDetector)
        {
        }

        public T GetById(Guid id)
        {
            return GetById<T>(typeof(T).Name, id);
        }

        public T GetById(Guid id, int version)
        {
            return GetById<T>(typeof (T).Name, id, version);
        }

        public void Save(IAggregate aggregate, Guid commitId)
        {
            this.Save(typeof(T).Name, aggregate, commitId);
        }
    }
}
