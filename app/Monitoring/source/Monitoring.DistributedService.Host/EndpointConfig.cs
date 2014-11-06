using Autofac;
using Monitoring.DistributedService.Host.IoC;
using NServiceBus;
using NServiceBus.Features;

namespace Monitoring.DistributedService.Host
{
   
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EnableFeature<JsonSerialization>();
            configuration.EnableFeature<XmlSerialization>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.DisableFeature<TimeoutManager>();
           // configuration.EndpointName("Monitoring.DistributedService.Host.APPSURE-PC5");
           // configuration.EndpointName("");
         
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Monitoring.Domain.Messages.Commands"))
                .DefiningEventsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Monitoring.Domain.Messages.Events"))
                .DefiningMessagesAs(
                    m =>
                        m.Namespace != null &&
                        m.Namespace.StartsWith("Monitoring.Domain.Messages.Messages"));

            var builder = new ContainerBuilder();
            builder.RegisterModule(new DomainModule());
            var container = builder.Build();

            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
        }
    }
}
