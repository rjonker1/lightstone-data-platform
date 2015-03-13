using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using EasyNetQ;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;

namespace Billing.Api.Installers
{
    public class BusInstaller : IWindsorInstaller
    {

        private IBus bus;
        private Publisher publisher;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            this.Info(() => "Attempting to install BusInstaller");

            container.Register(Component.For<IPublishMessages>().Instance(new Publisher(BusFactory.CreateBus("workflow/billing/queue"))));

            this.Info(() => "Successfully installed BusInstaller");
        }
    }
}