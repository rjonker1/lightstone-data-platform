using System;
using System.Collections.Generic;

namespace EventTracking.Domain.Persistence
{
    public interface IRepository
    {
        TAggregate GetById<TAggregate>(Guid id) where TAggregate : class, IAggregate;
        TAggregate GetById<TAggregate>(Guid id, int version) where TAggregate : class, IAggregate;
        TEvent[] GetStreams<TEvent>(string streamName, int pageSize) where TEvent : class;

        void Save(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders);
    }
}
