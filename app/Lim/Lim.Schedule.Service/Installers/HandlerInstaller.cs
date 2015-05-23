using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Handlers;

namespace Lim.Schedule.Service.Installers
{
    public class HandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHandleFetchingApiPushConfiguration>().ImplementedBy<HandleFetchingApiPushConfiguration>().LifestyleTransient());
            container.Register(
                Component.For<IHandleFetchingApiPullConfiguration>().ImplementedBy<HandleFetchingApiPullConfiguration>().LifestyleTransient());
            container.Register(Component.For<IHandleExecutingApiConfiguration>().ImplementedBy<HandleExecutingApiConfiguration>().LifestyleTransient());
        }
    }
}
