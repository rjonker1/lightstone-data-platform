using System;

namespace Monitoring.Domain.Messages.Commands
{
    [Serializable]
    public class ExecuteDataProvider
    {
        public Guid Id { get; private set; }
        public int DataProviderId { get; private set; }
        public string Message { get; private set; }
        public string Payload { get; private set; }
        public DateTime Date { get; private set; }

        public ExecuteDataProvider()
        {
            
        }

        public ExecuteDataProvider(Guid id, int dataProviderId, string message, string payload, DateTime date)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Message = message;
            Payload = payload;
            Date = date;
        }
    }
}
