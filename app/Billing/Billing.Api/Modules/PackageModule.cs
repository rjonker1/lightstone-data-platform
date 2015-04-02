using System.Collections.Generic;
using Nancy;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Billing.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IPackageBuilderApiClient packageBuilderApiClient)
        {
            Get["/Packages/{filter}"] = parameters =>
            {
                var packagesJson = packageBuilderApiClient.Get("", "Packages", new { parameters.filter });
                //var packages = JsonConvert.DeserializeObject<IEnumerable<PackageDto>>(packagesJson);

                return packagesJson;
            };
        }
    }
}