using Nancy;
using Nancy.TinyIoc;
using Workflow;
using Workflow.BuildingBlocks;

namespace Billing.Api.Infrastructure
{
    public class BillingBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var bus = new BusFactory().CreateBus("workflow/billing/queue");
            var publisher = new Workflow.RabbitMQ.Publisher(bus);


            container.Register<IPublishMessages>(publisher);
        }
    }
}