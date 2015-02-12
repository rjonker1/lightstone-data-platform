using Api.Domain.Infrastructure.Metadata;
using Nancy;

namespace Api.Modules
{
    public class ApiNancyModule : NancyModule
    {
        public ApiNancyModule(IApiMetaDataGenerator apiMetaDataGenerator)
            : base("/api")
        {
            Get["/"] = parameters => Response.AsJson(apiMetaDataGenerator.GetAllModuleRouteMetaData(Context));
        }
    }
}