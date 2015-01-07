﻿using System.Data;
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
            container.Register<IDataProviderRepository, DataProviderRepository>();
            container.Register<IHandleDataProviderCommands, DataProviderHandler>();
            container.Register<ICallDataProviderService, DataProviderService>();
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Content/Images"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Content/Styles"));

            
        }
    }
}