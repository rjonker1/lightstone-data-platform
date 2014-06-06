using System.Collections.Generic;
using Nancy;
using Nancy.Routing;

namespace Api
{
    public class ApiMetaDataGenerator : IApiMetaDataGenerator
    {
        private readonly IRouteCacheProvider _routeCacheProvider;
        private readonly IRouteMetadataProvider _routeMetadataProvider;
        private readonly INancyModuleCatalog _nancyModuleCatalog;

        public ApiMetaDataGenerator(IRouteCacheProvider routeCacheProvider, IRouteMetadataProvider routeMetadataProvider, INancyModuleCatalog nancyModuleCatalog)
        {
            _routeCacheProvider = routeCacheProvider;
            _routeMetadataProvider = routeMetadataProvider;
            _nancyModuleCatalog = nancyModuleCatalog;
        }

        public IEnumerable<object> GetAllModuleRouteMetaData(NancyContext context)
        {
            var cache = _routeCacheProvider.GetCache();
            foreach (var module in cache)
            {
                foreach (var routeDescription in module.Value)
                {
                    yield return _routeMetadataProvider.GetMetadata(_nancyModuleCatalog.GetModule(module.Key, context), routeDescription.Item2);
                }
            }
        }
    }
}