using System;
using System.Linq;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;

namespace Shared.BuildingBlocks.Api.Security
{
    public static class PiplineExtensions
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

        public static IPipelines EnableStatelessAuthentication(this IPipelines pipelines, IAuthenticateUser authenticator)
        {
            var configuration = new StatelessAuthenticationConfiguration(context =>
            {
                var token = context.AuthorizationHeaderToken();

                return String.IsNullOrWhiteSpace(token) ? null : authenticator != null ? authenticator.GetUserIdentity(token) : null;
            });

            StatelessAuthentication.Enable(pipelines, configuration);

            return pipelines;
        }

        public static IPipelines EnableCors(this IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext =>
            {
                nancyContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });

            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                nancyContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");

                return null;
            });

            return pipelines;
        }
    }
}