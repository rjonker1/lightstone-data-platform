using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Installers
{
    public class HelperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install HelperInstaller");
            container.Register(Component.For<IRetrieveEntitiesByType>().ImplementedBy<EntitiesByTypeHelper>().LifestyleTransient());
            this.Info(() => "Successfully installed HelperInstaller");
        }
    }
}