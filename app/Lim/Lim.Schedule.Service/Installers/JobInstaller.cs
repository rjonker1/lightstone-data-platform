using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Lim.Schedule.Service.Installers
{
    public class JobInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Daily.Api.Job>().ImplementedBy<Daily.Api.Job>().LifestyleTransient());
            container.Register(Component.For<EveryMinute.Api.Job>().ImplementedBy<EveryMinute.Api.Job>().LifestyleTransient());
            container.Register(Component.For<Hourly.Api.Job>().ImplementedBy<Hourly.Api.Job>().LifestyleTransient());
            container.Register(Component.For<Custom.Api.Job>().ImplementedBy<Custom.Api.Job>().LifestyleTransient());
        }
    }
}
