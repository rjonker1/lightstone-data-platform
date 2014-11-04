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
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new StorageConfigModule());
            var container = builder.Build();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
    }
}
