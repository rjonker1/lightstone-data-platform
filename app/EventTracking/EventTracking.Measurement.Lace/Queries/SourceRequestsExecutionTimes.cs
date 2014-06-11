using System;

namespace EventTracking.Measurement.Lace.Queries
{
    public class SourceRequestsExecutionTimes
    {
        public string Message { get; private set; }
        public string Source { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime EventDate { get; private set; }
        public int Order { get; private set; }
        public bool IsWebServiceCall { get; private set; }

       // private string _executionTimeInSeconds;


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
            if (Message != "Starting External Web Service Call") return;

            SetTime(0);

        }

        private void SetStartTime()
        {
            if (Message != "End External Web Service Call") return;

            SetTime(1);
        }

        private void SetTime(int order)
        {
            EndTime = EventDate;
            Order = order;
            IsWebServiceCall = true;
        }

        //private static string SetExecutionTime(DateTime? startTime, DateTime? endTime)
        //{
        //    if (!startTime.HasValue || !endTime.HasValue) return string.Empty;

        //    var time = (endTime.Value.TimeOfDay - startTime.Value.TimeOfDay).TotalSeconds;

        //    return time.ToString("N");
        //}



        //public SourceRequestsExecutionTimes(string message, string source, Guid aggregateId, DateTime startTime, DateTime endTime)
        //{
        //    Message = message;
        //    Source = source;
        //    AggregateId = aggregateId;

        //    GetExecutionTimes(startTime, endTime);
        //}


        public override string ToString()
        {
            return
                string.Format(
                    "Source:  {0}, Message: {1}, Aggregate Id {2}, Start Time {3}, End Time {4}", Source,
                    Message, StartTime, EndTime);
        }

    }
}
