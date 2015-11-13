using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lace.Caching.Manager.Service.Jobs;

namespace Lace.Caching.Manager.Service.Installers
{
    public class JobInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<RefreshCache>().ImplementedBy<RefreshCache>().LifestyleTransient());
        }
    }
}