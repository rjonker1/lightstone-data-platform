using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lim.Domain.Base;
using Lim.Domain.EventStore;
using Lim.Domain.EventStore.Factory;

namespace Lim.Schedule.Service.Installers
{
    public class EventStoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IEventStoreRepository>().ImplementedBy<EventStoreRepository>());
            container.Register(Component.For<IEventStore>().ImplementedBy<EventStore>());
            container.Register(Component.For(typeof (IAggregateRepository<>)).ImplementedBy(typeof (AggregateRepository<>)).LifestyleTransient());
            container.Register(
                Component.For<LimEventStoreConfiguration>().UsingFactoryMethod(c => LimEventStoreManager.BuildConfiguration()).LifestyleTransient());
        }
    }
}
