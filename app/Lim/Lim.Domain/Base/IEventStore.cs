using System;
using System.Collections.Generic;

namespace Lim.Domain.Base
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<LimEvent> events, long version);
        List<LimEvent> GetEventsForAggregate(Guid aggregateId);
    }
}
