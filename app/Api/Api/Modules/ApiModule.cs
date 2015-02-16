using Api.Domain.Infrastructure.Metadata;
using Nancy;

namespace Api.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule(IApiMetaDataGenerator apiMetaDataGenerator)
            : base("/api")
        {
            Get["/"] = parameters => Response.AsJson(apiMetaDataGenerator.GetAllModuleRouteMetaData(Context));
        }
    }
}