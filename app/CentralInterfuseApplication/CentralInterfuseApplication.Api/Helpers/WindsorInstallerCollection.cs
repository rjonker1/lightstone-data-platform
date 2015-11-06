using Castle.MicroKernel.Registration;
using CentralInterfuseApplication.Api.Helpers.Installers;
using Shared.BuildingBlocks.Api.Installers;

namespace CentralInterfuseApplication.Api.Helpers
{
    public class WindsorInstallerCollection
    {
        public static IWindsorInstaller[] Installers =
        {
            new ApiClientInstaller(), 
            new AuthInstaller(),  
        };
    }
}