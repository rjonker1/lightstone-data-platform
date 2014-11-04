using Monitoring.Domain.Core.Contracts;
using Monitoring.Domain.Messages.Events;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderEventsUpdater : IHandleMessages<DataProviderExecuted>, IHandleMessages<DataProviderFailed>
    {
        private IUpdateStorage _storage;

        public DataProviderEventsUpdater(IUpdateStorage storage)
        {
            _storage = storage;
        }


        public void Handle(DataProviderExecuted message)
        {
            var @event = new DataProviderEve
        }

        public void Handle(DataProviderFailed message)
        {
            
        }
    }
}
