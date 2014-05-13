using Nancy;
using Shared.BuildingBlocks.Api.Security;

namespace UmApi.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IAuthenticateUser authenticator)
        {
            Post["/authenticate"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();

                return string.IsNullOrWhiteSpace(token) ? Response.AsJson((string)null) : Response.AsJson(authenticator.GetUserIdentity(token));
            };
        }
    }
}