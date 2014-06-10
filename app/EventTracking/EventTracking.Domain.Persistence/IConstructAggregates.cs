using System;

namespace EventTracking.Domain.Persistence
{
    public interface IConstructAggregates
    {
        IAggregate Build(Type type, Guid id, IMemento snapshot);
    }
}
