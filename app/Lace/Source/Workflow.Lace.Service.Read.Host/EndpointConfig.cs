
using Autofac;
using NServiceBus.Features;

namespace Workflow.Lace.Service.Read.Host
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableFeature<JsonSerialization>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.EndpointName("DataPlatform.DataProviders.Host.Read");
            configuration.Conventions()
                .DefiningEventsAs(c => c.Namespace != null && c.Namespace.EndsWith("Messages.Events"))
                .DefiningCommandsAs(c => c.Namespace != null && c.Namespace.EndsWith("Messages.Commands"));

            var builder = new ContainerBuilder();
            builder.RegisterModule(new ReadModule());
            var container = builder.Build();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
    }
}
