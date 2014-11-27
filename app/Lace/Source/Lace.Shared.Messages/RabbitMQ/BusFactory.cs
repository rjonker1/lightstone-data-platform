using NServiceBus;
using NServiceBus.Features;

namespace Lace.Shared.Monitoring.Messages.RabbitMQ
{
    public class BusFactory
    {
        public static IBus CreateBus()
        {
            var configuration = new BusConfiguration();

            configuration.UseTransport<RabbitMQTransport>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Commands"));
            //.DefiningEventsAs(
            //    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Events"))
            //.DefiningMessagesAs(
            //    m => m.Namespace != null && m.Namespace.StartsWith("Monitoring.Domain.Messages.Messages"));

            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
