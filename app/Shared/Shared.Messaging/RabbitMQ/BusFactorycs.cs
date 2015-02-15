using System.Collections.Generic;
using System.Reflection;
using NServiceBus;
using NServiceBus.Features;

namespace DataPlatform.Shared.Messaging.RabbitMQ
{
    public class BusFactory
    {
        private readonly string _namespace;
        private readonly string _endpointName;
        private readonly IEnumerable<Assembly> _assembliesToScan;

        public BusFactory(string @namespace, IEnumerable<Assembly> assembliesToScan, string endpointName)
        {
            _namespace = @namespace;
            _assembliesToScan = assembliesToScan;
            _endpointName = endpointName;
        }

        public IBus CreateBus()
        {
            var configuration = new BusConfiguration();

            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.EndpointName(_endpointName);
            configuration.AssembliesToScan(_assembliesToScan);
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.EndsWith(_namespace));
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
