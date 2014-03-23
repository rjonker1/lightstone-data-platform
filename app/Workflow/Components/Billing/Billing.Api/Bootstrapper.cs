using Nancy.TinyIoc;
using Workflow;
using Workflow.BuildingBlocks;

namespace Billing.Api
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var bus = new BusFactory().CreateBus("workflow/billing/queue");
            var publisher = new Workflow.RabbitMQ.Publisher(bus);


            container.Register<IPublishMessages>(publisher);
        }
    }
}