using System;
using CommonDomain.Core;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class DataProviderAggregate : AggregateBase
    {
        private DataProviderAggregate(Guid id)
        {
            Id = id;
            Register<DataProviderEvent>(e => Id = id);
        }

        public DataProviderAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new DataProviderEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderFaultAggregate : AggregateBase
    {
        private DataProviderFaultAggregate(Guid id)
        {
            Id = id;
            Register<FaultInDataProviderEvent>(e => Id = id);
        }

        public DataProviderFaultAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new FaultInDataProviderEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderConfigurationAggregate : AggregateBase
    {
        private DataProviderConfigurationAggregate(Guid id)
        {
            Id = id;
            Register<ConfigurationInDataProviderEvent>(e => Id = id);
        }

        public DataProviderConfigurationAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new ConfigurationInDataProviderEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderSecurityAggregate : AggregateBase
    {
        private DataProviderSecurityAggregate(Guid id)
        {
            Id = id;
            Register<SecurityInDataProviderEvent>(e => Id = id);
        }

        public DataProviderSecurityAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new SecurityInDataProviderEvent(id, dataProvider, category, message, payload, metadata, date, isJson));
        }
    }

    public class DataProviderTransformationAggregate : AggregateBase
    {
        private DataProviderTransformationAggregate(Guid id)
        {
            Id = id;
            Register<TransformationInDataProviderEvent>(e => Id = id);
        }

        public DataProviderTransformationAggregate(Guid id, DataProvider dataProvider, Category category, string message,
            string payload, string metadata, DateTime date, bool isJson)
            : this(id)
        {
            RaiseEvent(new TransformationInDataProviderEvent(id, dataProvider, category, message, payload, metadata, date,
                isJson));
        }
    }
}
