using System.Collections.Generic;
using System.Reflection;
using NServiceBus;
using NServiceBus.Features;

namespace Api.Verfication.Infrastructure.Messaging.RabbitMQ
{
    public class BusFactory
    {
        private readonly string _namespace;
        private readonly IEnumerable<Assembly> _assembliesToScan;

        public BusFactory(string @namespace, IEnumerable<Assembly> assembliesToScan)
        {
            _namespace = @namespace;
            _assembliesToScan = assembliesToScan;
        }

        public IBus CreateBus()
        {
            var configuration = new BusConfiguration();

            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.EndpointName("DataPlatform.Monitoring.Host");
            configuration.AssembliesToScan(_assembliesToScan);
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.EndsWith(_namespace));
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
