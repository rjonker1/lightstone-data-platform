using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using NEventStore;

namespace PackageBuilder.Core.Helpers.Cqrs.NEventStore
{
    public interface IRepository<T> : IRepository
    {
        T GetById(Guid id);
        T GetById(Guid id, int version);
        void Save(IAggregate aggregate, Guid commitId);
    }

    public class NEventStoreRepository<T> : EventStoreRepository, IRepository<T> where T : AggregateBase
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
            return GetById<T>(typeof(T).Name, id, version);
        }

        public void Save(IAggregate aggregate, Guid commitId)
        {
            this.Save(typeof(T).Name, aggregate, commitId);
        }
    }
}
