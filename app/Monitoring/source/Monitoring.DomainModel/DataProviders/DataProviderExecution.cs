using System;
using CommonDomain.Core;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class DataProviderStartCall : AggregateBase
    {
        private DataProviderStartCall(Guid id)
        {
            Id = id;
            Register<DataProviderCallStarted>(e => Id = id);
        }

        public DataProviderStartCall(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderCallStarted(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderEndCall : AggregateBase
    {
        private DataProviderEndCall(Guid id)
        {
            Id = id;
            Register<DataProviderCallEnded>(e => Id = id);
        }

        public DataProviderEndCall(Guid id, DataProvider dataProvider, Category category, string message, string payload,
            string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderCallEnded(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }
}
