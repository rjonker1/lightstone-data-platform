using System;
using EventTracking.Domain;
using EventTracking.Domain.Persistence;
using Monitoring.Test.Helper.Fakes.EventStore;

namespace Monitoring.Test.Helper.Fakes
{
    public class FakePersistEvent : IPersistAnEvent
    {
        public void Save(IAggregate aggregate)
        {
            var repostiory = new FakeEventStoreRepository();
            repostiory.Write(aggregate, Guid.NewGuid(), d => { });
        }
    }
}
