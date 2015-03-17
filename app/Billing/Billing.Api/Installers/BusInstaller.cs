using Billing.Domain.Core.MessageHandling;
using Billing.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using MemBus.Configurators;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;
//using IBus = EasyNetQ.IBus;

namespace Billing.Api.Installers
{
    public class BusInstaller : IWindsorInstaller
    {

        //private IBus bus;
        //private Publisher publisher;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            this.Info(() => "Attempting to install BusInstaller");

            container.Register(Component.For<IPublishMessages>().Instance(new Publisher(BusFactory.CreateBus("workflow/billing/queue"))));
            container.Register(Component.For<IBus>().Instance(BusSetup.StartWith<Conservative>()
                                                                     .Apply<IoCSupport>(s => s.SetAdapter(new MessageAdapter(container))
                                                                     .SetHandlerInterface(typeof(IHandleMessages<>)))
                                                                     .Construct()));

            this.Info(() => "Successfully installed BusInstaller");
        }
    }
}