using Nancy;
using Nancy.Security;

namespace UserManagement.Api.Helpers.Extensions
{
    public static class ModuleExtensions
    {
        public static void RequiresRoles(this INancyModule module, params string[] claims)
        {
            module.After.AddItemToEndOfPipeline(ModuleHooks.ReturnForbiddenResponse());
            module.RequiresClaims(claims);
        }
    }
}