using NServiceBus;
using NServiceBus.Features;

namespace DataPlatform.Shared.RabbitMQ
{
    internal class BusFactory
    {
        public static IBus CreateBus(string commandNamespace)
        {
            var configuration = new BusConfiguration();

            configuration.UseTransport<RabbitMQTransport>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith(commandNamespace));
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
