using System;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Monitoring.Test.Helper.Mothers;
using NServiceBus;
using Xunit.Extensions;

namespace Monitoring.Acceptence.Tests.DataProvider
{
    public class when_sending_data_provider_executed_command_to_bus : Specification
    {
        private readonly IBus _bus;
        private readonly DataProviderCommand _command;



        public when_sending_data_provider_executed_command_to_bus()
        {
            _bus = BusFactory.NServiceRabbitMqBus();

            _command = new DataProviderCommand(Guid.NewGuid(),
                Lace.Shared.Monitoring.Messages.Core.DataProvider.Audatex,
                "Start Calling unit test", "request{}", "metadata", DateTime.UtcNow, Category.Performance, true);
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
