using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Messaging.RabbitMQ;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using NServiceBus;

namespace PackageBuilder.Api.Installers
{
    public class LaceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assembliesToScan =
                AllAssemblies.Matching("Lightstone.DataPlatform.Lace.Shared.Monitoring.Messages")
                    .And("NServiceBus.NHibernate")
                    .And("NServiceBus.Transports.RabbitMQ");
            container.Register(Component.For<IBus>().Instance(new BusFactory("Monitoring.Messages.Commands", assembliesToScan, "DataPlatform.Monitoring.Host").CreateBusWithNHibernatePersistence()));
            container.Register(Component.For<IEntryPoint>().ImplementedBy<EntryPointService>().LifestyleTransient());
        }
    }
}