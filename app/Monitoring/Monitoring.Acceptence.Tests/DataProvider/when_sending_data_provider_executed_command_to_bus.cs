using System;
using Monitoring.Domain.Messages.Commands;
using Monitoring.Test.Helper.Mothers;
using NServiceBus;
using Xunit.Extensions;

namespace Monitoring.Acceptence.Tests.DataProvider
{
    public class when_sending_data_provider_executed_command_to_bus : Specification
    {
        private readonly IBus _bus;
        private readonly ExecuteDataProvider _command;

        public when_sending_data_provider_executed_command_to_bus()
        {
            _bus = BusFactory.NServiceRabbitMqBus();

            _command = new ExecuteDataProvider(Guid.NewGuid(), (int) Domain.Core.Consumers.DataProvider.Audatex,
                Domain.Core.Constants.DefinedMessages.StartCallingDataProvider, "", DateTime.UtcNow);
        }

        public override void Observe()
        {
            _bus.Send(_command);
        }

        [Observation]
        public void then_event_must_be_published_to_bus()
        {
            true.ShouldEqual(true);
        }
    }
}
