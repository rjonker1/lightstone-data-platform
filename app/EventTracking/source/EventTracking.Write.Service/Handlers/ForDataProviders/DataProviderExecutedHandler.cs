using System;
using CommonDomain.Persistence;
using EventTracking.Domain.Messages.Commands;
using EventTracking.Write.DomainModel.DataProviders;
using NServiceBus;

namespace EventTracking.Write.Service.Handlers.ForDataProviders
{
    public class DataProviderExecutedHandler : IHandleMessages<ExecuteDataProvider>
    {
        private readonly IRepository _repository;

        public DataProviderExecutedHandler()
        {
        }

        public DataProviderExecutedHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ExecuteDataProvider message)
        {
            var @event = new DataProviderExecutionAggregate(message.Id, message.DataProviderId, message.Message,
                message.Date);
            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
