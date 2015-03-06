using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Security;

namespace UserManagement.Api.Installers
{
    public class HashProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install HashProviderInstaller");
            container.Register(Component.For<IHashProvider>().ImplementedBy<SaltedHash>());
            this.Info(() => "Successfully installed HashProviderInstaller");
        }
    }
}