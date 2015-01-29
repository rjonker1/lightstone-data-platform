using Autofac;
using NServiceBus;
using Monitoring.DistributedService.DenormalizerHost.IoC;
using NServiceBus.Features;

namespace Monitoring.DistributedService.DenormalizerHost
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EnableFeature<JsonSerialization>();
            configuration.EnableFeature<XmlSerialization>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();

            configuration.EndpointName("DataPlatform.Monitoring.DenormalizerHost");

            configuration.Conventions()
                .DefiningEventsAs(
                    c => c.Namespace != null && c.Namespace.EndsWith("Messaging.Events"));

            var builder = new ContainerBuilder();
            builder.RegisterModule(new DenormalizerHostModule());
            var container = builder.Build();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
    }
}
