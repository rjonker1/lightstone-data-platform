using System;

namespace Monitoring.Domain.Messages.Events
{
    [Serializable]
    public class DataProviderExecuted : IDataProviderEvent
    {
        public readonly Guid Id;
        // public readonly Guid AggregateId;
        public readonly int DataProviderId;
        public readonly string Message;
        public readonly DateTime Date;

        public DataProviderExecuted()
        {
            
        }

        public DataProviderExecuted(Guid id, int dataProviderId, string message, DateTime date)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Message = message;
            Date = date;
        }
    }
}
