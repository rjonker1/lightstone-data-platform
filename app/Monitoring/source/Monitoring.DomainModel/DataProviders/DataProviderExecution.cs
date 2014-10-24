using System;
using CommonDomain.Core;
using Monitoring.Domain.Messages;
using Monitoring.Domain.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class DataProviderExecution : AggregateBase
    {
        private DataProviderExecution(Guid id)
        {
            Id = id;
            Register<DataProviderExecuted>(e => Id = id);
        }

        public DataProviderExecution(Guid id, int dataProvider, string message, DateTime date)
            : this(id)
        {
            RaiseEvent(new DataProviderExecuted(id, dataProvider, message, date));
        }
    }
}
