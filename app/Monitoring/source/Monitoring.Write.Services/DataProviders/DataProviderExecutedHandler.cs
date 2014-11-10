using System;
using CommonDomain.Persistence;
using Monitoring.Domain.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderExecutedHandler : IHandleMessages<ExecuteDataProvider>
    {
        private readonly IRepository _repository;

        public DataProviderExecutedHandler()
        {}

        public DataProviderExecutedHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ExecuteDataProvider message)
        {
            var @event = new DataProviderExecution(message.Id, message.DataProviderId, message.Message, message.Date);
            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
