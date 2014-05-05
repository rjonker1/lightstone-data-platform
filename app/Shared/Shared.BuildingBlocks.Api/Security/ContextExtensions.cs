using Nancy;

namespace Shared.BuildingBlocks.Api.Security
{
    public static class ContextExtensions
    {
        public static string AuthorizationHeaderToken(this NancyContext context)
        {
            const string key = "ApiKey ";

            return (context.Request.Headers.Authorization.StartsWith(key))
                ? context.Request.Headers.Authorization.Substring(key.Length)
                : null;
        }
    }
}