using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PackageBuilder.Api.Helpers;

namespace PackageBuilder.Api.Installers
{
    public class ContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<CurrentContext>().ImplementedBy<CurrentContext>());
        }
    }
}