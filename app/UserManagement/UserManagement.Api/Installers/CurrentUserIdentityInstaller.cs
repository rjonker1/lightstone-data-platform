using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UserManagement.Api.Helpers.Security;

namespace UserManagement.Api.Installers
{
    public class CurrentUserIdentityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICurrentUserIdentity>().ImplementedBy<CurrentUserIdentity>().LifestylePerWebRequest());
        }
    }
}