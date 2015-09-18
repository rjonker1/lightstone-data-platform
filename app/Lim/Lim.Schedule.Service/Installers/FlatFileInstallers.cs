using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;

namespace Lim.Schedule.Service.Installers
{
    public class FlatFileInstallers : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<FlatFileInstallers>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Log.Info("Installing Flat File Installers");

            container.Register(Classes.FromAssemblyContaining<Core.Factories.FlatFile.FetchFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.FlatFile.InitializePullFactory>()
                .BasedOn(typeof (IInitialize<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.FlatFile.PullFactory>()
                .BasedOn(typeof (IPull<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.FlatFile.PushFactory>()
                .BasedOn(typeof (IPush))
                .WithServiceAllInterfaces()
                .LifestyleTransient());


            Log.Info("Installed Flat File Installers");
        }
    }
}