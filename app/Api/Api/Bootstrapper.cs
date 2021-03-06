﻿using Billing.Api.Connector;
using Billing.Api.Connector.Configuration;
using Lace.Request.Entry;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Routing;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;
using Workflow;
using Workflow.BuildingBlocks;
using Workflow.RabbitMQ;

namespace Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            //var configuration = new StatelessAuthenticationConfiguration(context =>
            //{
            //    var token = context.AuthorizationHeaderToken();
            //    var authenticator = container.Resolve<IAuthenticateUser>();

                
            //    return string.IsNullOrWhiteSpace(token) ? null : authenticator != null ? authenticator.GetUserIdentity(token) : null;
            //});

            //StatelessAuthentication.Enable(pipelines, configuration);

            pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());
            pipelines.EnableCors(); // cross origin resource sharing
            pipelines.EnableMonitoring();

            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            AutoMapperConfiguration.Init();

            container.Register<IAuthenticateUser, UmApiAuthenticator>();
            container.Register<IRouteMetadataProvider, DefaultRouteMetadataProvider>();
            container.Register<IRouteDescriptionProvider, ApiRouteDescriptionProvider>();

            IPublishMessages publisher;
            using (var bus = BusFactory.CreateBus("monitor-event-tracking/queue"))
            {
                publisher = new Publisher(bus);
            }

            container.Register(publisher);
            container.Register<IEntryPoint>(new EntryPoint(publisher));

            container.Register<IConnectToBilling>(new DefaultBillingConnector(new ApplicationConfigurationBillingConnectorConfiguration()));
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
            base.ConfigureRequestContainer(container, context);

        }
    }
}