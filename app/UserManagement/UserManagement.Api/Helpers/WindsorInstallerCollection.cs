using Castle.MicroKernel.Registration;
using Shared.BuildingBlocks.Api.Installers;
using UserManagement.Api.Installers;

namespace UserManagement.Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new LoggingInstaller(), 
            new CommandInstaller(),
            new BusInstaller(),
            new ServiceLocatorInstaller(),
            new NHibernateInstaller(),
            new RepositoryInstaller(),
            new AutoMapperInstaller(),
            new HelperInstaller(),
            new ApiClientInstaller(),
            new RedisInstaller(),
            new AuthenticationInstaller(),
            new HashProviderInstaller(),
            new AuthInstaller(),
            new CurrentUserIdentityInstaller()
        };
    }
}