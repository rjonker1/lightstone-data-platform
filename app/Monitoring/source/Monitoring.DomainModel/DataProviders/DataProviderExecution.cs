using System;
using CommonDomain.Core;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class DataProviderFromLace : AggregateBase
    {
        private DataProviderFromLace(Guid id)
        {
            Id = id;
            Register<DataProviderExecutingEvent>(e => Id = id);
            Register<DataProviderHasExecutedEvent>(e => Id = id);
            Register<DataProviderIsCalledEvent>(e => Id = id);
            Register<DataProviderCallEndedEvent>(e => Id = id);
            Register<DataProviderCallEndedEvent>(e => Id = id);
            Register<DataProviderHasFaultEvent>(e => Id = id);
            Register<DataProviderHasConfigurationEvent>(e => Id = id);
            Register<DataProviderHasSecurityEvent>(e => Id = id);
            Register<DataProviderasBeenTransformedEvent>(e => Id = id);
        }

        public DataProviderFromLace(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderExecutingEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
        
        public void Executed(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderHasExecutedEvent(Id, dataProvider, category, message, payload, metadata, date, isJson));
        }

        public void Calling(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderIsCalledEvent(Id, dataProvider, category, message, payload, metadata, date, isJson));
        }

        public void Called(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderCallEndedEvent(Id, dataProvider, category, message, payload, metadata, date, isJson));
        }

        public void FaultHappened(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderHasFaultEvent(Id, dataProvider, category, message, payload, metadata, date, isJson));
        }

        public void Configured(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderHasConfigurationEvent(Id, dataProvider, category, message, payload, metadata, date,
                isJson));
        }

        public void SecurityApplied(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderHasSecurityEvent(Id, dataProvider, category, message, payload, metadata, date,
               isJson));
        }

        public void ResponseTransformed(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
        {
            RaiseEvent(new DataProviderasBeenTransformedEvent(Id, dataProvider, category, message, payload, metadata,
               date,
               isJson));
        }
    }
}
