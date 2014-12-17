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
            var @event = new DataProviderAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasExecutedCommand message)
        {
            //var @event = new DataProviderAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderWasCalledCommand message)
        {
            //var @event = new DataProviderAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasEndedCommand message)
        {
            //var @event = new DataProviderAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category, message.Command.Message,
            //    message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            //_repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasFaultCommand message)
        {
            var @event = new DataProviderFaultAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category,
                message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasBeenConfiguredCommand message)
        {
            var @event = new DataProviderConfigurationAggregate(message.Command.Id, message.Command.DataProvider, message.Command.Category,
                message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderHasSecurityCommand message)
        {
            var @event = new DataProviderSecurityAggregate(message.Command.Id, message.Command.DataProvider,
                message.Command.Category,
                message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderResponseTransformedCommand message)
        {
            var @event = new DataProviderTransformationAggregate(message.Command.Id, message.Command.DataProvider,
                message.Command.Category,
                message.Command.Message,
                message.Command.Payload, message.Command.MetaData, message.Command.Date, message.Command.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
