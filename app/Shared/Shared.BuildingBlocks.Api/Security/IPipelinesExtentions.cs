using System;
using System.Linq;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;

namespace Shared.BuildingBlocks.Api.Security
{
    public static class IPipelinesExtentions
    {
        public static IPipelines EnableStatelessAuthentication(this IPipelines pipelines)
        {
            var configuration = new StatelessAuthenticationConfiguration(ctx =>
            {
                var apiKey = ctx.Request.Headers.Any(h => h.Key.Equals("apikey", StringComparison.InvariantCultureIgnoreCase));

                if (!apiKey)
                {
                    return null;
                }

                return new ApiUser("Testing");
            });

            StatelessAuthentication.Enable(pipelines, configuration);

            pipelines.BeforeRequest += ctx =>
            {
                if (ctx.CurrentUser == null)
                    return HttpStatusCode.Unauthorized;

                return null;
            };

            return pipelines;
        }
    }
}