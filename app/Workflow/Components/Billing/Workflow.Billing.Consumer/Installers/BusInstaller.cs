﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using Workflow.BuildingBlocks;

namespace Workflow.Billing.Consumer.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log.InfoFormat("Installing bus");

            container.Register(
                Component.For<IBus>().UsingFactoryMethod(() => BusFactory.CreateBus("workflow/billing/queue", container)).LifestyleSingleton()
                );
        }
    }
}