using System;
using System.Configuration;
using System.Data;
using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using EasyNetQ;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Infrastructure.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Dashboard.UI.Infrastructure.Services;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Helpers;
using Nancy.Hosting.Aspnet;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Workflow.BuildingBlocks;

namespace Monitoring.Dashboard.UI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new AspNetRootPathProvider(); }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            //TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));

            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            //pipelines.BeforeRequest.AddItemToEndOfPipeline(nancyContext =>
            //{
            //    this.Info(() => "Api invoked at {0}[{1}]".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url));
            //    var token = "";
            //    var cookie = nancyContext.Request.Headers.Cookie.FirstOrDefault(x => (x.Name + "").ToLower() == "token");
            //    if (cookie != null)
            //        token = HttpUtility.UrlDecode(cookie.Value);

            //    nancyContext.Request.Headers.Authorization = "Token {0}".FormatWith(token);

            //    var user = container.Resolve<ITokenizer>().Detokenize(token, nancyContext, new DefaultUserIdentityResolver());
            //    if (user != null)
            //    {
            //        nancyContext.CurrentUser = user;
            //    }
            //    return null;
            //});

            //pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            //{
            //    this.Error(() => "Error on Monitoring request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
            //    return ErrorResponse.FromException(exception);
            //});
            //TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            base.RequestStartup(container, pipelines, context);
        }
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var userAgent = ConfigurationManager.AppSettings["TokenAuthUserAgentValue"];
            container.Register<ITokenizer>(new Tokenizer(cfg => cfg.AdditionalItems(ctx => ctx.Request.Headers.UserAgent = userAgent).WithKeyCache(new FileSystemTokenKeyStore((new TokenRootPathProvider())))));

            container.Register<ITransactionRepository>(new BillingTransactionRepository());

            container.Register<IRepositoryMapper, RepositoryMapper>();
            container.Register<IHaveTypeMappings, MappingForMonitoringTypes>();
            container.Register<IMonitoringRepository, MonitoringRepository>();
            container.Register<ITransactionRepository, BillingTransactionRepository>();

            container.Register<IHandleMonitoringCommands, DataProviderHandler>();
            container.Register<IHandleDataProviderStatistics, DataProviderStatisticsHandler>();
            container.Register<ICallMonitoringService, DataProviderMonitoringService>();

            container.Register<IHandleDataProviderCaching, DataProviderCachingHandler>();
            container.Register<IPublishCacheMessages, DataProviderCommandPublisher>();
            container.Register<IAdvancedBus>(BusFactory.CreateAdvancedBus(QueueConfigurationReader.CacheSender));
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

        public class TokenRootPathProvider : IRootPathProvider
        {
            public string GetRootPath()
            {
                var keyStore = ConfigurationManager.AppSettings["TokenAuthKeyStorePath"];
                return new Uri(keyStore).LocalPath;
            }
        }
    }
}