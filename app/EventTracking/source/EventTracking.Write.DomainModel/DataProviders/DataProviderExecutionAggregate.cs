using System;
using CommonDomain.Core;
using EventTracking.Domain.Messages.Events.ForDataProvider;

namespace EventTracking.Write.DomainModel.DataProviders
{
    public class DataProviderExecutionAggregate : AggregateBase
    {
        private DataProviderExecutionAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderExecutedEvent>(e => Id = id);
        }

        public DataProviderExecutionAggregate(Guid id, int dataProvider, string message, DateTime date)
            : this(id)
        {
            RaiseEvent(new DataProviderExecutedEvent(id, dataProvider, message, date));
        }
    }
}