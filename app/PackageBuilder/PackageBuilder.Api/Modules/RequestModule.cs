using Nancy;
using PackageBuilder.Domain.Dtos.Write;

namespace PackageBuilder.Api.Modules
{
    public class RequestModule : NancyModule // : SecureModule
    {
        public RequestModule()
        {
            Get["/Requests"] = parameters => Response.AsJson(new[] { new DataProviderFieldItemDto { Name = "Vin" }, new DataProviderFieldItemDto { Name = "Lic" } });
        }
    }
}