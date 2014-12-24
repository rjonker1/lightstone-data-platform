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
        private readonly IUpdateStorage _storage;

        public DataProviderMonitoringHandler(IUpdateStorage storage)
        {
            _storage = storage;
        }

        public void Handle(DataProviderExecutingEvent message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasExecutedEvent message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }

        public void Handle(DataProviderIsCalledEvent message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }

        public void Handle(DataProviderCallEndedEvent message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasConfigurationEvent message)
        {
            var @event = new DataProviderMonitoringConfigurationModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }


        public void Handle(DataProviderHasFaultEvent message)
        {
            var @event = new DataProviderMonitoringFaultModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasSecurityEvent message)
        {
            var @event = new DataProviderMonitoringSecurityModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }

        public void Handle(DataProviderasBeenTransformedEvent message)
        {
            var @event = new DataProviderMonitoringTransformationModel(message.RequestAggregateId)
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

            _storage.Add(@event);
        }
    }
}
