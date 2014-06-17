using System;
using Nancy;
using Nancy.Routing;

namespace Api
{
    public class DefaultRouteMetadataProvider : IRouteMetadataProvider
    {
        private readonly IRouteDescriptionProvider _routeDescriptionProvider = new ApiRouteDescriptionProvider();

        //public DefaultRouteMetadataProvider(IRouteDescriptionProvider routeDescriptionProvider)
        //{
        //    _routeDescriptionProvider = routeDescriptionProvider;
        //}

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