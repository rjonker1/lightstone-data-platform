using DataPlatform.Shared.Public.Entities;
using Shared.BuildingBlocks.Api;

namespace PackageBuilder.Api
{
    using Nancy;

    public class IndexModule : SecureModule
    {
        public IndexModule()
        {
            Get["/package/{action}"] = parameters =>
            {
                var package = new PackageLookup().Get(Context.CurrentUser.UserName, parameters.action);

                return Response.AsJson((IPackage)package);
            };

            Get["/getUserMetaData"] = parameters =>
            {
                var actions = new PackageLookup().GetActions(Context.CurrentUser.UserName);

                return Response.AsJson(new { path = "/action/{action}", actions });
            };
        }
    }
}