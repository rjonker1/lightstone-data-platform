using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;

namespace Lim.Schedule.Service.Installers
{
    public class ApiInstallers : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<HandlerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing Api Installers");


            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.FetchPushFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.FetchPullFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.ClientFetchPushFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.ClientFetchPullFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.CustomFetchPushFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.CustomFetchPullFactory>()
                .BasedOn(typeof (IFetch<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());


            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.InitializePushFactory>()
                          .BasedOn(typeof(IInitialize<>))
                          .WithServiceAllInterfaces()
                          .LifestyleTransient());

            //container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.PushFactory>()
            //    .BasedOn(typeof(IPull<>))
            //    .WithServiceAllInterfaces()
            //    .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<Core.Factories.Api.PushFactory>()
                .BasedOn(typeof(IPush))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            _log.Info("Api Installers Installed");
        }
    }
}
