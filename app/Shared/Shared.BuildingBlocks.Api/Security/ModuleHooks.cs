using System;
using Nancy;
using Shared.BuildingBlocks.Api.ExceptionHandling;

namespace Shared.BuildingBlocks.Api.Security
{
    public class ModuleHooks
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