using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;
using Workflow;

namespace Billing.Api.Tests
{
    public class TestingBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IPublishMessages publisher;

        public TestingBootstrapper(IPublishMessages publisher)
        {
            this.publisher = publisher;
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.EnableStatelessAuthentication();
        }


        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IPublishMessages>(publisher);
        }

    }
}