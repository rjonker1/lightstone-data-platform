using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.Logging;

namespace UserManagement.Api.Installers
{
    public class ApiClientInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install ApiClientInstaller", SystemName.UserManagement);
            container.Register(Component.For<IPackageBuilderApiClient>().ImplementedBy<PackageBuilderApiClient>().LifestyleTransient());
            this.Info(() => "Successfully installed ApiClientInstaller", SystemName.UserManagement);
        }
    }
}