using System;
using CommonDomain.Persistence;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Publisher;
using Monitoring.DomainModel.DataProviders;
using Monitoring.Test.Helper.Fakes.EventStore;
using Monitoring.Write.Service.DataProviders;
using Xunit.Extensions;

namespace Monitoring.Unit.Tests.DataProvider
{
    public class when_sending_data_provider_events_to_the_bus : Specification
    {
        private readonly IRepository _repository;
        private readonly DataProviderHandler _handler;

        private Guid _aggregateId;

        public when_sending_data_provider_events_to_the_bus()
        {
            _repository = new FakeEventStoreRepository();
            _handler = new DataProviderHandler(_repository);
        }

        public override void Observe()
        {
            _aggregateId = Guid.NewGuid();
        }

        [Observation]
        public void then_monitoring_data_provider_executing_command_must_be_handled()
        {
            var command = CommandMessageFactory.StartDataProvider(_aggregateId,
                Lace.Shared.Monitoring.Messages.Core.DataProvider.Ivid, string.Empty,
                Category.Performance, "", true);
            _handler.Handle(command);

            var @event = _repository.GetById<DataProviderFromLace>(command.Command.Id);
            @event.ShouldNotBeNull();
            @event.Id.ShouldEqual(_aggregateId);
        }
    }
}
