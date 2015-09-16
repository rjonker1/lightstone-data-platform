using Nancy;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;

namespace Shared.BuildingBlocks.Api.Extensions
{
    public static class ModuleExtensions
    {
        public static void RequiresRequestClaims(this INancyModule module, params string[] claims)
        {
            module.After.AddItemToEndOfPipeline(ModuleHooks.ReturnForbiddenResponse());
            module.RequiresClaims(claims);
        }
    }
}