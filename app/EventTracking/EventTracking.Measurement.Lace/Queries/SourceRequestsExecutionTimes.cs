using System;
using Monitoring.Sources.Lace;

namespace EventTracking.Measurement.Lace.Queries
{
    public class SourceRequestsExecutionTimes
    {
        public string Message { get; private set; }
        public string Source { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime EventDate { get; private set; }
        public bool IsExternalSourceCall { get; private set; }


        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }


        public SourceRequestsExecutionTimes(){}

        public SourceRequestsExecutionTimes(string message, string source, Guid aggregateId, DateTime eventDate)
        {
            Message = message;
            Source = source;
            EventDate = eventDate;
            AggregateId = aggregateId;

            SetStartTime();
            SetEndTime();
        }

        private void SetEndTime()
        {
            if (Message != PublishableLaceMessages.StartCallingExternalSource()) return;

            IsExternalSourceCall = true;
            StartTime = EventDate;
        }

        private void SetStartTime()
        {
            if (Message != PublishableLaceMessages.EndCallingExternalSource()) return;

            IsExternalSourceCall = true;
            EndTime = EventDate;
        }

        
        public override string ToString()
        {
            return
                string.Format(
                    "Source:  {0}, Message: {1}, Aggregate Id {2}, Start Time {3}, End Time {4}", Source,
                    Message, AggregateId, StartTime, EndTime);
        }
    }
}
