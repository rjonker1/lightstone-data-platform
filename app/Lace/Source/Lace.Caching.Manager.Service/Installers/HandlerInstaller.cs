using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lace.Caching.BuildingBlocks.Handlers;

namespace Lace.Caching.Manager.Service.Installers
{
    public class HandlerInstaller : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<HandlerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Log.Info("Installing the handlers");
            container.Register(Component.For<IHandleClearingData>().ImplementedBy<ClearData>().LifestyleTransient());
            container.Register(Component.For<IHandleRefreshingData>().ImplementedBy<RefreshData>().LifestyleTransient());
        }
    }
}
