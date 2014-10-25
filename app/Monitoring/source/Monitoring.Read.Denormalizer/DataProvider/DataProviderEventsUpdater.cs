using System;
using Monitoring.Domain.Messages.Events;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderEventsUpdater : IHandleMessages<DataProviderExecuted>, IHandleMessages<DataProviderFailed>
    {
        public void Handle(DataProviderExecuted message)
        {
            throw new NotImplementedException();
        }

        public void Handle(DataProviderFailed message)
        {
            throw new NotImplementedException();
        }
    }
}
