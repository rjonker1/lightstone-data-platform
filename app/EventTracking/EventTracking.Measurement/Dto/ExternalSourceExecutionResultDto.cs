using System;
using Monitoring.Sources.Lace;

namespace EventTracking.Measurement.Dto
{
    public class ExternalSourceExecutionResultDto
    {
        public Guid AggregateId { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string Source { get; private set; }
        public string Message { get; private set; }
        
        public DateTime? ExecutionStartTime { get; private set; }
        public DateTime? ExecutionEndTime { get; private set; }

        public int Order { get; private set; }

        public ExternalSourceExecutionResultDto(Guid aggregateId, DateTime timeStamp, int source, string message,
            int order)
        {
            AggregateId = aggregateId;
            TimeStamp = timeStamp;
            Source = ((LaceEventSource) source).ToString();
            Message = message;
            Order = order;

            ExecutionStartTime = order == 1 ? timeStamp : (DateTime?) null;
            ExecutionEndTime = order == 2 ? timeStamp : (DateTime?) null;
        }
    }
}
