using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Infrastructure.NEventStore;

namespace PackageBuilder.Api.Installers
{
    public class CacheProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(ICacheProvider<>)).ImplementedBy(typeof(CacheProvider<>)));
        }
    }
}