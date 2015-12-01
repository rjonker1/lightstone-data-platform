using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.Logging;
using UserManagement.Api.Helpers.Security;

namespace UserManagement.Api.Installers
{
    public class AuthenticationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install AuthenticationInstaller", SystemName.UserManagement);

            //container.Register(Component.For<IUserAuthenticationClient>().ImplementedBy<UserAuthenticatorClient>().LifestyleTransient());
            container.Register(Component.For<IUmAuthenticator>().ImplementedBy<UmAuthenticator>().LifestyleTransient());
            //container.Register(Component.For<IAuthenticateUser>().ImplementedBy<RedisAuthenticator>().LifestyleTransient());

            this.Info(() => "Successfully installed AuthenticationInstaller", SystemName.UserManagement);
        }
    }
}