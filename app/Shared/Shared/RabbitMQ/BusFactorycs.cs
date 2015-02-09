using NServiceBus;
using NServiceBus.Features;

namespace DataPlatform.Shared.RabbitMQ
{
    public class BusFactory
    {
        private readonly string _namespace;

        public BusFactory(string @namespace)
        {
            _namespace = @namespace;
        }

        public IBus CreateBus()
        {
            var configuration = new BusConfiguration();

            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.EndsWith(_namespace));
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
