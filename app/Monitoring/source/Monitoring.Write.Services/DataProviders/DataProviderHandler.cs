using System;
using CommonDomain.Persistence;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderHandler : IHandleMessages<DataProviderExecutingCommand>, IHandleMessages<DataProviderHasBeenConfiguredCommand>,
        IHandleMessages<DataProviderHasEndedCommand>, IHandleMessages<DataProviderHasExecutedCommand>,
        IHandleMessages<DataProviderHasFaultCommand>, IHandleMessages<DataProviderHasSecurityCommand>, IHandleMessages<DataProviderResponseTransformedCommand>, IHandleMessages<DataProviderWasCalledCommand>
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
            var @event = new DataProviderFromLace(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasExecutedCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.Executed(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);

            //var @event = new DataProviderHasExecutedAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderWasCalledCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.Calling(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
          
            //var @event = new DataProviderIsBeingCalledAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasEndedCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.Called(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
            //var @event = new DataProviderHasBeenCalledAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasFaultCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.FaultHappened(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
            //var @event = new DataProviderFaultAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category,
            //    message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasBeenConfiguredCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.Configured(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
            //var @event = new DataProviderConfigurationAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category,
            //    message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasSecurityCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.SecurityApplied(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderResponseTransformedCommand message)
        {
            var @event = _repository.GetById<DataProviderFromLace>(message.Command.Id);

            @event.ResponseTransformed(message.Command.Id, message.Command.DataProvider, message.Command.Category,
                message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);

            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
