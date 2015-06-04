using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Schedule.Core.Tracking;

namespace Lim.Schedule.Service.Installers
{
    public class TrackingInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<TrackingInstaller>();
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Tracking");
            container.Register(Component.For<ITrackIntegration>().ImplementedBy<TrackIntegration>().LifestyleTransient());
            _log.InfoFormat("Tracking  Installed");
        }
    }
}
