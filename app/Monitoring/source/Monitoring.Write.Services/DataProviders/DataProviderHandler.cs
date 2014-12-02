using System;
using CommonDomain.Persistence;
using Lace.Shared.Monitoring.Messages.Commands;
using Monitoring.DomainModel.DataProviders;
using NServiceBus;

namespace Monitoring.Write.Service.DataProviders
{
    public class DataProviderHandler : IHandleMessages<DataProviderCommand>, IHandleMessages<DataProviderFaultCommand>,
        IHandleMessages<DataProviderConfigurationCommand>, IHandleMessages<DataProviderSecurityCommand>,
        IHandleMessages<DataProviderTransformationCommand>
    {
        private readonly IRepository _repository;

        public DataProviderHandler()
        {
        }

        public DataProviderHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DataProviderCommand message)
        {
            var @event = new DataProviderAggregate(message.Id, message.DataProvider, message.Category, message.Message,
                message.Payload, message.MetaData, message.Date, message.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderFaultCommand message)
        {
            var @event = new DataProviderFaultAggregate(message.Id, message.DataProvider, message.Category,
                message.Message,
                message.Payload, message.MetaData, message.Date, message.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderConfigurationCommand message)
        {
            var @event = new DataProviderConfigurationAggregate(message.Id, message.DataProvider, message.Category,
                message.Message,
                message.Payload, message.MetaData, message.Date, message.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderSecurityCommand message)
        {
            var @event = new DataProviderSecurityAggregate(message.Id, message.DataProvider, message.Category,
                message.Message,
                message.Payload, message.MetaData, message.Date, message.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(DataProviderTransformationCommand message)
        {
            var @event = new DataProviderTransformationAggregate(message.Id, message.DataProvider, message.Category,
                message.Message,
                message.Payload, message.MetaData, message.Date, message.IsJson);
            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
