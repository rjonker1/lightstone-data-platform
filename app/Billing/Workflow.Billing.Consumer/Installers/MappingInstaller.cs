using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumer.Installers
{
    public class MappingTypeInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<RepositoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Mappings for Types");
            container.Register(Component.For<IHaveTypeMappings>().ImplementedBy<MappingsforTypes>());
        }
    }
}
