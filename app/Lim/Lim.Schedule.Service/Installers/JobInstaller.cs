using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Lim.Schedule.Service.Installers
{
    public class JobInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Integrations.Daily.Api.PushJob>().ImplementedBy<Integrations.Daily.Api.PushJob>().LifestyleTransient());
            container.Register(Component.For<Integrations.EveryMinute.Api.PushJob>().ImplementedBy<Integrations.EveryMinute.Api.PushJob>().LifestyleTransient());
            container.Register(Component.For<Integrations.Hourly.Api.PushJob>().ImplementedBy<Integrations.Hourly.Api.PushJob>().LifestyleTransient());
            container.Register(Component.For<Integrations.Custom.Api.PushJob>().ImplementedBy<Integrations.Custom.Api.PushJob>().LifestyleTransient());

            container.Register(Component.For<Integrations.Daily.Api.PullJob>().ImplementedBy<Integrations.Daily.Api.PullJob>().LifestyleTransient());
            container.Register(Component.For<Integrations.EveryMinute.Api.PullJob>().ImplementedBy<Integrations.EveryMinute.Api.PullJob>().LifestyleTransient());
            container.Register(Component.For<Integrations.Hourly.Api.PullJob>().ImplementedBy<Integrations.Hourly.Api.PullJob>().LifestyleTransient());
            container.Register(Component.For<Integrations.Custom.Api.PullJob>().ImplementedBy<Integrations.Custom.Api.PullJob>().LifestyleTransient());
        }
    }
}