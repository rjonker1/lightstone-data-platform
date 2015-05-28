using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Handlers;

namespace Lim.Schedule.Service.Installers
{
    public class HandlerInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<HandlerInstaller>();
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing Handlers");

            container.Register(Component.For<IHandleFetchingApiPushConfiguration>().ImplementedBy<HandleFetchingApiPushConfiguration>().LifestyleTransient());
            container.Register(
                Component.For<IHandleFetchingApiPullConfiguration>().ImplementedBy<HandleFetchingApiPullConfiguration>().LifestyleTransient());
            container.Register(Component.For<IHandleExecutingApiConfiguration>().ImplementedBy<HandleExecutingApiConfiguration>().LifestyleTransient());

            _log.Info("Handlers Installed");
        }
    }
}
