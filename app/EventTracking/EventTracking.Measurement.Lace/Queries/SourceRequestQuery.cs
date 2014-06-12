using System;
using System.Collections.Generic;
using System.Linq;
using EventStore.ClientAPI;
using EventTracking.Domain.Read.Core;
using EventTracking.Measurement.Lace.Events;

namespace EventTracking.Measurement.Lace.Queries
{
    public class SourceRequestQuery
    {
        private readonly IEventStoreConnection _connection;

        public SourceRequestQuery(IEventStoreConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            _connection = connection;
        }

        public IEnumerable<SourceRequestsExecutionTimes> GetValues(string sourceName)
        {
            var projectionResultStream = string.Format("{0}", sourceName);

            var values = _connection.ReadStreamEventsBackward<DetailsForRequest>(projectionResultStream);

            return values
                .Select(s => new SourceRequestsExecutionTimes(s.Message, s.Source, s.AggregateId, s.EventDate))
                .Where(w => w.IsExternalSourceCall)
                .OrderBy(o => o.AggregateId)
                .ThenBy(o => o.EventDate)
                .ToList();
        }
    }
}
