using System;
using Api.Domain.Infrastructure.Metadata;
using Nancy;
using Nancy.Routing;

namespace Api.Infrastructure.Metadata
{
    public class DefaultRouteMetadataProvider : IRouteMetadataProvider
    {
        //private readonly IRouteDescriptionProvider _routeDescriptionProvider = new ApiRouteDescriptionProvider();
        private readonly IRouteDescriptionProvider _routeDescriptionProvider;

        public DefaultRouteMetadataProvider(IRouteDescriptionProvider routeDescriptionProvider)
        {
            _routeDescriptionProvider = routeDescriptionProvider;
        }

        public Type GetMetadataType(INancyModule module, RouteDescription routeDescription)
        {
            return null;
        }

        public object GetMetadata(INancyModule module, RouteDescription routeDescription)
        {
            var description = _routeDescriptionProvider.GetDescription(module, routeDescription.Path);
            return new DefaultRouteMetadata(routeDescription.Method, routeDescription.Path, description);
        }
    }
}