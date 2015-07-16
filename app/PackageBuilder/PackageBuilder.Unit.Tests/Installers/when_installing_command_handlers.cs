using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.EventHandlers.Packages;
using PackageBuilder.TestHelper;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_command_handlers : Specification
    {
        class WindsorInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IWindsorContainer>().Instance(container));
            }
        }

        readonly IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            _container.Install(new WindsorInstaller(), new BusInstaller(),new CommandInstaller(), new RavenDbInstaller(), new NEventStoreInstaller(), new RepositoryInstaller(), new NHibernateInstaller());
            OverrideHelper.OverrideNhibernateCfg(_container);
        }

        [Observation]
        public void should_resolve_IHandleMessages()
        {
            _container.Resolve<IHandleMessages>().ShouldBeType<MessagesHandlerResolver>();
        }

        [Observation]
        public void should_resolve_all_handlers()
        {
            var registeredHandlers = Core.Helpers.Extensions.TypeExtensions.FindDerivedTypesFromAssembly(Assembly.GetAssembly(typeof(PackageCreatedHandler)), typeof(IHandleMessages<>), true, false).OrderBy(x => x.Name);
            var resolvedHandlers = _container.ResolveAll<IHandleMessages>().Select(x => x.GetType()).Where(x => x != typeof(MessagesHandlerResolver)).OrderBy(x => x.Name);
                
             registeredHandlers.ShouldEqual(resolvedHandlers);
        }
    }
}