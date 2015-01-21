using System.Data;
using System.Web.Configuration;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Repositories;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Infrastructure.Handlers;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Dashboard.UI.Infrastructure.Repository.Framework.Connection;
using Monitoring.Dashboard.UI.Infrastructure.Services;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace Monitoring.Dashboard.UI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IDbConnection>(ConnectionFactory.ForReadDatabase());
            container.Register<IQueryStorage, Repository>();
            container.Register<IMonitoringRepository, MonitoringRepository>();
            container.Register<IHandleMonitoringCommands, MonitoringHandler>();
            container.Register<ICallMonitoringService, DataProviderMonitoringService>();
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/js"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/images"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/ang"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/assets/ang/app"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts"));

            
        }
    }
}