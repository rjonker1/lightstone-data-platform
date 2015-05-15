using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lim.Schedule.Audits;

namespace Lim.Schedule.Service.Installers
{
    public class AuditInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAuditIntegration>().ImplementedBy<StoreIntegrationAudit>().LifestyleTransient());
        }
    }
}