using EventTracking.Domain.Core.Contracts;
using EventTracking.Domain.Messages.Commands;
using EventTracking.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace EventTracking.Read.Normalizer.Handlers.ForDataProviders
{
    public class DataProviderEventsHandler : IHandleMessages<ExecuteDataProvider>
    {
        private readonly IUpdateStorage _storage;

        public DataProviderEventsHandler(IUpdateStorage storage)
        {
            _storage = storage;
        }

        public void Handle(ExecuteDataProvider message)
        {
            var @event = new EventForDataProviderModel(message.Id)
            {
                Payload = message.Message,
                DataProviderId = message.DataProviderId,
                TimeStamp = message.Date
            };

            _storage.Add(@event);
        }
    }
}
