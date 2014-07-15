using System;
using EventTracking.Domain;
using EventTracking.Domain.Persistence;
using EventTracking.Tests.Helper.Fakes.EventStore;

namespace EventTracking.Tests.Helper.Fakes.Persistence
{
    public class FakePersistEvent : IPersistAnEvent
    {
        public void Save(IAggregate aggregate)
        {
            var repostiory = new EventStorePersistRepository();
            repostiory.Write(aggregate, Guid.NewGuid(), d => { });
        }
    }
}
