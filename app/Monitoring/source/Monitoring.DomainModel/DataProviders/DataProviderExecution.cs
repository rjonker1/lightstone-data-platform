using System;
using CommonDomain.Core;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class DataProviderExecutingAggregate : AggregateBase
    {
        private DataProviderExecutingAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderExecutingEvent>(e => Id = id);
        }

        public DataProviderExecutingAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderExecutingEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderHasExecutedAggregate : AggregateBase
    {
        private DataProviderHasExecutedAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderHasExecutedEvent>(e => Id = id);
        }

        public DataProviderHasExecutedAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderHasExecutedEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderIsBeingCalledAggregate : AggregateBase
    {
        private DataProviderIsBeingCalledAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderIsCalledEvent>(e => Id = id);
        }

        public DataProviderIsBeingCalledAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderIsCalledEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderHasBeenCalledAggregate : AggregateBase
    {
        private DataProviderHasBeenCalledAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderCallEndedEvent>(e => Id = id);
        }

        public DataProviderHasBeenCalledAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderCallEndedEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderFaultAggregate : AggregateBase
    {
        private DataProviderFaultAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderHasFaultEvent>(e => Id = id);
        }

        public DataProviderFaultAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderHasFaultEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderConfigurationAggregate : AggregateBase
    {
        private DataProviderConfigurationAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderHasConfigurationEvent>(e => Id = id);
        }

        public DataProviderConfigurationAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderHasConfigurationEvent(id, dataProvider, category, message, payload, metadata, date,
                isJson));
        }
    }

    public class DataProviderSecurityAggregate : AggregateBase
    {
        private DataProviderSecurityAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderHasSecurityEvent>(e => Id = id);
        }

        public DataProviderSecurityAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderHasSecurityEvent(id, dataProvider, category, message, payload, metadata, date,
                isJson));
        }
    }

    public class DataProviderTransformationAggregate : AggregateBase
    {
        private DataProviderTransformationAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderasBeenTransformedEvent>(e => Id = id);
        }

        public DataProviderTransformationAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderasBeenTransformedEvent(id, dataProvider, category, message, payload, metadata,
                date,
                isJson));
        }
    }
}
