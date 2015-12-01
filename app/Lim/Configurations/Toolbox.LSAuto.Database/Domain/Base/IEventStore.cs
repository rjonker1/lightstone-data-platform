using System;
using System.Collections.Generic;

namespace Toolbox.LightstoneAuto.Database.Domain.Base
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int version);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}
