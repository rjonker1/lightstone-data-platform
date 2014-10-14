using Castle.Windsor;
using MemBus;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_a_bus : Specification
    {
        IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Install(new BusInstaller());
        }

        [Observation]
        public void should_resolve_IBus()
        {
            _container.Resolve<IBus>().ShouldNotBeNull();
        }
    }
}