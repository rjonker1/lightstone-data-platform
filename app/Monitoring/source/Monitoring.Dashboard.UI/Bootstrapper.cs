using System.Linq;
using Api.Infrastructure.Base.Handlers;
using Api.Infrastructure.Handlers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Base.Services;
using DataProvider.Infrastructure.Handlers;
using DataProvider.Infrastructure.Repository;
using DataProvider.Infrastructure.Services;
using EasyNetQ;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;
using Nancy.Helpers;
using Nancy.Hosting.Aspnet;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Shared.BuildingBlocks.Api.Installers;
using Workflow.BuildingBlocks;

namespace Monitoring.Dashboard.UI
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new AspNetRootPathProvider(); }
        }

        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            pipelines.BeforeRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                this.Info(() => "Monitoring API invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
                var token = "";
                var cookie = nancyContext.Request.Headers.Cookie.FirstOrDefault(x => (x.Name + "").ToLower() == "token");
                if (cookie != null)
                    token = HttpUtility.UrlDecode(cookie.Value);

                nancyContext.Request.Headers.Authorization = "Token {0}".FormatWith(token);

                var user = container.Resolve<ITokenizer>().Detokenize(token, nancyContext, new DefaultUserIdentityResolver());
                if (user != null)
                {
                    nancyContext.CurrentUser = user;
                }
                return null;
            });

            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Monitoring request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                return ErrorResponse.FromException(exception);
            });
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));

            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Monitoring request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                return ErrorResponse.FromException(exception);
            });
        }
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(Component.For<IRepositoryMapper, RepositoryMapper>());
            container.Register(Component.For<IHaveTypeMappings, MappingForMonitoringTypes>());
            container.Register(Component.For<IMonitoringRepository, MonitoringRepository>());
            container.Register(Component.For<ITransactionRepository, BillingTransactionRepository>());

            container.Register(Component.For<IHandleMonitoringCommands, DataProviderHandler>());
            container.Register(Component.For<IHandleDataProviderIndicators, DataProviderIndicatorsHandler>());
            container.Register(Component.For<IHandleApiRequests, ApiRequestHandler>());
            container.Register(Component.For<ICallMonitoringService, MonitoringService>());

            container.Register(Component.For<IHandleDataProviderCaching, DataProviderCachingHandler>());
            container.Register(Component.For<IPublishCacheMessages, DataProviderCommandPublisher>());
            container.Register(Component.For<IAdvancedBus>().UsingFactoryMethod(kernel => BusFactory.CreateAdvancedBus(QueueConfigurationReader.CacheSender)));

            container.Install(new AuthInstaller());
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js/pages"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/images"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/img"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css/skins"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/ang"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/ang/app"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/fastclick"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/plugins/slimScroll"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts"));
        }
    }
}