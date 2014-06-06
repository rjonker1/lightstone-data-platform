using System;

namespace EventTracking.Measurement.Lace.Events
{
    public class DetailsForRequest
    {
        public Guid Id { get;  set; }
        public Guid AggregateId { get;  set; }
        public string Source { get;  set; }
        public string Message { get;  set; }
        public DateTime EventDate { get; set; }

        public override string ToString()
        {
            return string.Format("Agg Id: {0}, Source: {1}, Message: {2}, Event Time: {3}", AggregateId, Source, Message,
                GetTime());
        }

        private string GetTime()
        {
            var time = EventDate.TimeOfDay;
            return time.ToString();
        }
    }
}
