using Lace.Shared.Monitoring.Messages.Events;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderMonitoringHandler : IHandleMessages<DataProviderExecutingEvent>,
        IHandleMessages<DataProviderHasConfigurationEvent>,
        IHandleMessages<DataProviderCallEndedEvent>, IHandleMessages<DataProviderHasExecutedEvent>,
        IHandleMessages<DataProviderHasFaultEvent>, IHandleMessages<DataProviderHasSecurityEvent>,
        IHandleMessages<DataProviderasBeenTransformedEvent>, IHandleMessages<DataProviderIsCalledEvent>
    {
        private readonly IAccessToStorage _storage;

        public DataProviderMonitoringHandler(IAccessToStorage storage)
        {
            _storage = storage;
        }

        public void Handle(DataProviderExecutingEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }

        public void Handle(DataProviderHasExecutedEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }

        public void Handle(DataProviderIsCalledEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }

        public void Handle(DataProviderCallEndedEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }

        public void Handle(DataProviderHasConfigurationEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }


        public void Handle(DataProviderHasFaultEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }

        public void Handle(DataProviderHasSecurityEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }

        public void Handle(DataProviderasBeenTransformedEvent message)
        {
            var model = new MonitoringDataProviderModel(message.RequestAggregateId)
            {
                Payload = message.Payload,
                Message = message.Message,
                DataProviderId = message.DateProviderId,
                DataProvider = message.DataProvider,
                Category = message.Category,
                CategoryId = message.CategoryId,
                Date = message.Date,
                RequestAggregateId = message.RequestAggregateId,
                IsJson = message.IsJson,
                Metadata = message.Metadata,
                TimeStamp = message.Date
            };

            _storage.Add(model);
        }
    }
}
