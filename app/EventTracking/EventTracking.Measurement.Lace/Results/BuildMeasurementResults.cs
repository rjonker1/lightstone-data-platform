using System;
using System.Collections.Generic;
using System.Linq;
using EventTracking.Measurement.Lace.Events;

namespace EventTracking.Measurement.Lace.Results
{
    public class BuildMeasurementResults
    {
        public static Func<IEnumerable<IShowEventsPublishedForLaceRequests>, IEnumerable<SourceRequestsExecutionTimes>>
            ForSourceExecutionTimes = (results) => GetSourceExecutionTimes(results);


        private static IEnumerable<SourceRequestsExecutionTimes> GetSourceExecutionTimes(
            IEnumerable<IShowEventsPublishedForLaceRequests> projectionResults)
        {
            var slicedValues = projectionResults
                .Select(s => new SourceRequestsExecutionTimes(s.Message, s.SourceId, s.AggregateId, s.EventDate))
                .OrderBy(o => o.AggregateId)
                .ThenBy(o => o.EventDate)
                .ToList();

            return slicedValues;
        }
    }
}
