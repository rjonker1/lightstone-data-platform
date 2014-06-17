using System;
using Monitoring.Sources.Lace;

namespace EventTracking.Measurement.Lace.Results
{
    public class SourceRequestsExecutionTimes
    {
        public string Message { get; private set; }

        public string Source
        {
            get
            {
                int id;
                return !int.TryParse(_sourceId, out id)
                    ? _sourceId
                    : string.Format("{0} {1}", _sourceId, ((LaceEventSource) id));
            }
        }

        public Guid AggregateId { get; private set; }
        public DateTime EventDate { get; private set; }
        public bool IsExternalSourceCall { get; private set; }


        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }

        private readonly string _sourceId;

        public SourceRequestsExecutionTimes(){}

        public SourceRequestsExecutionTimes(string message, string source, Guid aggregateId, DateTime eventDate)
        {
            Message = message;
            _sourceId = source;
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
                    "Source:  {0}, Message: {1}, Aggregate Id {2}, Event Date: {3}", Source,
                    Message, AggregateId, EventDate); //Start Time {4}, End Time {5}  , StartTime, EndTime
        }
    }
}
