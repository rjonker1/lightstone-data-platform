using Monitoring.Domain.Core.Contracts;
using Monitoring.Domain.Messages.Commands;
using Monitoring.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace Monitoring.Read.Normalizer.DataProvider
{
    public class DataProviderEventsUpdater : IHandleMessages<ExecuteDataProvider> //, IHandleMessages<DataProviderFailed>
    {
        private readonly IUpdateStorage _storage;

        public DataProviderEventsUpdater(IUpdateStorage storage)
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

        //public void Handle(DataProviderFailed message)
        //{
            
        //}
    }
}
