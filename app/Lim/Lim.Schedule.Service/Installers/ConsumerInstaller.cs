using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Domain.Receiver.Handlers;
using Lim.Domain.Sender.Handlers;
using Toolbox.LightstoneAuto.Consumers.Read;
using Toolbox.LightstoneAuto.Consumers.Write;
using Toolbox.LIVE.Infrastructure.Consumers.Read;
using Toolbox.LIVE.Infrastructure.Consumers.Write;

namespace Lim.Schedule.Service.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<ConsumerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Log.InfoFormat("Installing Consumers");

            container.Register(Component.For<ResponseFromPackageConsumer>().ImplementedBy<ResponseFromPackageConsumer>());
            container.Register(Component.For<AlwaysOnConfigurationConsumer>().ImplementedBy<AlwaysOnConfigurationConsumer>());

            container.Register(Component.For<SendExecutedPackageConsumer>().ImplementedBy<SendExecutedPackageConsumer>());
            container.Register(Component.For<ExecutedPackageSentConsumer>().ImplementedBy<ExecutedPackageSentConsumer>());

            container.Register(Component.For<DataSetExportEventConsumer>().ImplementedBy<DataSetExportEventConsumer>());
            container.Register(Component.For<DataSetExportCommandConsumer>().ImplementedBy<DataSetExportCommandConsumer>());

            container.Register(Component.For<ViewImportCommandConsumer>().ImplementedBy<ViewImportCommandConsumer>());
            container.Register(Component.For<ViewImportEventConsumer>().ImplementedBy<ViewImportEventConsumer>());

            Log.InfoFormat("Consumers Installed");
        }
    }
}
