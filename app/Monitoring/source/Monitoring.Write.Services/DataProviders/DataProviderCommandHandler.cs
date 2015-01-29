using System;
using CommonDomain.Persistence;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderCommandHandler : IHandleMessages<ExecutingDataProviderMonitoringCommand>
    {
        private readonly IRepository _repository;

        public DataProviderCommandHandler()
        {
        }

        public DataProviderCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ExecutingDataProviderMonitoringCommand message)
        {
            var @event = _repository.GetById<MonitoringDataProvider>(message.Command.Id);

            if (@event == null || @event.Id == Guid.Empty)
            {
                @event = new MonitoringDataProvider(message.Command.Id, message.Command.Payload, message.Command.DateUtc,
                    message.Command.Source);
            }
            else
            {
                @event.Add(message.Command.Id, message.Command.Payload, message.Command.DateUtc,
                    message.Command.Source);
            }

            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
