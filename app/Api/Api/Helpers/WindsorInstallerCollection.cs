using Api.Helpers.Installers;
using Castle.MicroKernel.Registration;
using Shared.BuildingBlocks.Api.Installers;

namespace Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new BusInstaller(),
            new ServiceLocatorInstaller(),
            new WorkflowInstaller(),
            new AuthInstaller(),
            new AutoMapperInstaller()
        };
    }
}