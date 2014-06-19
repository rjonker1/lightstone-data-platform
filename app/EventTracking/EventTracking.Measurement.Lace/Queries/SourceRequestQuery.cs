using System;
using System.Collections.Generic;
using EventStore.ClientAPI;
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

        public IEnumerable<EventsPublishedForLaceRequests> GetValues(string sourceName)
        {
            var projectionResultStream = string.Format("{0}", sourceName);

            return _connection.ReadStreamEventsBackward<EventsPublishedForLaceRequests>(projectionResultStream);
        }
    }
}
