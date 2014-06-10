using System;

namespace EventTracking.Measurement.Lace.Queries
{
    public class SourceRequestsExecutionTimes
    {
        public string Message  { get; private set; }
        public string Source { get; private set; }
        public Guid AggregateId { get; private set; }
        public string ExecutionTime { get; private set; }

        public SourceRequestsExecutionTimes()
        {
        }

        public SourceRequestsExecutionTimes(string message, string source, Guid aggregateId, DateTime startTime, DateTime endTime)
        {
            Message = message;
            Source = source;
            AggregateId = aggregateId;

            GetExecutionTimes(startTime, endTime);
        }

        private void GetExecutionTimes(DateTime? startTime, DateTime? endTime)
        {
            if (!startTime.HasValue || !endTime.HasValue) ExecutionTime = "00:00:00";

            var time = (endTime.Value.TimeOfDay - startTime.Value.TimeOfDay).TotalSeconds;

            ExecutionTime = time.ToString("N");
        }

      
        public override string ToString()
        {
            return string.Format("Source:  {0}, Message: {1}, Aggregate Id {2}, Time Taken {3}", Source, Message, ExecutionTime);
        }

    }
}
