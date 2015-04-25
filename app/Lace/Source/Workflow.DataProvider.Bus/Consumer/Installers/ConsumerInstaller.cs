using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.DataProvider.Bus.ConsumerTypes;

namespace Workflow.DataProvider.Bus.Consumer.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private ILog _log;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log = LogManager.GetLogger(GetType());
            _log.InfoFormat("Installing Data Provider Consumer");

            container.Register(
                Component.For<CommandConsumer>().ImplementedBy<CommandConsumer>(),
                Component.For<EventConsumer>().ImplementedBy<EventConsumer>());
        }
    }
}
