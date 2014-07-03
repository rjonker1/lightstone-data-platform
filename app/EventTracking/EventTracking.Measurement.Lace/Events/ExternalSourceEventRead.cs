using System;

namespace EventTracking.Measurement.Lace.Events
{
    public class ExternalSourceEventRead : IShowEventsPublishedForLaceRequests
    {
        public Guid AggregateId { get; set; }
        public string SourceId { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return string.Format("Agg Id: {0}, Source: {1}, Message: {2}, Event Time: {3}", AggregateId, SourceId,
                Message,
                GetTime());
        }

        private string GetTime()
        {
            var time = TimeStamp.TimeOfDay;
            return time.ToString();
        }
    }
}
