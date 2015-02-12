using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Installers
{
    public class HelperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRetrieveEntitiesByType>().ImplementedBy<EntitiesByTypeHelper>().LifestyleTransient());
        }
    }
}