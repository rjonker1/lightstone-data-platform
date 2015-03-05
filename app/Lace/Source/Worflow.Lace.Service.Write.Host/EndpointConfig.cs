using Autofac;
using NServiceBus.Features;

namespace Worflow.Lace.Service.Write.Host
{
    using NServiceBus;
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EnableFeature<JsonSerialization>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EndpointName("DataPlatform.DataProviders.Host.Write");

            configuration.Conventions()
                .DefiningEventsAs(c => c.Namespace != null && c.Namespace.EndsWith("Messages.Events"))
                .DefiningCommandsAs(c => c.Namespace != null && c.Namespace.EndsWith("Messages.Commands"));

            var builder = new ContainerBuilder();
            builder.RegisterModule(new WriteModule());
            var container = builder.Build();

            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
    }
}
