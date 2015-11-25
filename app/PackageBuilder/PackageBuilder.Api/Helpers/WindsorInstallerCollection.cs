using Castle.MicroKernel.Registration;
using PackageBuilder.Api.Installers;
using Shared.BuildingBlocks.Api.Installers;

namespace PackageBuilder.Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new RedisInstaller(), 
            new NHibernateInstaller(),
            new RepositoryInstaller(),
            new CommandInstaller(),
            new BusInstaller(),
            new CacheProviderInstaller(),
            new NEventStoreInstaller(),
            new ServiceLocatorInstaller(),
            new AutoMapperInstaller(),
            new LaceInstaller(),
            new AuthInstaller(),
            new ApiInstaller(),
            new NancyInstaller(), 
        };
    }
}