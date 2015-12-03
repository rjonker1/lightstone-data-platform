using Castle.MicroKernel.Registration;
using PackageBuilder.Api.Installers;
using Shared.BuildingBlocks.Api.Installers;

namespace PackageBuilder.Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new CommandInstaller(),
            new BusInstaller(),
            new ServiceLocatorInstaller(),
            new RedisInstaller(), 
            new NHibernateInstaller(),
            new RepositoryInstaller(),
            new CacheProviderInstaller(),
            new NEventStoreInstaller(),
            new AutoMapperInstaller(),
            new LaceInstaller(),
            new AuthInstaller(),
            new ApiInstaller(),
            new NancyInstaller(), 
        };
    }
}