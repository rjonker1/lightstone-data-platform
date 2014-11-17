using System;

namespace Monitoring.Domain.Messages.Events
{
    [Serializable]
    public class DataProviderExecutingStartingEvent : IDataProviderMonitoringEvent
    {
        public readonly Guid Id;
        public readonly int DataProviderId;
        public readonly string Message;
        public readonly DateTime Date = DateTime.UtcNow;

        public DataProviderExecutingStartingEvent()
        {
            
        }

        public DataProviderExecutingStartingEvent(Guid id, int dataProviderId, string message, DateTime date)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Message = message;
            Date = date;
        }
    }
}
