using Monitoring.Domain.Core.Contracts;
using Monitoring.Domain.Messages.Events;
using Monitoring.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderEventsUpdater : IHandleMessages<DataProviderExecuted>, IHandleMessages<DataProviderFailed>
    {
        private readonly IUpdateStorage _storage;

        public DataProviderEventsUpdater(IUpdateStorage storage)
        {
            _storage = storage;
        }

        public void Handle(DataProviderExecuted message)
        {
            var @event = new DataProviderEvent(message.Id)
            {
                Payload = message.Message,
                Source = message.DataProviderId,
                TimeStamp = message.Date
            };

            _storage.Add(@event);
        }

        public void Handle(DataProviderFailed message)
        {
            
        }
    }
}
