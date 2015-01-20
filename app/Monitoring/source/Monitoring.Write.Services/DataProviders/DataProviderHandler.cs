using System;
using CommonDomain.Persistence;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderHandler : IHandleMessages<DataProviderCommandEnvelope>
    {
        private readonly IRepository _repository;

        public DataProviderHandler()
        {
        }

        public DataProviderHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataProviderCommandEnvelope message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            if (@event == null || @event.Id == Guid.Empty)
            {
                @event = new MonitoringEvents(message.Command.Id, message.Command.Payload, message.Command.DateUtc,
                    message.Command.Source);
            }
            else
            {
                @event.Add(message.Command.Id, message.Command.Payload, message.Command.DateUtc,
                    MonitoringSource.Lace);
            }

            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
