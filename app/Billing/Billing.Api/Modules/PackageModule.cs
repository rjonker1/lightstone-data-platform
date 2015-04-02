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
            Get["/Packages"] = parameters => packageBuilderApiClient.Get("", "Packages");
        }
    }
}