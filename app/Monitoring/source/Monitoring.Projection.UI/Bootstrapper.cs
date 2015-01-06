using System.Data;
using Monitoring.Projection.UI.Core.Contracts.Handlers;
using Monitoring.Projection.UI.Core.Contracts.Repositories;
using Monitoring.Projection.UI.Core.Contracts.Services;
using Monitoring.Projection.UI.Infrastructure.Handlers;
using Monitoring.Projection.UI.Infrastructure.Repository;
using Monitoring.Projection.UI.Infrastructure.Repository.Framework.Connection;
using Monitoring.Projection.UI.Infrastructure.Services;
using Nancy;
using Nancy.TinyIoc;

namespace Monitoring.Projection.UI
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IDbConnection>(ConnectionFactory.ForReadDatabase());
            container.Register<IQueryStorage, Repository>();
            container.Register<IDataProviderRepository, DataProviderRepository>();
            container.Register<IHandleDataProviderCommands, DataProviderHandler>();
            container.Register<ICallDataProviderService, DataProviderService>();
        }
    }
}