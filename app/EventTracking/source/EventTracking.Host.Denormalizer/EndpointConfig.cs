using Autofac;
using EventTracking.Host.Denormalizer.IoC;
using NServiceBus.Features;

namespace EventTracking.Host.Denormalizer
{
    using NServiceBus;
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EnableFeature<JsonSerialization>();
            configuration.EnableFeature<XmlSerialization>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.DisableFeature<TimeoutManager>();

            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("EventTracking.Domain.Messages.Commands"))
                .DefiningEventsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("EventTracking.Domain.Messages.Events"))
                .DefiningMessagesAs(
                    m =>
                        m.Namespace != null &&
                        m.Namespace.StartsWith("EventTracking.Domain.Messages.Messages"));

            var builder = new ContainerBuilder();
            builder.RegisterModule(new DenormalizedStorageModule());
            var container = builder.Build();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
    }
}
