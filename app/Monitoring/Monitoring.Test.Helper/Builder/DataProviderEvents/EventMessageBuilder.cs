using System;
using Monitoring.Domain.Core.Constants;
using Monitoring.Domain.Core.Consumers;
using Monitoring.Domain.Messages.Events;

namespace Monitoring.Test.Helper.Builder.DataProviderEvents
{
    public class EventMessageBuilder
    {
        public static DataProviderExecuted DataProviderExecutedEvent()
        {
            return new DataProviderExecuted(Guid.NewGuid(), (int) DataProvider.Audatex,
                DefinedMessages.StartCallingDataProvider, DateTime.UtcNow);
        }
    }

    //[Serializable]
    //public class DataProviderExecutedMessage : DataProviderExecuted
    //{
    //    public Guid Id { get; set; }

    //    public Guid AggregateId { get; set; }

    //    public int DataProviderId { get; set; }

    //    public string Message { get; set; }

    //    public DateTime Date { get; set; }


    //}
}
