﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Domain.Receiver.Handlers;
using Lim.Domain.Sender.Handlers;
using Toolbox.LIVE.Infrastructure.Consumers.Read;
using Toolbox.LIVE.Infrastructure.Consumers.Write;

namespace Lim.Schedule.Service.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private ILog _log;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log = LogManager.GetLogger(GetType());
            _log.InfoFormat("Installing Consumers");

            container.Register(Component.For<ResponseFromPackageConsumer>().ImplementedBy<ResponseFromPackageConsumer>());
            container.Register(Component.For<AlwaysOnConfigurationConsumer>().ImplementedBy<AlwaysOnConfigurationConsumer>());

            container.Register(Component.For<SendExecutedPackageConsumer>().ImplementedBy<SendExecutedPackageConsumer>());
            container.Register(Component.For<ExecutedPackageSentConsumer>().ImplementedBy<ExecutedPackageSentConsumer>());

            _log.InfoFormat("Consumers Installed");
        }
    }
}
