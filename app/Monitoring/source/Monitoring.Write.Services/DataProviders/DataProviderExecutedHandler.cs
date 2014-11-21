using System;
using CommonDomain.Persistence;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderExecutedHandler : IHandleMessages<ExecutingDataProviderCommand>
    {
        private readonly IRepository _repository;

        public DataProviderExecutedHandler()
        {}

        public DataProviderExecutedHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ExecutingDataProviderCommand message)
        {
            var @event = new DataProviderStartCall(message.Id, message.DataProvider, message.Category, message.Message,
                message.Payload, message.MetaData, message.Date, message.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
