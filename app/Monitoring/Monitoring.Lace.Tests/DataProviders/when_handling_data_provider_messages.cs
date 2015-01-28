using System;
using CommonDomain;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Extensions;
using Monitoring.DomainModel.DataProviders;
using Monitoring.Test.Helper.Builder;
using Monitoring.Test.Helper.Fakes;
using Monitoring.Test.Helper.Fakes.EventStore;
using Monitoring.Write.Service.DataProviders;
using NServiceBus;
using Xunit.Extensions;
using IBus = EasyNetQ.IBus;

namespace Monitoring.Unit.Tests.DataProviders
{
    public class when_handling_data_provider_messages : Specification
    {
        private readonly IBus Bus;
        private readonly Guid _aggregateId;
        private readonly FakeEventStoreRepository _repository;

        private DataProviderStopWatch _dataProviderStopWatch;

        public when_handling_data_provider_messages()
        {
            _aggregateId = Guid.NewGuid();
            _repository = new FakeEventStoreRepository();
        }

        public override void Observe()
        {
            var configuration = new BusConfiguration();
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Commands"))
                .DefiningEventsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("DataPlatform.Shared.Messaging.Events"));

            NServiceBus.Testing.Test.Initialize();
        }

        [Observation]
        public void then_data_provider_command_handler_message_should_be_handled()
        {
            NServiceBus.Testing.Test.Handler<DataProviderHandler>(new DataProviderHandler(_repository))
                .OnMessage<DataProviderCommandEnvelope>(GetDataProviderCommandEnvelope());

            FakeDatabase.Events.Count.ShouldEqual(1);
        }

        private DataProviderCommandEnvelope GetDataProviderCommandEnvelope()
        {
            var payload = DataProviderRequestBuilder.ForIvidLicensePlateSearch();
            _dataProviderStopWatch = new DataProviderStopWatch(DataProviderCommandSource.Ivid.ToString());

            var command = new
            {
                AudatexExecutionHasStarted =
                    new AudatexExecutionHasStarted(_aggregateId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Audatex),
                        payload, _dataProviderStopWatch, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_aggregateId, (int) DisplayOrder.FirstThing, 1);
        }
    }
}
