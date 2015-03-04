using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Domain.Core.Security;

namespace UserManagement.Api.Installers
{
    public class HashProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHashProvider>().ImplementedBy<SaltedHash>());
        }
    }
}