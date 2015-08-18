using System;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;

namespace Shared.BuildingBlocks.Api.Security
{
    public static class PiplineExtensions
    {
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
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });

            return pipelines;
        }
    }
}