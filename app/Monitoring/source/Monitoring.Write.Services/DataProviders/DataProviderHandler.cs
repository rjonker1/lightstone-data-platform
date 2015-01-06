using System;
using CommonDomain.Persistence;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderHandler : IHandleMessages<DataProviderExecutingCommand>,
        IHandleMessages<DataProviderHasBeenConfiguredCommand>,
        IHandleMessages<DataProviderHasEndedCommand>, IHandleMessages<DataProviderHasExecutedCommand>,
        IHandleMessages<DataProviderHasFaultCommand>, IHandleMessages<DataProviderHasSecurityCommand>,
        IHandleMessages<DataProviderResponseTransformedCommand>, IHandleMessages<DataProviderWasCalledCommand>
    {
        private readonly IRepository _repository;

        public DataProviderHandler()
        {
        }

        public DataProviderHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataProviderExecutingCommand message)
        {
            var @event = new MonitoringEvents(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasExecutedCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderWasCalledCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasEndedCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasFaultCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasBeenConfiguredCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasSecurityCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderResponseTransformedCommand message)
        {
            var @event = _repository.GetById<MonitoringEvents>(message.Command.Id);

            @event.Add(message.Command.Id, message.Command.Payload, message.Command.Date,
                MonitoringSource.Lace);

            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
