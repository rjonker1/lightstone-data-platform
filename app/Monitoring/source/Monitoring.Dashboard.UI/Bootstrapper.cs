using System.Data;
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
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;
using Shared.BuildingBlocks.Api.ExceptionHandling;
using Workflow.BuildingBlocks;

namespace Monitoring.Dashboard.UI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                this.Error(() => "Error on Monitoring request {0}[{1}] => {2}".FormatWith(nancyContext.Request.Method, nancyContext.Request.Url, exception));
                return ErrorResponse.FromException(exception);
            });
        }
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {

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
    }
}