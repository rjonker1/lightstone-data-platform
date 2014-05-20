using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.CannedData;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/Package{action}"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}