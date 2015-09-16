using System;
using Nancy;
using Shared.BuildingBlocks.Api.ExceptionHandling;

namespace UserManagement.Api.Helpers.Extensions
{
    public static class ModuleHooks
    {
        public static Action<NancyContext> ReturnForbiddenResponse()
        {
            return context =>
            {
                if (context.Response.StatusCode == HttpStatusCode.Forbidden)
                    context.Response = ErrorResponse.FromException(new UnauthorizedAccessException()).WithStatusCode(HttpStatusCode.Forbidden);
            };
        }
    }
}