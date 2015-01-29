using System;
using DataPlatform.Shared.Enums;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Dto;
using Lace.Shared.Monitoring.Messages.Infrastructure.Extensions;
using Monitoring.DomainModel.DataProviders;
using Monitoring.Test.Helper.Builder;
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
                    c => c.Namespace != null && c.Namespace.EndsWith("Monitoring.Messages.Commands"))
                .DefiningEventsAs(
                    c => c.Namespace != null && c.Namespace.EndsWith("Monitoring.Messages.Events"));

            NServiceBus.Testing.Test.Initialize();
        }

        [Observation]
        public void then_data_provider_command_handler_message_should_be_handled()
        {
            NServiceBus.Testing.Test.Handler<DataProviderCommandHandler>(new DataProviderCommandHandler(_repository))
                .OnMessage<DataProviderMonitoringCommand>(GetDataProviderCommandEnvelope());

            FakeDatabase.Events.Count.ShouldEqual(1);
        }

        private DataProviderMonitoringCommand GetDataProviderCommandEnvelope()
        {
            var payload = DataProviderRequestBuilder.ForIvidLicensePlateSearch();
            _dataProviderStopWatch = new DataProviderStopWatch(DataProviderCommandSource.Ivid.ToString());

            var command = new
            {
                StartIvidExecution =
                    new StartIvidExecution(_aggregateId, DataProviderCommandSource.Ivid,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Ivid),
                        payload, new PerformanceMetadata(_dataProviderStopWatch.ToObject()), DateTime.UtcNow,
                        Category.Performance)
            };

            var cmd = command.ObjectToJson().GetCommand(_aggregateId, (int) DisplayOrder.FirstThing, 1);
            return cmd;
        }
    }
}
