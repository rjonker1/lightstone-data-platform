using System;
using CommonDomain.Core;
using Monitoring.Domain.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class DataProviderExecution : AggregateBase
    {
        private DataProviderExecution(Guid id)
        {
            Id = id;
            Register<DataProviderExecutingStartingEvent>(e => Id = id);
        }

        public DataProviderExecution(Guid id, int dataProvider, string message, DateTime date)
            : this(id)
        {
            RaiseEvent(new DataProviderExecutingStartingEvent(id, dataProvider, message, date));
        }
    }
}
