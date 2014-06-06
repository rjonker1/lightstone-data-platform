using Nancy;

namespace Api.Modules
{
    public class ApiNancyModule : NancyModule
    {
        public ApiNancyModule(IApiMetaDataGenerator apiMetaDataGenerator)
            : base("/api")
        {
            Get["/"] = parameters =>
            {
                return Response.AsJson(apiMetaDataGenerator.GetAllModuleRouteMetaData(Context));
            };
        }
    }
}