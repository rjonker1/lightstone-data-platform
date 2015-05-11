using System;
using Lace.Caching.Messages;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderCachingModule : NancyModule
    {
        public DataProviderCachingModule(IHandleDataProviderCaching handler)
        {
            Get["/dataProviders/caching"] = _ => View["DataProvidersCaching"];

            Post["/dataProviders/caching/refresh"] = _ =>
            {
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