using System;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderMonitoringHandler : IHandleMessages<DataProviderExecutingCommand>,
        IHandleMessages<DataProviderHasBeenConfiguredCommand>,
        IHandleMessages<DataProviderHasEndedCommand>, IHandleMessages<DataProviderHasExecutedCommand>,
        IHandleMessages<DataProviderHasFaultCommand>, IHandleMessages<DataProviderHasSecurityCommand>,
        IHandleMessages<DataProviderResponseTransformedCommand>, IHandleMessages<DataProviderWasCalledCommand>
    {
        private readonly IUpdateStorage _storage;

        public DataProviderMonitoringHandler(IUpdateStorage storage)
        {
            _storage = storage;
        }

        public void Handle(DataProviderExecutingCommand message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasExecutedCommand message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderWasCalledCommand message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasEndedCommand message)
        {
            var @event = new DataProviderMonitoringPerformanceModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasBeenConfiguredCommand message)
        {
            var @event = new DataProviderMonitoringConfigurationModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }


        public void Handle(DataProviderHasFaultCommand message)
        {
            var @event = new DataProviderMonitoringFaultModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderHasSecurityCommand message)
        {
            var @event = new DataProviderMonitoringSecurityModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderResponseTransformedCommand message)
        {
            var @event = new DataProviderMonitoringTransformationModel(message.Command.Id)
            {
                Payload = message.Command.Payload,
                Message = message.Command.Message,
                DataProviderId = (int) message.Command.DataProvider,
                DataProvider = message.Command.DataProvider.ToString(),
                Category = message.Command.Category.ToString(),
                CategoryId = (int) message.Command.Category,
                Date = message.Command.Date,
                RequestAggregateId = message.Command.Id,
                IsJson = message.Command.IsJson,
                Metadata = message.Command.MetaData,
                TimeStamp = message.Command.Date
            };

            _storage.Add(@event);
        }
    }
}
