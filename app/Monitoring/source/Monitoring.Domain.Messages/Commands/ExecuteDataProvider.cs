using System;

namespace Monitoring.Domain.Messages.Commands
{
    [Serializable]
    public class ExecuteDataProvider
    {
        public readonly Guid Id;
        public readonly int DataProviderId;
        public readonly string Message;
        public readonly DateTime Date;

        //public Guid Id { get; set; }
        //public int DataProviderId { get; set; }
        //public string Message { get; set; }
        //public DateTime Date { get; set; }

        public ExecuteDataProvider()
        {
            
        }

        public ExecuteDataProvider(Guid id, int dataProviderId, string message, DateTime date)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Message = message;
            Date = date;
        }
    }
}
