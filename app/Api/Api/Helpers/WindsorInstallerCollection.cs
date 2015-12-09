using Api.Installers;
using Castle.MicroKernel.Registration;
using Shared.BuildingBlocks.Api.Installers;

namespace Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new LoggingInstaller(), 
            new ServiceLocatorInstaller(),
            new AuthInstaller(),
            new AutoMapperInstaller()
        };
    }
}