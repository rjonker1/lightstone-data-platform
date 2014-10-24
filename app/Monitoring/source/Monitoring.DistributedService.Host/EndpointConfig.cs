using Autofac;
using Autofac.Builder;
using Monitoring.DistributedService.Host.IoC;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.MessageMutator;

namespace Monitoring.DistributedService.Host{
   
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        //private IWindsorContainer _container;

        public void Customize(BusConfiguration configuration)
        {

            //configuration.DisableFeature<Sagas>();
            configuration.EnableFeature<JsonSerialization>();
            configuration.EnableFeature<XmlSerialization>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.DisableFeature<TimeoutManager>();

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
            //builder.RegisterType<IStartableBus>().AsSelf();
            builder.RegisterModule(new DomainModule());
            var container = builder.Build();

            //container.Resolve<IStartableBus>();

            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));

           // Bus.Create(configuration);
            //configuration.UseContainer<WindsorContainerDefintion>();

        }
    }
}
