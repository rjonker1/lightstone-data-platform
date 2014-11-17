using System;

namespace Monitoring.Domain.Messages.Events
{
    [Serializable]
    public class DataProviderExecutingEndingEvent : IDataProviderMonitoringEvent
    {
        public readonly Guid Id;
        public readonly int DataProviderId;
        public readonly string Message;
        public readonly DateTime Date;

        public DataProviderExecutingEndingEvent()
        {

        }

        public DataProviderExecutingEndingEvent(Guid id, int dataProviderId, string message, DateTime date)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Message = message;
            Date = date;
        }
    }
}
