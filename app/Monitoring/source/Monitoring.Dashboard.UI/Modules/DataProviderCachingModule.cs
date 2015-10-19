using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Caching.Messages;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Nancy;
using Nancy.Security;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderCachingModule : NancyModule
    {
        private static readonly ILog Log = LogManager.GetLogger<DataProviderCachingModule>();

        public DataProviderCachingModule(IHandleDataProviderCaching handler)
        {
            //this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/dataProviders/caching"] = _ => View["DataProvidersCaching"];

            Post["/dataProviders/caching/refresh"] = _ =>
            {
                Log.Info("Refreshing the cache for Data Providers");

                handler.Handle(new RefreshCacheCommand(Guid.NewGuid(), DateTime.UtcNow));
                return HttpStatusCode.OK;
            };

            Post["/dataProviders/caching/clear"] = _ =>
            {
                handler.Handle(new ClearCacheCommand(Guid.NewGuid(), DateTime.UtcNow));
                return HttpStatusCode.OK;
            };

            Post["/dataProviders/caching/restart"] = _ =>
            {
                handler.Handle(new RestartCacheDataStoreCommand(Guid.NewGuid(), DateTime.UtcNow));
                return HttpStatusCode.OK;
            };
        }
    }
}