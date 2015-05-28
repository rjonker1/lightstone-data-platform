using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Schedule.Core.Audits;

namespace Lim.Schedule.Service.Installers
{
    public class AuditInstallers : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<AuditInstallers>();
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Auditing");
            container.Register(Component.For<IAuditIntegration>().ImplementedBy<StoreIntegrationAudit>().LifestyleTransient());
            _log.InfoFormat("Auditing  Installed");
        }
    }
}