﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;

namespace PackageBuilder.Api.Installers
{
    public class LaceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //var assembliesToScan =
            //      AllAssemblies.Matching("Lightstone.DataPlatform.Workflow.Lace.Messages")
            //          .And("NServiceBus.NHibernate")
            //          .And("NServiceBus.Transports.RabbitMQ");

            //container.Register(
            //    Component.For<IBus>()
            //        .Instance(
            //            new BusFactory("Workflow.Lace.Messages.Commands", assembliesToScan, "DataPlatform.Transactions.Host.Write")
            //                .CreateBusWithNHibernatePersistence()));
            container.Register(Component.For<IEntryPoint>().ImplementedBy<EntryPointService>().LifestyleTransient());
        }
    }
}