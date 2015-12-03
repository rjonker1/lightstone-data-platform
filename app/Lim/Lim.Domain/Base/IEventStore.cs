using System.Collections.Generic;

namespace Lim.Domain.Base
{
    public interface IEventStore
    {
        void SaveEvents(long aggregateId, IEnumerable<LimEvent> events, int version);
        List<LimEvent> GetEventsForAggregate(long aggregateId);
    }
}
