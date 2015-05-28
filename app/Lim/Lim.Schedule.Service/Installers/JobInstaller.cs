using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;

namespace Lim.Schedule.Service.Installers
{
    public class JobInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<HandlerInstaller>();
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing Jobs");

            container.Register(Component.For<Jobs.Integrations.Daily.Api.PushJob>().ImplementedBy<Jobs.Integrations.Daily.Api.PushJob>().LifestyleTransient());
            container.Register(Component.For<Jobs.Integrations.EveryMinute.Api.PushJob>().ImplementedBy<Jobs.Integrations.EveryMinute.Api.PushJob>().LifestyleTransient());
            container.Register(Component.For<Jobs.Integrations.Hourly.Api.PushJob>().ImplementedBy<Jobs.Integrations.Hourly.Api.PushJob>().LifestyleTransient());
            container.Register(Component.For<Jobs.Integrations.Custom.Api.PushJob>().ImplementedBy<Jobs.Integrations.Custom.Api.PushJob>().LifestyleTransient());

            container.Register(Component.For<Jobs.Integrations.Daily.Api.PullJob>().ImplementedBy<Jobs.Integrations.Daily.Api.PullJob>().LifestyleTransient());
            container.Register(Component.For<Jobs.Integrations.EveryMinute.Api.PullJob>().ImplementedBy<Jobs.Integrations.EveryMinute.Api.PullJob>().LifestyleTransient());
            container.Register(Component.For<Jobs.Integrations.Hourly.Api.PullJob>().ImplementedBy<Jobs.Integrations.Hourly.Api.PullJob>().LifestyleTransient());
            container.Register(Component.For<Jobs.Integrations.Custom.Api.PullJob>().ImplementedBy<Jobs.Integrations.Custom.Api.PullJob>().LifestyleTransient());

            _log.Info("Jobs Installed");
        }
    }
}