﻿using System;
using CommonDomain.Persistence;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class IvidMonitoringHandler : IHandleMessages<StartIvidExecution>, IHandleMessages<EndIvidExcution>,
        IHandleMessages<StartIvidDataSourceCall>, IHandleMessages<EndIvidDataSourceCall>,
        IHandleMessages<RaiseIvidSecurityFlag>, IHandleMessages<ConfigureIvid>, IHandleMessages<TrasformIvidResponse>, IHandleMessages<ThrowError>
    {

        private readonly IRepository _repository;

        public IvidMonitoringHandler()
        {
        }

        public IvidMonitoringHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(StartIvidExecution message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(EndIvidExcution message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(StartIvidDataSourceCall message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(EndIvidDataSourceCall message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(RaiseIvidSecurityFlag message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(ConfigureIvid message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(TrasformIvidResponse message)
        {
            var @event = IvidMonitoringEvent(message.Id);
            if ((@event == null || @event.Id == Guid.Empty))
                new IvidMonitoringEvents(message).Apply(message);
            else
                @event.Apply(message);

            Save(@event);
        }

        public void Handle(ThrowError message)
        {
            //var @event = IvidMonitoringEvent(message.Id);
            //if ((@event == null || @event.Id == Guid.Empty))
            //    new IvidMonitoringEvents(message).Apply(message);
            //else
            //    @event.Apply(message);

            //Save(@event);
        }

        private IvidMonitoringEvents IvidMonitoringEvent(Guid id)
        {
            return _repository.GetById<IvidMonitoringEvents>(id);
        }

        private void Save(IvidMonitoringEvents @event)
        {
            _repository.Save(@event, Guid.NewGuid(), null);
        }

       
    }
}
