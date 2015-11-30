using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.Logging;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Installers
{
    public class HelperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install HelperInstaller", SystemName.UserManagement);
            container.Register(Component.For<IEntityByTypeRepository>().ImplementedBy<EntityByTypeRepository>().LifestyleTransient());
            this.Info(() => "Successfully installed HelperInstaller", SystemName.UserManagement);
        }
    }
}