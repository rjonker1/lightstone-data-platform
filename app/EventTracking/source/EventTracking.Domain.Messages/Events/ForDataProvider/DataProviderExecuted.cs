using System;
using EventTracking.Domain.Messages.Events.Contracts;

namespace EventTracking.Domain.Messages.Events.ForDataProvider
{
    [Serializable]
    public class DataProviderExecutedEvent : IDataProviderEvent
    {
        public readonly Guid Id;
        public readonly int DataProviderId;
        public readonly string Message;
        public readonly DateTime Date;

        public DataProviderExecutedEvent()
        {

        }

        public DataProviderExecutedEvent(Guid id, int dataProviderId, string message, DateTime date)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Message = message;
            Date = date;
        }
    }
}
