using System;
using System.Collections.Generic;

namespace EventTracking.Domain.Persistence
{
    public interface IRepository
    {
        void Write(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders);
    }
}
