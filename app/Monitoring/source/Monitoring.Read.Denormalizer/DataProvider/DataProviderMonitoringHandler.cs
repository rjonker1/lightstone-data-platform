using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderMonitoringHandler : IHandleMessages<ExecutingDataProviderCommand> //, IHandleMessages<DataProviderFailed>
    {
        private readonly IUpdateStorage _storage;

        public DataProviderMonitoringHandler(IUpdateStorage storage)
        {
            _storage = storage;
        }

        public void Handle(ExecutingDataProviderCommand message)
        {
            var @event = new DataProviderMonitoringModel(message.Id)
            {
                Payload = message.Message,
                DataProviderId = (int)message.DataProvider,
                DataProvider = message.DataProvider.ToString(),
                Category = message.Category.ToString(),
                CategoryId = (int)message.Category,
                Date = message.Date,
                RequestAggregateId = message.Id,
                IsJson = message.IsJson,
                Metadata = message.MetaData,
                TimeStamp = message.Date
            };

            _storage.Add(@event);
        }

    }
}
