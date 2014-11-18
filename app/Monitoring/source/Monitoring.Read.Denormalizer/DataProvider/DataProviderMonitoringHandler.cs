using Monitoring.Domain.Core.Contracts;
using Monitoring.Domain.Messages.Commands;
using Monitoring.Read.ReadModel.Models.DataProviders;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProvider
{
    public class DataProviderMonitoringHandler : IHandleMessages<ExecuteDataProviderCommand> //, IHandleMessages<DataProviderFailed>
    {
        private readonly IUpdateStorage _storage;

        public DataProviderMonitoringHandler(IUpdateStorage storage)
        {
            _storage = storage;
        }

        public void Handle(ExecuteDataProviderCommand message)
        {
            var @event = new DataProviderMonitoringModel(message.Id)
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
