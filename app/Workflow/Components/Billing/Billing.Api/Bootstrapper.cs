using System;
using System.Linq;
using EasyNetQ;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;

namespace Billing.Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        private IBus bus;
        private Publisher publisher;
        private static readonly Common.Logging.ILog log = Common.Logging.LogManager.GetLogger<Bootstrapper>();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.EnableStatelessAuthentication();
            pipelines.OnError.AddItemToEndOfPipeline((ctx, e) =>
            {
                if (ctx.Response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    log.ErrorFormat("Error occured on route {0}", ctx.ResolvedRoute.ToString());
                    log.ErrorFormat("The error was {0}", e);
                }

                return null;
            });
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            bus = new BusFactory().CreateBus("workflow/billing/queue");
            publisher = new Publisher(null);

            container.Register<IPublishMessages>(publisher);
        }

    }

    public class LoggingPipelet
    {
    }
}