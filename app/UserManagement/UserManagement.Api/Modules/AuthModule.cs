using Common.Logging;
using Nancy;
using Shared.BuildingBlocks.Api.Security;

namespace UmApi.Modules
{
    public class AuthModule : NancyModule
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public AuthModule(IAuthenticateUser authenticator)
        {
            Post["/authenticate"] = parameters =>
            {
                _log.InfoFormat("authenticate");

                var token = Context.AuthorizationHeaderToken();

                return string.IsNullOrWhiteSpace(token) ? Response.AsJson((string)null) : Response.AsJson(authenticator.GetUserIdentity(token));
            };
        }
    }
}