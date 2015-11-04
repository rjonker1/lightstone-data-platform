using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Recoveries.Domain.Base;
using Recoveries.Domain.Handlers;

namespace Recoveries.Router.Installers
{
    public class RecoveryHandlerInstaller : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<RecoveryHandlerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Log.Info("Installing Recovery Message Handler Installers");

            container.Register(Component.For<IQueueRetrieval>().ImplementedBy<QueueRetrieval>());
            container.Register(Component.For<IMessageWriter>().ImplementedBy<FileMessageWriter>());
            container.Register(Component.For<IMessageReader>().ImplementedBy<MessageReader>());
            container.Register(Component.For<IErrorRetry>().UsingFactoryMethod(CreateErrorRetry));
            container.Register(Component.For<IDeleteFiles>().ImplementedBy<DeleteErrorFiles>());
            container.Register(Component.For<IPurgeQueue>().ImplementedBy<PurgeErrorQueue>());

            container.Register(Component.For<IHandleErrorMessageRecovery>().ImplementedBy<ErrorMessageRecoveryHandler>());

            Log.Info("Installed Recovery Message Handler Installers");
        }

        private static IErrorRetry CreateErrorRetry()
        {
            var typeNameSerializer = new TypeNameSerializer();
            return new ErrorRetry(new JsonSerializer(typeNameSerializer));
        }
    }
}
